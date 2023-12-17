using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TasksAPI.Dto;
using TasksAPI.Interfaces;
using TasksAPI.Models;

namespace TasksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectivesController : Controller
    {
        private readonly IObjectivesRepository _objectivesRepository;
        private readonly IMapper _mapper;
        public ObjectivesController(IObjectivesRepository tasksRepository, IMapper mapper) 
        {
            _objectivesRepository = tasksRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Objective>))]
        public IActionResult GetObjectives()
        {
            var objectives = _mapper.Map<List<ObjectivesDto>>(_objectivesRepository.GetObjectives());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(objectives);
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(200, Type = typeof(Objective))]
        [ProducesResponseType(400)]
        public IActionResult GetObjective(int taskId)
        {
            if (!_objectivesRepository.ObjectiveExists(taskId))
            {
                return NotFound();
            }

            var objective = _mapper.Map<ObjectivesDto>(_objectivesRepository.GetObjective(taskId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(objective);
        }
    }
}
