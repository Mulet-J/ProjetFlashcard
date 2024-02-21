using ProjetFlashcard.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFlashcard.Domain.Helpers
{
    public static class CategoryHelpers
    {
        /// <summary>
        /// Get category name
        /// </summary>
        /// <param name="category">Current category</param>
        /// <returns>Category name</returns>
        public static string GetCategoryName(Category category)
        {
            return Enum.GetName(typeof(Category), category);
        }
        /// <summary>
        /// Get next category
        /// </summary>
        /// <param name="category">Curent category</param>
        /// <returns>Next category, or current category if there was an issue with the parameter</returns>
        public static Category GetNextCategory(Category category)
        {
            if(category.Equals(Category.SEVENTH) || category.Equals(Category.DONE))
            {
                return Category.DONE;
            }
            Category[] allCategories = (Category[])Enum.GetValues(typeof(Category));
            int currentIndex = Array.IndexOf(allCategories, category);
            if (currentIndex == -1 || currentIndex == allCategories.Length - 1)
                return category;
            return allCategories[currentIndex + 1];
        }

        public static Category GetFirstCategory()
        {
            return Category.FIRST;
        }
    }
}
