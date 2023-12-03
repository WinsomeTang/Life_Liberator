using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Database;
using UserAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using UserAPI.Models.DTO;
using UserAPI.Models;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Get all Users using DTO
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Users.ToList();

            var userDTOList = new List<UserDTO>();
            foreach (var user in users)
            {
                userDTOList.Add(new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    ProficiencyLevel = user.ProficiencyLevel,
                    Password = user.Password,
                    CustomSchedules = user.CustomSchedules
                });
            }
            return Ok(userDTOList);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ProficiencyLevel = user.ProficiencyLevel,
                Password = user.Password,
                CustomSchedules = user.CustomSchedules
            };

            return Ok(userDto);
        }

        [HttpPost]
        public IActionResult Create(AddUserDTO addUserDto)
        {
            var user = new User
            {
                FirstName = addUserDto.FirstName,
                LastName = addUserDto.LastName,
                Email = addUserDto.Email,
                ProficiencyLevel = addUserDto.ProficiencyLevel,
                Password = addUserDto.Password,
                CustomSchedules = addUserDto.CustomSchedules
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var userDto = new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ProficiencyLevel = user.ProficiencyLevel,
                Password = user.Password,
                CustomSchedules = user.CustomSchedules
            };

            return CreatedAtAction(nameof(GetById), new { id = userDto.Id }, userDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserViewModel userViewModel)
        {
            if (id != userViewModel.Id)
            {
                return BadRequest();
            }

            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = userViewModel.FirstName;
            user.LastName = userViewModel.LastName;
            user.Email = userViewModel.Email;
            user.ProficiencyLevel = userViewModel.ProficiencyLevel;
            user.Password = userViewModel.Password;
            user.CustomSchedules = userViewModel.CustomSchedules;

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
