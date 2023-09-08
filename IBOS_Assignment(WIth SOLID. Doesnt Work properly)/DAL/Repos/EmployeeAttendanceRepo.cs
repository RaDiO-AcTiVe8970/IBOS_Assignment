using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class EmployeeAttendanceRepo : IRepo<EmployeeAttendance>
    {
        private readonly IBOS_AssignmentContext _context;
        public EmployeeAttendanceRepo(IBOS_AssignmentContext context)
        {
            _context = context;
        }
        public async Task<EmployeeAttendance> AddAsync(EmployeeAttendance entity)
        {
            _context.EmployeeAttendances.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _context.EmployeeAttendances.FindAsync(id);
            if (employee != null)
            {
                _context.EmployeeAttendances.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<EmployeeAttendance>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeAttendance> GetByIDAsync(int id)
        {
            return await _context.EmployeeAttendances.FindAsync(id);
        }

        public async Task<EmployeeAttendance> UpdateAsync(EmployeeAttendance entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
