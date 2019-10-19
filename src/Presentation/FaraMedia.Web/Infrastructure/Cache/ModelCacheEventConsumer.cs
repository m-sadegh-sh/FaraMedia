using Fara.Core.Caching;
using Fara.Core.Domain.Catalog;
using Fara.Core.Domain.Configuration;
using Fara.Core.Domain.Localization;
using Fara.Core.Domain.Topics;
using Fara.Core.Events;
using Fara.Core.Infrastructure;

namespace Fara.Web.Infrastructure.Cache
{
    
    
    
    public  class ModelCacheEventConsumer: 
        
        IConsumer<EntityInserted<Language>>,
        IConsumer<EntityUpdated<Language>>,
        IConsumer<EntityDeleted<Language>>,
        
        IConsumer<EntityInserted<Setting>>,
        IConsumer<EntityUpdated<Setting>>,
        IConsumer<EntityDeleted<Setting>>,
        
        IConsumer<EntityInserted<Publisher>>,
        IConsumer<EntityUpdated<Publisher>>,
        IConsumer<EntityDeleted<Publisher>>,
        
        IConsumer<EntityInserted<ProductPublisher>>,
        IConsumer<EntityUpdated<ProductPublisher>>,
        IConsumer<EntityDeleted<ProductPublisher>>,
        
        IConsumer<EntityInserted<Category>>,
        IConsumer<EntityUpdated<Category>>,
        IConsumer<EntityDeleted<Category>>,
        
        IConsumer<EntityInserted<ProductCategory>>,
        IConsumer<EntityUpdated<ProductCategory>>,
        IConsumer<EntityDeleted<ProductCategory>>,
        
        IConsumer<EntityInserted<Product>>,
        IConsumer<EntityUpdated<Product>>,
        IConsumer<EntityDeleted<Product>>,
        
        IConsumer<EntityInserted<ProductVariant>>,
        IConsumer<EntityUpdated<ProductVariant>>,
        IConsumer<EntityDeleted<ProductVariant>>,
        
        IConsumer<EntityInserted<ProductTag>>,
        IConsumer<EntityUpdated<ProductTag>>,
        IConsumer<EntityDeleted<ProductTag>>,
        
        IConsumer<EntityInserted<SpecificationAttribute>>,
        IConsumer<EntityUpdated<SpecificationAttribute>>,
        IConsumer<EntityDeleted<SpecificationAttribute>>,
        
        IConsumer<EntityInserted<SpecificationAttributeOption>>,
        IConsumer<EntityUpdated<SpecificationAttributeOption>>,
        IConsumer<EntityDeleted<SpecificationAttributeOption>>,
        
        IConsumer<EntityInserted<ProductSpecificationAttribute>>,
        IConsumer<EntityUpdated<ProductSpecificationAttribute>>,
        IConsumer<EntityDeleted<ProductSpecificationAttribute>>,
        
        IConsumer<EntityInserted<Topic>>,
        IConsumer<EntityUpdated<Topic>>,
        IConsumer<EntityDeleted<Topic>>,
        
        IConsumer<EntityInserted<ViewTemplate>>,
        IConsumer<EntityUpdated<ViewTemplate>>,
        IConsumer<EntityDeleted<ViewTemplate>>,
        
        IConsumer<EntityInserted<ViewTemplate>>,
        IConsumer<EntityUpdated<ViewTemplate>>,
        IConsumer<EntityDeleted<ViewTemplate>>,
        
