using Microsoft.AspNetCore.Mvc;
using TasksAPI.Models;
using TasksAPI.Interfaces;
using AutoMapper;
using TasksAPI.Dto;

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
    }
}
