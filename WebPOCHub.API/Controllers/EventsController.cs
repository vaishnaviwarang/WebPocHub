using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPOCHub.DataAccessLayer;
using WebPOCHub.Models;

namespace WebPOCHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly ICommonRepository<Event> _eventRepo;
        public EventsController(ICommonRepository<Event> eventRepo)
        {
            _eventRepo = eventRepo;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Event>> Get()
        {
            var events = _eventRepo.GetAll();
            if(events.Count <= 0)
            {
                return NotFound();
            }
            return Ok(events);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Employee> GetDetails(int id)
        {
            var employee = _eventRepo.GetDetails(id);
            return employee == null ? NotFound() : Ok(employee);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(Event model)
        {
            _eventRepo.Insert(model);
            var employee = _eventRepo.SaveChanges();
            if (employee > 0)
            {
                return CreatedAtAction("GetDetails", new { id = model.EventId }, employee);
            }
            return BadRequest();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(Event eventModel)
        {
            _eventRepo.Update(eventModel);
            var result = _eventRepo.SaveChanges();
            if (result > 0)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            var employee = _eventRepo.GetDetails(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _eventRepo.Delete(employee);
                var result = _eventRepo.SaveChanges();
                return NoContent();
            }
        }
    }
}
