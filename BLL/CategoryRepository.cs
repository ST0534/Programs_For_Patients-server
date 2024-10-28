using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DTO;
namespace BLL
{
    public class CategoryRepository:ICategoryRepository
    {
        ProgramsPatients categoryPatients;
        IMapper mapper;
        public CategoryRepository(ProgramsPatients categoryPatients, IMapper mapper)
        {
            this.categoryPatients = categoryPatients;
            this.mapper = mapper;
        }
        public CategoryDTO GetCategoryById(int id)
        {
            Category category = categoryPatients.Categories.Find(id);
            return mapper.Map<CategoryDTO>(category);
        }

        public List<CategoryDTO> GetListOfCategories()
        {
            List<Category> categoryList = categoryPatients.Categories.ToList();
            return mapper.Map<List<CategoryDTO>>(categoryList);

        }
        public void AddCategory(CategoryDTO c)
        {
            categoryPatients.Categories.Add(mapper.Map<Category>(c));
            categoryPatients.SaveChanges();
        }
        public void UpdateCategory(CategoryDTO c)
        {
            categoryPatients.Categories.Update(mapper.Map<Category>(c));
            categoryPatients.SaveChanges();
        }
        public void DeleteCategory(CategoryDTO c)
        {
            categoryPatients.Categories.Remove(mapper.Map<Category>(c));
            categoryPatients.SaveChanges();
        }

    }
}
