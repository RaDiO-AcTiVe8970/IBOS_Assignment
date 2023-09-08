using Assignment.DTO;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        //API-01

        [HttpPut("updateEmployee/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDTO obj)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);

                if (employee == null)
                {
                    return NotFound();
                }

                if (await EmployeeCodeExistsAsync(obj.EmployeeCode, id))
                {
                    return BadRequest("Employee code needs to be unique.");
                }

                employee.EmployeeName = obj.EmployeeName;
                employee.EmployeeCode = obj.EmployeeCode;
                employee.EmployeeSalary = obj.EmployeeSalary;
                employee.SupervisorId = obj.SupervisorId;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "An error occurred while saving the changes.");
            }
        }

        private async Task<bool> EmployeeCodeExistsAsync(string employeeCode, int currentEmployeeId)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeCode == employeeCode && e.EmployeeId != currentEmployeeId);
        }


        //API-02
        [HttpGet("thirdHighestSal")]
        public async Task<ActionResult<Employee>> GetEmployeeWithThirdHighestSalary()
        {
            try
            {
                var employee = await _context.Employees
                .OrderByDescending(e => e.EmployeeSalary)
                .Skip(2)
                .Take(1)
                .FirstOrDefaultAsync();

                return employee != null ? Ok(employee) : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        //API-05
        [HttpGet("hierarchyFinder/{employeeId}")]
        public IActionResult GetHierarchy(int employeeId)
        {
            var hierarchy = GetHierarchyRecursive(employeeId);
            if (hierarchy == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(hierarchy);
        }

        private EmployeeHierarchyDTO GetHierarchyRecursive(int employeeId, HashSet<int> visitedIds = null)
        {
            if (visitedIds == null)
            {
                visitedIds = new HashSet<int>();
            }

            if (visitedIds.Contains(employeeId))
            {
                return null;
            }

            visitedIds.Add(employeeId);

            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
            if (employee == null)
            {
                return null;
            }

            var hierarchy = new EmployeeHierarchyDTO
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                Subordinates = new List<EmployeeHierarchyDTO>()
            };

            if (employee.SupervisorId.HasValue)
            {
                var supervisorHierarchy = GetHierarchyRecursive(employee.SupervisorId.Value, visitedIds);
                if (supervisorHierarchy != null)
                {
                    hierarchy.Subordinates.Add(supervisorHierarchy);
                }
            }

            return hierarchy;
        }
    }

}




