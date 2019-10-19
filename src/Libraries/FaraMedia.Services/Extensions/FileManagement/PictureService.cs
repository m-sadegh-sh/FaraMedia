namespace FaraMedia.Services.FileManagement {
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;

    using FaraMedia.Core;
    using FaraMedia.Core.Data;
    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Core.Domain.Configuration;
    using FaraMedia.Core.Events;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Data.Schemas.Common;
    using FaraMedia.Services.Common;
    using FaraMedia.Services.Infrastructure;
    using FaraMedia.Services.Configuration;
    
    using NHibernate.Validator.Exceptions;

    public sealed class PictureService : PushServiceBase, IPictureService {
        private const string VALID_CHARS = "abcdefghijklmfaraqrstuvwxyz1234567890-";

        private static readonly object _lock = new object();

        private readonly IRepository<Picture> _pictureRepository;
        private readonly IWebHelper _webHelper;
        private readonly IEventPublisher _eventPublisher;
        private readonly MediaUtils _mediaUtils;
        private readonly IFileManagementSettingsService _fileManagementSettingsService;
        private readonly FileManagementSettings _fileManagementSettings;
        private readonly CdnSettings _cdnSettings;

        public PictureService(IRepository<Picture> pictureRepository, IFileManagementSettingsService fileManagementSettingsService, IWebHelper webHelper, IEventPublisher eventPublisher, MediaUtils mediaUtils, FileManagementSettings fileManagementSettings, CdnSettings cdnSettings) {
            _pictureRepository = pictureRepository;
            _webHelper = webHelper;
            _eventPublisher = eventPublisher;
            _mediaUtils = mediaUtils;
            _fileManagementSettingsService = fileManagementSettingsService;
            _fileManagementSettingsService = fileManagementSettingsService;
            _fileManagementSettings = fileManagementSettings;
            _cdnSettings = cdnSettings;
        }

        public bool StoreInDb {
            get { return _fileManagementSettings.StoreInDb; }
            set {
                if (StoreInDb == value)
                    return;

                _fileManagementSettings.StoreInDb = value;
                _fileManagementSettingsService.SaveFileManagementSettings(_fileManagementSettings);

                SwitchPicturesLocation(value);
            }
        }

        public string GetDefaultPictureUrl(int targetSize = 0, PictureType defaultPictureType = PictureType.Entity) {
            string defaultImageName;

            switch (defaultPictureType) {
                case PictureType.Avatar:
                    defaultImageName = _fileManagementSettings.DefaultAvatarImageName;
                    break;
                default:
                    defaultImageName = _fileManagementSettings.DefaultEntityImageName;
                    break;
            }

            var relativePath = string.Concat(_webHelper.GetAppLocation(), _cdnSettings.ImagesPath, defaultImageName);

            if (targetSize == 0)
                return relativePath;

            var filePath = Path.Combine(_fileManagementSettings.LocalImagePath, defaultImageName);

            if (File.Exists(filePath)) {
                var fileExtension = Path.GetExtension(filePath);
                var fileName = string.Format("{0}-{1}{2}", Path.GetFileNameWithoutExtension(filePath), targetSize, fileExtension);

                if (!File.Exists(Path.Combine(_fileManagementSettings.LocalThumbImagePath, fileName))) {
                    var bitmap = new Bitmap(filePath);

                    var newSize = _mediaUtils.CalculateDimensions(bitmap.Size, targetSize);

                    if (newSize.Width < 1)
                        newSize.Width = 1;

                    if (newSize.Height < 1)
                        newSize.Height = 1;

                    var newBitMap = new Bitmap(newSize.Width, newSize.Height);
                    var g = Graphics.FromImage(newBitMap);
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.CompositingQuality = CompositingQuality.HighQuality;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawImage(bitmap, 0, 0, newSize.Width, newSize.Height);

                    var ep = new EncoderParameters();
                    ep.Param[0] = new EncoderParameter(Encoder.Quality, _fileManagementSettings.ImageQuality);
                    var ici = _mediaUtils.GetImageCodecInfoFromExtension(fileExtension) ?? _mediaUtils.GetImageCodecInfoFromMimeType("image/jpeg");

                    newBitMap.Save(Path.Combine(_fileManagementSettings.LocalThumbImagePath, fileName), ici, ep);
                    newBitMap.Dispose();
                    bitmap.Dispose();
                }
                return string.Concat(_webHelper.GetAppLocation(), _fileManagementSettings.LocalThumbImagePath, fileName);
            }
            return relativePath;
        }

        public byte[] GetPictureBinaryFromFile(long id, string mimeType) {
            var extension = _mediaUtils.GetFileExtensionFromMimeType(mimeType);
            var localFileName = string.Format("{0}-0.{1}", id.ToString("0000000"), extension);

            if (!File.Exists(Path.Combine(_fileManagementSettings.LocalImagePath, localFileName)))
                return new byte[0];

            return File.ReadAllBytes(Path.Combine(_fileManagementSettings.LocalImagePath, localFileName));
        }

        public byte[] GetPictureBinary(Picture picture) {
            if (picture == null)
                return null;

            return  GetPictureBinaryFromFile(picture.Id, picture.MimeType);
        }

        public Picture GetPictureById(long id) {
            if (id < 1)
                return null;

            var picture = _pictureRepository.GetById(id);

            return picture;
        }

        public Picture LoadPictureById(long id) {
            if (id < 1)
                return null;

            var picture = _pictureRepository.LoadById(id);

            return picture;
        }

        public string GetPictureUrl(long id, int targetSize = 0, bool showDefaultPicture = true) {
            var picture = GetPictureById(id);

            return GetPictureUrl(picture, targetSize, showDefaultPicture);
        }

        public string GetPictureUrl(Picture picture, int targetSize = 0, bool showDefaultPicture = true) {
            var url = string.Empty;

            if (picture == null || GetPictureBinary(picture).Length == 0) {
                if (showDefaultPicture)
                    url = GetDefaultPictureUrl(targetSize);
                return url;
            }

            var extension = _mediaUtils.GetFileExtensionFromMimeType(picture.MimeType);
            string localFileName;

            if (picture.IsNew) {
                picture.PictureBinary = GetPictureBinary(picture);

                DeletePictureThumbs(picture);

                picture = UpdatePicture(picture).Value;
            }

            lock (_lock) {
                var fileName = picture.FileName;
                if (targetSize == 0) {
                    localFileName = !string.IsNullOrEmpty(fileName) ? string.Format("{0}-{1}.{2}", picture.Id.ToString("0000000"), fileName, extension) : string.Format("{0}.{1}", picture.Id.ToString("0000000"), extension);

                    if (!File.Exists(Path.Combine(_fileManagementSettings.LocalThumbImagePath, localFileName))) {
                        if (!Directory.Exists(_fileManagementSettings.LocalThumbImagePath))
                            Directory.CreateDirectory(_fileManagementSettings.LocalThumbImagePath);
                        File.WriteAllBytes(Path.Combine(_fileManagementSettings.LocalThumbImagePath, localFileName), GetPictureBinary(picture));
                    }
                } else {
                    localFileName = !string.IsNullOrEmpty(fileName) ? string.Format("{0}-{1}-{2}.{3}", picture.Id.ToString("0000000"), fileName, targetSize, extension) : string.Format("{0}-{1}.{2}", picture.Id.ToString("0000000"), targetSize, extension);
                    if (!File.Exists(Path.Combine(_fileManagementSettings.LocalThumbImagePath, localFileName))) {
                        if (!Directory.Exists(_fileManagementSettings.LocalThumbImagePath))
                            Directory.CreateDirectory(_fileManagementSettings.LocalThumbImagePath);
                        using (var stream = new MemoryStream(GetPictureBinary(picture))) {
                            var bitmap = new Bitmap(stream);

                            var newSize = _mediaUtils.CalculateDimensions(bitmap.Size, targetSize);

                            if (newSize.Width < 1)
                                newSize.Width = 1;

                            if (newSize.Height < 1)
                                newSize.Height = 1;

                            var newBitMap = new Bitmap(newSize.Width, newSize.Height);
                            var g = Graphics.FromImage(newBitMap);
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                            g.DrawImage(bitmap, 0, 0, newSize.Width, newSize.Height);
                            var ep = new EncoderParameters();
                            ep.Param[0] = new EncoderParameter(Encoder.Quality, _fileManagementSettings.ImageQuality);
                            var ici = _mediaUtils.GetImageCodecInfoFromExtension(extension) ?? _mediaUtils.GetImageCodecInfoFromMimeType("image/jpeg");
                            newBitMap.Save(Path.Combine(_fileManagementSettings.LocalThumbImagePath, localFileName), ici, ep);
                            newBitMap.Dispose();
                            bitmap.Dispose();
                        }
                    }
                }
            }
            url = string.Concat(_webHelper.GetAppLocation(), _fileManagementSettings.LocalThumbImagePath, localFileName);
            return url;
        }

        public string GetPictureLocalPath(Picture picture, int targetSize = 0, bool showDefaultPicture = true) {
            var url = GetPictureUrl(picture, targetSize, showDefaultPicture);

            if (string.IsNullOrEmpty(url))
                return string.Empty;

            return Path.Combine(_fileManagementSettings.LocalThumbImagePath, Path.GetFileName(url) ?? string.Empty);
        }

        public IQueryable<Picture> GetAllPictures() {
            var pictures = QueryPictures();

            return pictures;
        }

        private IQueryable<Picture> QueryPictures(Func<Picture, bool> predicate = null) {
            var query = _pictureRepository.GetAll();

            if (predicate != null)
                query = query.Where(predicate).AsQueryable();

            query = query.OrderBy(p => p.FileName);

            return query;
        }

        public ServiceOperationResultWithValue<Picture> InsertPicture(Picture picture) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<Picture>>();

            if (picture == null) {
                result.AddResourceError(CommonConstants.Systematic.NullEntity);
                return result;
            }

            picture.PictureBinary = _mediaUtils.ValidatePicture(picture.PictureBinary, picture.MimeType);

            byte[] pictureBinary = null;
            if (!StoreInDb) {
                pictureBinary = picture.PictureBinary;
                picture.PictureBinary = new byte[0];
            }

            InjectUserContentProperties(picture);

            try {
                _pictureRepository.Insert(picture);
            } catch (InvalidStateException invalidStateException) {
                result.InjectExceptionMessages(invalidStateException);
                result.Exception = invalidStateException;
                return result;
            } catch (Exception exception) {
                result.Exception = exception;
                return result;
            }

            if (!StoreInDb)
                SavePictureInFile(picture.Id, pictureBinary, picture.MimeType);

            _eventPublisher.EntityInserted(picture);

            return result.With(picture);
        }

        public ServiceOperationResultWithValue<Picture> UpdatePicture(Picture picture) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<Picture>>();

            if (picture == null) {
                result.AddResourceError(CommonConstants.Systematic.NullEntity);
                return result;
            }

            var dbPicture = GetPictureById(picture.Id);
            if (dbPicture == null) {
                result.AddResourceError(CommonConstants.Systematic.UnknownEntity);
                return result;
            }

            UpdateEntity(picture);

            picture.PictureBinary = _mediaUtils.ValidatePicture(picture.PictureBinary, picture.MimeType);

            if (picture.FileName != dbPicture.FileName)
                DeletePictureThumbs(picture);

            byte[] pictureBinary = null;
            if (!StoreInDb) {
                pictureBinary = picture.PictureBinary;
                picture.PictureBinary = new byte[0];
            }

            try {
                _pictureRepository.Update(picture);
            } catch (InvalidStateException invalidStateException) {
                result.InjectExceptionMessages(invalidStateException);
                result.Exception = invalidStateException;
                return result;
            } catch (Exception exception) {
                result.Exception = exception;
                return result;
            }

            if (!StoreInDb)
                SavePictureInFile(picture.Id, pictureBinary, picture.MimeType);

            _eventPublisher.EntityUpdated(picture);

            return result.With(picture);
        }

        public ServiceOperationResultWithValue<Picture> SetFileName(long id, string newFileName) {
            var result = EngineContext.Current.Resolve<ServiceOperationResultWithValue<Picture>>();

            var picture = GetPictureById(id);

            if (picture == null) {
                result.AddResourceError(CommonConstants.Systematic.UnknownEntity);
                return result;
            }

            if (picture.FileName != newFileName) {
                picture.IsNew = true;
                picture.FileName = newFileName;
                picture.PictureBinary = GetPictureBinary(picture);

                picture = UpdatePicture(picture).Value;
            }

            return result.With(picture);
        }

        public ServiceOperationResult DeletePicture(Picture picture, bool onlyChangeFlag = false) {
            var result = EngineContext.Current.Resolve<ServiceOperationResult>();

            if (picture == null) {
                result.AddResourceError(CommonConstants.Systematic.NullEntity);
                return result;
            }

            if (GetPictureById(picture.Id) == null) {
                result.AddResourceError(CommonConstants.Systematic.UnknownEntity);
                return result;
            }

            if (onlyChangeFlag) {
                picture.IsDeleted = true;
                _pictureRepository.Update(picture);
            } else {
                try {
                    _pictureRepository.Insert(picture);
                } catch (InvalidStateException invalidStateException) {
                    result.InjectExceptionMessages(invalidStateException);
                    result.Exception = invalidStateException;
                    return result;
                } catch (Exception exception) {
                    result.Exception = exception;
                    return result;
                }
            }

            DeletePictureThumbs(picture);

            if (!StoreInDb)
                DeletePictureOnFileSystem(picture);

            _eventPublisher.EntityDeleted(picture);

            return result;
        }

        private void SwitchPicturesLocation(bool storeInDb) {
            var pictures = GetAllPictures();
            foreach (var picture in pictures) {
                picture.PictureBinary = GetPictureBinary(picture, !storeInDb);

                if (storeInDb)
                    DeletePictureOnFileSystem(picture);

                UpdatePicture(picture);
            }
        }

        private void SavePictureInFile(long id, byte[] pictureBinary, string mimeType) {
            var extension = _mediaUtils.GetFileExtensionFromMimeType(mimeType);
            var localFileName = string.Format("{0}-0.{1}", id.ToString("0000000"), extension);

            File.WriteAllBytes(Path.Combine(_fileManagementSettings.LocalImagePath, localFileName), pictureBinary);
        }

        private void DeletePictureOnFileSystem(Picture picture) {
            if (picture == null)
                throw new ArgumentNullException("picture");

            var extension = _mediaUtils.GetFileExtensionFromMimeType(picture.MimeType);
            var localFileName = string.Format("{0}-0.{1}", picture.Id.ToString("0000000"), extension);
            var localFilePath = Path.Combine(_fileManagementSettings.LocalImagePath, localFileName);

            if (File.Exists(localFilePath))
                File.Delete(localFilePath);
        }

        private void DeletePictureThumbs(Picture picture) {
            var filter = string.Format("{0}*.*", picture.Id.ToString("0000000"));
            var currentFiles = Directory.GetFiles(_fileManagementSettings.LocalThumbImagePath, filter);

            foreach (var currentFileName in currentFiles)
                File.Delete(Path.Combine(_fileManagementSettings.LocalThumbImagePath, currentFileName));
        }
    }
}