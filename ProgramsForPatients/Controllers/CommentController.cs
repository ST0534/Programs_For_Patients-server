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
    public class CommentController : ControllerBase
    {
        ICommentRepository commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            CommentDTO c = commentRepository.GetCommentById(id);
            if (c == null)
                return NotFound();
            return Ok(c);
        }
        [HttpGet("GetListComment")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetListComment()
        {
            List<CommentDTO> ListComment = commentRepository.GetListOfComment();
            if (ListComment == null)
                return NotFound();
            return Ok(ListComment);
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<CommentDTO> AddComment(CommentDTO c)
        {
            if (c == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CommentDTO c2 = commentRepository.GetCommentById(c.ID);
            if (c2 != null)
            {
                return Conflict();
            }
            commentRepository.AddComment(c);
            return CreatedAtAction(nameof(AddComment), new { id = c.ID }, c);
        }
        [HttpPut("updata/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, CommentDTO c)
        {
            if (c == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != c.ID)
            {
                return Conflict();
            }
            commentRepository.UpdateComment(c);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            CommentDTO c = commentRepository.GetCommentById(id);
            if (c == null)
            {
                return NotFound();
            }

            commentRepository.DeleteComment(c);
            return NoContent();
        }


    }
}
