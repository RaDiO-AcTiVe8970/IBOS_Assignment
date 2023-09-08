using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// EmployeeService.cs
namespace BLL.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> UpdateEmployeeAsync(int id, EmployeeDTO updateDto);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepo<Employee> _employeeRepository;

        public EmployeeService(IRepo<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeeAsync()
        {
            var employee= await _employeeRepository.GetAllAsync();
            return employee.Select(x => new EmployeeDTO
            {
                employeeId = x.employeeId,
                employeeName = x.employeeName,
                employeeCode = x.employeeCode,
                employeeSalary = x.employeeSalary,
                supervisorId = x.supervisorId
            }).ToList();
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(int id, EmployeeDTO updateDto)
        {
            // ... (your existing code to validate and update)

            var employee = await _employeeRepository.UpdateAsync(new Employee
            {
                employeeId = id,
                employeeName = updateDto.employeeName,
                employeeCode = updateDto.employeeCode,
                employeeSalary = updateDto.employeeSalary,
                supervisorId = updateDto.supervisorId
            });

            return new EmployeeDTO
            {
                employeeId = employee.employeeId,
                employeeName = employee.employeeName,
                employeeCode = employee.employeeCode,
                employeeSalary = employee.employeeSalary,
                supervisorId = employee.supervisorId
            };
        }
    }
}
