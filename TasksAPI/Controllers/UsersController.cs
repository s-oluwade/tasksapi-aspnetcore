using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models;
using TasksAPI.Interfaces;
using AutoMapper;
using TasksAPI.Dto;
using TasksAPI.Repository;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController: Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;

        public UsersController(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var users = _mapper.Map<List<UsersDto>>(_usersRepository.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int id)
        {
            var user = _mapper.Map<UsersDto>(_usersRepository.GetUser(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpGet("{id}/tasks")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Objective>))]
        [ProducesResponseType(400)]
        public IActionResult GetUserTasks(int id)
        {
            var objectives = _mapper.Map<List<ObjectivesDto>>(_usersRepository.GetUserObjectives(id));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(objectives);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UsersDto userCreate)
        {
            if (userCreate == null)
                return BadRequest(ModelState);

            var user = _usersRepository.GetUsers().Where(c => c.Name.Trim().ToUpper() == userCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (user != null)
            {
                ModelState.AddModelError("", "User already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userMap = _mapper.Map<User>(userCreate);

            if (!_usersRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int userId, [FromBody] UsersDto updatedUser)
        {
            if (updatedUser == null)
            {
                return BadRequest(ModelState);
            }

            if (userId != updatedUser.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_usersRepository.UserExists(userId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userMap = _mapper.Map<User>(updatedUser);

            if (!_usersRepository.UpdateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong updating user");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("userId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int userId)
        {
            if (!_usersRepository.UserExists(userId))
            {
                return NotFound();
            }

            var userToDelete = _usersRepository.GetUser(userId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_usersRepository.DeleteUser(userToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting user");
            }

            return NoContent();
        }
    }
}
