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
        public static string GetCategoryName(Category category)
        {
            return Enum.GetName(typeof(Category), category);
        }

        public static Category GetNextCategory(Category category)
        {
            if(category.Equals(Category.SEVENTH) || category.Equals(Category.DONE))
            {
                return Category.DONE;
            }
            return (Category)((int)category * 2);
        }

        public static Category GetFirstCategory()
        {
            return Category.FIRST;
        }
    }
}
