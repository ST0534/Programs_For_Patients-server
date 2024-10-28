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
    public class UsersController : ControllerBase
    {
        IUsersRepository usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        [HttpGet("getById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            UsersDTO u = usersRepository.GetUserById(id);
            if (u == null)
                return NotFound();
            return Ok(u);
        }
        [HttpGet("getListUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult getListUsers()
        {
            List<UsersDTO> UsersList = usersRepository.GetListOfUsers();
            if (UsersList == null)
                return NotFound();
            return Ok(UsersList);
        }
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<UsersDTO> AddUsers(UsersDTO u)
        {
            if (u == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            u.Password=BCrypt.Net.BCrypt.HashPassword(u.Password);
            u.Role = "user";
            UsersDTO u2 = usersRepository.GetUserById(u.Id);
            UsersDTO u3= usersRepository.GetListOfUsers().Where(x => x.Email == u.Email).FirstOrDefault();
            UsersDTO u4 = usersRepository.GetListOfUsers().Where(x => x.UserName == u.UserName).FirstOrDefault();
            if (u2 != null|| u3 != null|| u4 != null)
            {
                return Conflict();
            }
            usersRepository.AddUser(u);
            return CreatedAtAction(nameof(AddUsers), new { id = u.Id }, u);
        }
        [HttpPut("updata/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, UsersDTO u)
        {
            if (u == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != u.Id)
            {
                return Conflict();
            }
            usersRepository.UpdateUsers(u);
            return NoContent();
        }
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int id)
        {
            UsersDTO u = usersRepository.GetUserById(id);
            if (u == null)
            {
                return NotFound();
            }

            usersRepository.DeleteUsers(u);
            return NoContent();
        }

        [HttpPost("ExsistUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public IActionResult ExsistUser(UsersDTO u)
        {

            UsersDTO u1 = usersRepository.ExsistUser(u);
            if (u1 == null)
                return NotFound();

            if (!BCrypt.Net.BCrypt.Verify(u.Password, u1.Password))
                return BadRequest();

            string Token = Jwtutils.CreateJWT(u1);

            return Ok(new{ Token,u1});
        }
    }


}

