using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL;
using BLL;
using DTO;
using Microsoft.AspNetCore.Cors;

namespace ProgramsForPatients.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ProgramsController : ControllerBase
    {
        IProgramsRepository programsRepository;
        public ProgramsController(IProgramsRepository programsRepository)
        {
            this.programsRepository = programsRepository;
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            ProgramsDTO p= programsRepository.GetProgramsById(id);
            if(p==null)
                return NotFound();
            return Ok(p);
        }
        [HttpGet("getListProgram")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getListProgram()  
        {
          List<ProgramsDTO> programList = programsRepository.GetListOfPrograms();
            if (programList == null)
                return NotFound();
            return Ok(programList);
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<ProgramsDTO> AddPrograms(ProgramsDTO p)
        {
            if(p==null||!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ProgramsDTO p2 = programsRepository.GetProgramsById(p.Id);
            if (p2 != null)
            {
                return Conflict();
            }
            programsRepository.AddProgram(p);
            return CreatedAtAction(nameof(AddPrograms),new { id = p.Id} ,p);
        }
        [HttpPut("updata/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, ProgramsDTO p)
        {
            if (p == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != p.Id)
            {
                return Conflict();
            }
            programsRepository.UpdateProgram(p);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            ProgramsDTO p = programsRepository.GetProgramsById(id);
            if (p == null)
            {
                return NotFound();
            }

            programsRepository.DeleteProgram(p);
            return NoContent();
        }


    }
}
