using ERPAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAPIController : ControllerBase
    {
        private readonly MvcdbContext db;
        public EmployeeAPIController(MvcdbContext context) {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Getemployees() { 
            var data = await db.Employees.ToListAsync();
            return  Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetstudentbyId(int id)
        {
            var emp = await db.Employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return emp;
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Createemp(Employee emp)
        {
            //if(db.Employee = null)
            //{
            //    return Problem("employee is null");
            //}
           await db.Employees.AddAsync(emp);
           await db.SaveChangesAsync();
           return Ok(emp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Updateemp(int id , Employee emp)
        {
            if (id != emp.Empid)
            {
                return BadRequest();
            }
            db.Entry(emp).State = EntityState.Modified;
            await db.SaveChangesAsync();
            //return Ok(emp);
            return Ok(await db.Employees.ToListAsync()); 
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> Deleteemp(int id)
        {
            var emp = await db.Employees.FindAsync(id);
            if(emp == null)
            {
                return NotFound();
            }
             db.Employees.Remove(emp);
            await db.SaveChangesAsync();
            //return Ok();
            return Ok(await db.Employees.ToListAsync());
        }
    }
}
