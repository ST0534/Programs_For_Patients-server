using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DAL;
using DTO;
using Microsoft.AspNetCore.Cors;

namespace ProgramsForPatients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CategoryController : ControllerBase
    {
        ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            CategoryDTO c = categoryRepository.GetCategoryById(id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpGet("GetListCategory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetListCategory()
        {
            List<CategoryDTO> ListCategory = categoryRepository.GetListOfCategories();
            if (ListCategory == null)
                return NotFound();
            return Ok(ListCategory);
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<CategoryDTO> AddCategory(CategoryDTO c)
        {
            if (c == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CategoryDTO c2 = categoryRepository.GetCategoryById(c.Id);
            if (c2 != null)
            {
                return Conflict();
            }
            categoryRepository.AddCategory(c);
            return CreatedAtAction(nameof(AddCategory), new { id = c.Id }, c);
        }
        [HttpPut("updata/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, CategoryDTO c)
        {
            if (c == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != c.Id)
            {
                return Conflict();
            }
            categoryRepository.UpdateCategory(c);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            CategoryDTO c = categoryRepository.GetCategoryById(id);
            if (c == null)
            {
                return NotFound();
            }

            categoryRepository.DeleteCategory(c);
            return NoContent();
        }


    }
}
