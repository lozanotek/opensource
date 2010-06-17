namespace Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using DataAccess;
    using Domain;
    using NUnit.Framework;
    using Rhino.Mocks;
    using Services;

    public class BlogEngineServiceFixture : AutoMockingFixture
    {
        #region Category Operations

        [Test]
        public void DeleteCategory()
        {
            var service = Create<BlogEngineService>();
            var category = new Category {Name = "Test", Description = "Test"};

            using (Record)
            {
                var categoryRepository = Get<ICategoryRepository>();
                Expect.Call(categoryRepository.GetCategoryByName(null)).Return(category);
                LastCall.IgnoreArguments();

                Expect.Call(() => categoryRepository.Delete(category));
            }

            using (Playback)
            {
                service.DeleteCategory(category.Name);
            }
        }

        [Test]
        public void GetAllCategories_Test()
        {
            var service = Create<BlogEngineService>();

            IList<Category> list = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                list.Add(Mock<Category>());
            }

            using (Record)
            {
                var categoryRepository = Get<ICategoryRepository>();
                Expect.Call(categoryRepository.RetrieveAll()).Return(list);
            }

            using (Playback)
            {
                Category[] result = service.GetAllCategories();
                Category[] expected = list.ToArray();

                Assert.IsNotNull(result);
                CollectionAssert.AllItemsAreNotNull(result);
                CollectionAssert.AreEqual(result, expected);
            }
        }

        [Test]
        public void NewCategory_Test()
        {
            var service = Create<BlogEngineService>();
            var category = new Category {Name = "Test", Description = "Test"};

            using (Record)
            {
                var categoryRepository = Get<ICategoryRepository>();
                Expect.Call(categoryRepository.Create(null)).Return(category);
                LastCall.IgnoreArguments();
            }

            using (Playback)
            {
                Category result = service.NewCategory(category.Name, category.Description);

                Assert.IsNotNull(result);
                Assert.AreEqual(result.Name, category.Name);
                Assert.AreEqual(result.Description, category.Description);
            }
        }

        [Test]
        public void UpdateCategory_Test()
        {
            var service = Create<BlogEngineService>();
            var category = new Category {Name = "Test", Description = "Test"};

            using (Record)
            {
                var categoryRepository = Get<ICategoryRepository>();
                Expect.Call(() => categoryRepository.Update(category));
                LastCall.IgnoreArguments();
            }

            using (Playback)
            {
                service.UpdateCategory(category);
            }
        }

        #endregion

    }
}