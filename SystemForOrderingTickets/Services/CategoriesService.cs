using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemForOrderingTickets.Models;
using SystemForOrderingTickets.Repositories;

namespace SystemForOrderingTickets.Services
{
    public class CategoriesService
    {
        private readonly CategoriesRepository categoriesRepository = new CategoriesRepository(
            HttpContext.Current.Server.MapPath("~/App_Data/CategoryInfo.xml"));

        public Category GetCategoryByName(string categoryName)
        {
            var categories = categoriesRepository.GetCategories();

            return categories.FirstOrDefault(q => q.Name == categoryName);
        }

        public Category GetCategory(int categoryId)
        {
            return categoriesRepository.Get(categoryId);
        }

        public List<Category> GetCategories()
        {
            return categoriesRepository.GetCategories();
        }
    }
}