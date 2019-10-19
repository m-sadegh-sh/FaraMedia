namespace FaraMedia.Services.Validations.FileManagement {
    using FaraMedia.Core;
    using FaraMedia.Core.Domain.FileManagement;
    using FaraMedia.Core.Domain.Misc;
    using FaraMedia.Data.Schemas.FileManagement;
    using FaraMedia.Services.Validations.Extensions;

    public sealed class DownloadValidation : EntityValidationBase<Download> {
        public DownloadValidation() {
            Define(d => d.UseDownloadUrl);

            Define(d => d.ContentType)
                .MaxLength(DownloadConstants.Fields.ContentType.Length)
                .WithInvalidLength(DownloadConstants.Fields.ContentType.Label,
                                   DownloadConstants.Fields.ContentType.Length);

            Define(d => d.FileName)
                .MaxLength(DownloadConstants.Fields.FileName.Length)
                .WithInvalidLength(DownloadConstants.Fields.FileName.Label,
                                   DownloadConstants.Fields.FileName.Length);

            Define(d => d.DownloadUrl);

            ValidateInstance.SafeBy((download, context) => {
                                        var isValid = true;

                                        if (download.UseDownloadUrl) {
                                            download.ContentType = null;
                                            download.FileName = null;

                                            if (download.DownloadUrl == null || string.IsNullOrEmpty(download.DownloadUrl.TargetUrl)) {
                                                context.AddRequired<Download, Redirector>(DownloadConstants.Fields.DownloadUrl.Label,
                                                                                          d => d.DownloadUrl);

                                                isValid = false;
                                            } else if (download.DownloadUrl.TargetUrl.Length > DownloadConstants.Fields.DownloadUrl.Length) {
                                                context.AddInvalidLength<Download, Redirector>(DownloadConstants.Fields.DownloadUrl.Label,
                                                                                               DownloadConstants.Fields.DownloadUrl.Length,
                                                                                               d => d.DownloadUrl);

                                                isValid = false;
                                            } else if (!CommonHelper.IsValidUrl(download.DownloadUrl.TargetUrl)) {
                                                context.AddInvalidFormat<Download, Redirector>(DownloadConstants.Fields.DownloadUrl.Label,
                                                                                               d => d.DownloadUrl);

                                                isValid = false;
                                            }
                                        } else {
                                            download.DownloadUrl = null;

                                            if (string.IsNullOrEmpty(download.ContentType)) {
                                                context.AddRequired<Download, string>(DownloadConstants.Fields.ContentType.Label,
                                                                                      d => d.ContentType);

                                                isValid = false;
                                            }

                                            if (string.IsNullOrEmpty(download.FileName)) {
                                                context.AddRequired<Download, string>(DownloadConstants.Fields.FileName.Label,
                                                                                      d => d.FileName);

                                                isValid = false;
                                            }
                                        }

                                        return isValid;
                                    });
        }
    }
}