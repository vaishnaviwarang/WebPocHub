using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebPOCHub.Models;
using WebPOCHub.DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using WebPOCHub.API.DTO;

namespace WebPOCHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("PublicPolicy")]
    public class EmployeesController : ControllerBase
    {
        private readonly ICommonRepository<Employee> _employeeRepo;
        private readonly IMapper _mapper;
        public EmployeesController(ICommonRepository<Employee> repository, IMapper mapper)
        {
            _employeeRepo = repository;
            _mapper = mapper;
        }
        /*[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type = typeof(IEnumerable<Employee>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var employees = _employeeRepo.GetAll();
            if(employees.Count <= 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Employee))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDetails(int id)
        {
            var employee = _employeeRepo.GetDetails(id);
            return employee == null ? NotFound() : Ok(employee);
        }*/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles ="Employee,HR")]
        public ActionResult<IEnumerable<EmployeeDTO>> Get()
        {
            var employees = _employeeRepo.GetAll();
            if (employees.Count <= 0)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employees));
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "Employee,HR")]
        public ActionResult<EmployeeDTO> GetDetails(int id)
        {
            var employee = _employeeRepo.GetDetails(id);
            return employee == null ? NotFound() : Ok(_mapper.Map<EmployeeDTO>(employee));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Employee,HR")]

        public ActionResult Create(NewEmployeeDTO model)
        {
            var employeeModel = _mapper.Map<Employee>(model);
            _employeeRepo.Insert(employeeModel);
            var employee = _employeeRepo.SaveChanges();
            if (employee > 0)
            {
                var employeeDetails = _mapper.Map<EmployeeDTO>(employeeModel);
                return CreatedAtAction("GetDetails", new { id = employeeDetails.EmployeeId }, employeeDetails);
            }
            return BadRequest();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = "Employee,HR")]

        public IActionResult Update(Employee employee)
        {
            _employeeRepo.Update(employee);
            var result = _employeeRepo.SaveChanges();
            if (result > 0)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Roles = "HR")]
        public ActionResult Delete(int id)
        {
            var employee = _employeeRepo.GetDetails(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _employeeRepo.Delete(employee);
                var result = _employeeRepo.SaveChanges();
                return NoContent();
            }
        }
    }
}