        IConsumer<EntityInserted<ViewTemplate>>,
        IConsumer<EntityUpdated<ViewTemplate>>,
        IConsumer<EntityDeleted<ViewTemplate>>
    {
        
        
        
        
        
        
        
        public const string MANUFACTURER_NAVIGATION_MODEL_KEY = "fara.pres.publisher.navigation-{0}-{1}";
        public const string MANUFACTURER_NAVIGATION_PATTERN_KEY = "fara.pres.publisher.navigation";

        
        
        
        
        
        
        
        
        public const string CATEGORY_NAVIGATION_MODEL_KEY = "fara.pres.category.navigation-{0}-{1}-{2}";
        public const string CATEGORY_NAVIGATION_PATTERN_KEY = "fara.pres.category.navigation";

        
        
        
        
        
        
        public const string PRODUCTTAG_BY_PRODUCT_MODEL_KEY = "fara.pres.producttag.byproduct-{0}";
        public const string PRODUCTTAG_BY_PRODUCT_PATTERN_KEY = "fara.pres.producttag.byproduct";

        
        
        
        public const string PRODUCTTAG_POPULAR_MODEL_KEY = "fara.pres.producttag.popular";
        public const string PRODUCTTAG_POPULAR_PATTERN_KEY = "fara.pres.producttag.popular";

        
        
        
        
        
        
        
        public const string PRODUCT_BREADCRUMB_MODEL_KEY = "fara.pres.product.breadcrumb-{0}-{1}";
        public const string PRODUCT_BREADCRUMB_PATTERN_KEY = "fara.pres.product.breadcrumb";

        
        
        
        
        
        
        
        public const string PRODUCT_MANUFACTURERS_MODEL_KEY = "fara.pres.product.publishers-{0}-{1}";
        public const string PRODUCT_MANUFACTURERS_PATTERN_KEY = "fara.pres.product.publishers";

        
        
        
        
        
        
        
        public const string PRODUCT_SPECS_MODEL_KEY = "fara.pres.product.specs-{0}-{1}";
        public const string PRODUCT_SPECS_PATTERN_KEY = "fara.pres.product.specs";

        
        
        
        
        
        
        
        public const string TOPIC_MODEL_KEY = "fara.pres.topic.details-{0}-{1}";
        public const string TOPIC_PATTERN_KEY = "fara.pres.topic.details";

        
        
        
        
        
        
        public const string CATEGORY_TEMPLATE_MODEL_KEY = "fara.pres.viewtemplate-{0}";
        public const string CATEGORY_TEMPLATE_PATTERN_KEY = "fara.pres.viewtemplate";

        
        
        
        
        
        
        public const string MANUFACTURER_TEMPLATE_MODEL_KEY = "fara.pres.publishertemplate-{0}";
        public const string MANUFACTURER_TEMPLATE_PATTERN_KEY = "fara.pres.publishertemplate";

        
        
        
        
        
        
        public const string PRODUCT_TEMPLATE_MODEL_KEY = "fara.pres.producttemplate-{0}";
        public const string PRODUCT_TEMPLATE_PATTERN_KEY = "fara.pres.producttemplate";

        private readonly ICacheManager _cacheManager;
        
        public ModelCacheEventConsumer()
        {
            
            this._cacheManager = EngineContext.Current.ContainerManager.Resolve<ICacheManager>("fara_cache_static");
        }
        
        
        public void HandleEvent(EntityInserted<Language> eventMessage)
        {
            
            _cacheManager.RemoveByPattern(MANUFACTURER_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(TOPIC_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Language> eventMessage)
        {
            
            _cacheManager.RemoveByPattern(MANUFACTURER_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(TOPIC_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Language> eventMessage)
        {
            
            _cacheManager.RemoveByPattern(MANUFACTURER_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
            _cacheManager.RemoveByPattern(TOPIC_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<Setting> eventMessage)
        {
            
        }
        public void HandleEvent(EntityUpdated<Setting> eventMessage)
        {
            
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY); 
        }
        public void HandleEvent(EntityDeleted<Setting> eventMessage)
        {
            
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY); 
        }
        
        
        public void HandleEvent(EntityInserted<Publisher> eventMessage)
        {
            _cacheManager.RemoveByPattern(MANUFACTURER_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Publisher> eventMessage)
        {
            _cacheManager.RemoveByPattern(MANUFACTURER_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Publisher> eventMessage)
        {
            _cacheManager.RemoveByPattern(MANUFACTURER_NAVIGATION_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<ProductPublisher> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ProductPublisher> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ProductPublisher> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_MANUFACTURERS_PATTERN_KEY);
        }
        
        
        public void HandleEvent(EntityInserted<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Category> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<ProductCategory> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ProductCategory> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ProductCategory> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_BREADCRUMB_PATTERN_KEY);
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<Product> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<Product> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Product> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<ProductVariant> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ProductVariant> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ProductVariant> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_NAVIGATION_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<ProductTag> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCTTAG_POPULAR_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCTTAG_BY_PRODUCT_MODEL_KEY);
        }
        public void HandleEvent(EntityUpdated<ProductTag> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCTTAG_POPULAR_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCTTAG_BY_PRODUCT_MODEL_KEY);
        }
        public void HandleEvent(EntityDeleted<ProductTag> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCTTAG_POPULAR_PATTERN_KEY);
            _cacheManager.RemoveByPattern(PRODUCTTAG_BY_PRODUCT_MODEL_KEY);
        }
        
        
        public void HandleEvent(EntityInserted<SpecificationAttribute> eventMessage)
        {
        }
        public void HandleEvent(EntityUpdated<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<SpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }
        
        
        public void HandleEvent(EntityInserted<SpecificationAttributeOption> eventMessage)
        {
        }
        public void HandleEvent(EntityUpdated<SpecificationAttributeOption> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<SpecificationAttributeOption> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }
        
        
        public void HandleEvent(EntityInserted<ProductSpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ProductSpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ProductSpecificationAttribute> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_SPECS_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<Topic> eventMessage)
        {
        }
        public void HandleEvent(EntityUpdated<Topic> eventMessage)
        {
            _cacheManager.RemoveByPattern(TOPIC_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<Topic> eventMessage)
        {
            _cacheManager.RemoveByPattern(TOPIC_PATTERN_KEY);
        }
        
        
        public void HandleEvent(EntityInserted<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_TEMPLATE_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_TEMPLATE_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(CATEGORY_TEMPLATE_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(MANUFACTURER_TEMPLATE_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(MANUFACTURER_TEMPLATE_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(MANUFACTURER_TEMPLATE_PATTERN_KEY);
        }

        
        public void HandleEvent(EntityInserted<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_TEMPLATE_PATTERN_KEY);
        }
        public void HandleEvent(EntityUpdated<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_TEMPLATE_PATTERN_KEY);
        }
        public void HandleEvent(EntityDeleted<ViewTemplate> eventMessage)
        {
            _cacheManager.RemoveByPattern(PRODUCT_TEMPLATE_PATTERN_KEY);
        }
    }
}
