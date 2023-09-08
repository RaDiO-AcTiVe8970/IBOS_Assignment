using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using Assignment.DTO;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeAttendanceController : Controller
    {
        private readonly AppDbContext _context;

        public EmployeeAttendanceController(AppDbContext context)
        {
            _context = context;
        }

        //API-03
        [HttpGet("maxSalaryWithoutAbsent")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesMaxSalaryNoAbsent()
        {
            try
            {
                var employees = await _context.Employees
                    .Where(e => !e.EmployeeAttendances.Any(a => a.IsAbsent))
                    .OrderByDescending(e => e.EmployeeSalary)
                    .Select(e => new EmployeeDTO
                    {
                        EmployeeId = e.EmployeeId,
                        EmployeeName = e.EmployeeName,
                        EmployeeCode = e.EmployeeCode,
                        EmployeeSalary = e.EmployeeSalary,
                        SupervisorId = e.SupervisorId
                    })
                    .ToListAsync();

                return employees.Count > 0 ? employees : NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}

