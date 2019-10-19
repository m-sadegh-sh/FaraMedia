using Fara.Core.Domain.Catalog;
using Fara.Core.Domain.Common;
using Fara.Core.Domain.Directory;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Topics;
using Fara.Services.Localization;
using Fara.Services.Seo;
using Fara.Web.Models.Catalog;
using Fara.Web.Models.Common;
using Fara.Web.Models.Topics;

namespace Fara.Web.Extensions
{
    public static class MappingExtensions
    {
        
        public static CategoryModel ToModel(this Category entity)
        {
            if (entity == null)
                return null;

            var model = new CategoryModel()
            {
                Id = entity.Id,
                Name = entity.GetLocalized(x => x.Name),
                Description = entity.GetLocalized(x => x.Description),
                MetaKeywords = entity.GetLocalized(x => x.MetaKeywords),
                MetaDescription = entity.GetLocalized(x => x.MetaDescription),
                MetaTitle = entity.GetLocalized(x => x.MetaTitle),
                SeName = entity.GetSeName(),
            };
            return model;
        }

        
        public static PublisherModel ToModel(this Publisher entity)
        {
            if (entity == null)
                return null;

            var model = new PublisherModel()
            {
                Id = entity.Id,
                Name = entity.GetLocalized(x => x.Name),
                Description = entity.GetLocalized(x => x.Description),
                MetaKeywords = entity.GetLocalized(x => x.MetaKeywords),
                MetaDescription = entity.GetLocalized(x => x.MetaDescription),
                MetaTitle = entity.GetLocalized(x => x.MetaTitle),
                SeName = entity.GetSeName(),
            };
            return model;
        }

        
        public static LanguageModel ToModel(this Language entity)
        {
            if (entity == null)
                return null;

            var model = new LanguageModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                FlagImageFileName = entity.FlagImageFileName,
            };
            return model;
        }


        
        public static CurrencyModel ToModel(this Currency entity)
        {
            if (entity == null)
                return null;

            var model = new CurrencyModel()
            {
                Id = entity.Id,
                Name = entity.GetLocalized(x => x.Name),
            };
            return model;
        }

        
        public static ProductModel ToModel(this Product entity)
        {
            if (entity == null)
                return null;

            var model = new ProductModel()
            {
                Id = entity.Id,
                Name = entity.GetLocalized(x => x.Name),
                ShortDescription = entity.GetLocalized(x => x.ShortDescription),
                FullDescription = entity.GetLocalized(x => x.FullDescription),
                MetaKeywords = entity.GetLocalized(x => x.MetaKeywords),
                MetaDescription = entity.GetLocalized(x => x.MetaDescription),
                MetaTitle = entity.GetLocalized(x => x.MetaTitle),
                SeName = entity.GetSeName(),
            };
            return model;
        }

        
        public static AddressModel ToModel(this Address entity)
        {
            if (entity == null)
                return null;

            var model = new AddressModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Company = entity.Company,
                CountryId = entity.CountryId,
                CountryName = entity.Country != null ? entity.Country.GetLocalized(x => x.Name) : null,
                StateProvinceId = entity.StateProvinceId,
                StateProvinceName = entity.StateProvince != null ? entity.StateProvince.GetLocalized(x => x.Name) : null,
                City = entity.City,
                Address1 = entity.Address1,
                Address2 = entity.Address2,
                ZipPostalCode = entity.ZipPostalCode,
                PhoneNumber = entity.PhoneNumber,
                FaxNumber = entity.FaxNumber,
            };
            return model;
        }
        public static Address ToEntity(this AddressModel model)
        {
            if (model == null)
                return null;

            var entity = new Address();
            return ToEntity(model, entity);
        }
        public static Address ToEntity(this AddressModel model, Address destination)
        {
            if (model == null)
                return destination;

            destination.Id = model.Id;
            destination.FirstName = model.FirstName;
            destination.LastName = model.LastName;
            destination.Email = model.Email;
            destination.Company = model.Company;
            destination.CountryId = model.CountryId;
            destination.StateProvinceId = model.StateProvinceId;
            destination.City = model.City;
            destination.Address1 = model.Address1;
            destination.Address2 = model.Address2;
            destination.ZipPostalCode = model.ZipPostalCode;
            destination.PhoneNumber = model.PhoneNumber;
            destination.FaxNumber = model.FaxNumber;

            return destination;
        }

        
        public static TopicModel ToModel(this Topic entity)
        {
            if (entity == null)
                return null;

            var model = new TopicModel()
            {
                Id = entity.Id,
                SystemName = entity.SystemName,
                IncludeInSitemap = entity.IncludeInSitemap,
                IsPasswordProtected = entity.IsPasswordProtected,
                Title = entity.GetLocalized(x => x.Title),
                Body = entity.GetLocalized(x => x.Body),
                MetaKeywords = entity.GetLocalized(x => x.MetaKeywords),
                MetaDescription = entity.GetLocalized(x => x.MetaDescription),
                MetaTitle = entity.GetLocalized(x => x.MetaTitle),
            };
            return model;
        }
    }
}