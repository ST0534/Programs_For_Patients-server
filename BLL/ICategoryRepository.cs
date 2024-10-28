using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;  
namespace BLL
{
    public interface ICategoryRepository
    {
        CategoryDTO GetCategoryById(int id);
        List<CategoryDTO> GetListOfCategories();
        void AddCategory(CategoryDTO c);
        void UpdateCategory(CategoryDTO c);
        void DeleteCategory(CategoryDTO c);


    }
}
