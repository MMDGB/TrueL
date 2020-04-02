using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Tryplication.Models;
using Tryplication.Services;

namespace Tryplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeServices;

        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeServices = employeeService;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employeeServices.Get().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(long id)
        {
            try
            {
                return employeeServices.Get().Single(s => s.Id == id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Employee employee)
        {
            if (employeeServices.Get().Any(s => s.Id == employee.Id))
            {
                employeeServices.Update(employee);
                return Ok(employee);
            }

            employeeServices.Add(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee.Id != id)
            {
                return BadRequest();
            }
            if (!employeeServices.Get().Any(s => s.Id == employee.Id))
            {
                return NotFound();
            }

            employeeServices.Update(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            if (!employeeServices.Get().Any(s => s.Id == id))
            {
                return NotFound();
            }

            employeeServices.Delete(id);
            return Ok();
        }
    }
}
