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
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        public ObjectivesController(IObjectivesRepository tasksRepository, IUsersRepository usersRepository, IMapper mapper) 
        {
            _objectivesRepository = tasksRepository;
            _usersRepository = usersRepository;
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

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateObjective([FromQuery] int userId, [FromBody] ObjectivesDto objectiveCreate)
        {
            if (objectiveCreate == null)
                return BadRequest(ModelState);

            var objective = _objectivesRepository.GetObjectives().Where(c => c.Title.Trim().ToUpper() == objectiveCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (objective != null)
            {
                ModelState.AddModelError("", "Objective already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var objectiveMap = _mapper.Map<Objective>(objectiveCreate);
            User u = _usersRepository.GetUser(userId);

            if (u == null) 
            {
                ModelState.AddModelError("", "A user with that id does not exist");
                return StatusCode(422, ModelState);
            }

            objectiveMap.User = u;

            if (!_objectivesRepository.CreateObjective(objectiveMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{objectiveId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateObjective(int objectiveId, [FromBody]ObjectivesDto updatedObjective)
        {
            if (updatedObjective == null)
            {
                return BadRequest(ModelState);
            }

            if (objectiveId != updatedObjective.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_objectivesRepository.ObjectiveExists(objectiveId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid) return BadRequest();

            var objectiveMap = _mapper.Map<Objective>(updatedObjective);

            if(!_objectivesRepository.UpdateObjective(objectiveMap))
            {
                ModelState.AddModelError("", "Something went wrong updating objective");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("objectiveId")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteObjective(int objectiveId)
        {
            if(!_objectivesRepository.ObjectiveExists(objectiveId))
            {
                return NotFound();
            }

            var objectiveToDelete = _objectivesRepository.GetObjective(objectiveId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_objectivesRepository.DeleteObjective(objectiveToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting objective");
            }

            return NoContent();
        }
    }
}
