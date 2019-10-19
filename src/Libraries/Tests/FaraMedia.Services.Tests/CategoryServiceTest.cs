namespace FaraMedia.Services.Tests {
    using FaraMedia.Core.Domain.Components;
    using FaraMedia.Core.Domain.ContentManagement;
    using FaraMedia.Core.Domain.News;
    using FaraMedia.Core.Infrastructure;
    using FaraMedia.Services.News;

    using NUnit.Framework;

    [TestFixture]
    public class CategoryServiceTest {
        [Test]
        public void Create() {
            EngineContext.Initialize(false);

            var categoryService = EngineContext.Current.Resolve<ICategoryService>();

            var validCategory = new Category {
                Title = "Test Category",
                Metadata = new MetadataComponent {
                    Slug = "test-category"
                }
            };

            var validCategoryResult = categoryService.(validCategory);

            Assert.IsTrue(validCategoryResult.Success);

            var invalidCategory = new Category();

            var invalidCategoryResult = categoryService.InsertCategory(invalidCategory);

            Assert.IsTrue(!invalidCategoryResult.Success);
        }
    }
}