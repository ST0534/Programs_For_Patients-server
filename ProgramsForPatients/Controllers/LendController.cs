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
    public class LendController : ControllerBase
    {
        ILendRepository lendRepository;
        public LendController(ILendRepository lendRepository)
        {
            this.lendRepository = lendRepository;
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            LendDTO l = lendRepository.GetLendById(id);
            if (l== null)
                return NotFound();
            return Ok(l);
        }
        [HttpGet("GetListLend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetListLend()
        {
            List<LendDTO> ListLend = lendRepository.GetListOfLend();
            if (ListLend == null)
                return NotFound();
            return Ok(ListLend);
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<LendDTO> AddLend(LendDTO l)
        {
            if (l == null || !ModelState.IsValid)
            {
                return Ok(l);
            }
            LendDTO l2 = lendRepository.GetLendById(l.Id);
            if (l2 != null)
            {
                return Conflict();
            }
            lendRepository.AddLend(l);
            return CreatedAtAction(nameof(AddLend), new { id = l.Id }, l);
        }
        [HttpPut("updata/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, LendDTO l)
        {
            if (l == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != l.Id)
            {
                return Conflict();
            }
            lendRepository.UpdateLend(l);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            LendDTO l = lendRepository.GetLendById(id);
            if (l == null)
            {
                return NotFound();
            }

            lendRepository.DeleteLend(l);
            return NoContent();
        }
    }
}
