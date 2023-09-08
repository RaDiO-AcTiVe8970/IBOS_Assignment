using DAL.EF;
using DAL.EF.Model;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        public readonly IBOS_AssignmentContext _context;
        public DataAccessFactory(IBOS_AssignmentContext context)
        {
            _context = context;
        }
        public IRepo<Employee> EmployeeDataAccess()
        {
            return new EmployeeRepo(_context);
        }
        public IRepo<EmployeeAttendance> EmployeeAttendanceDataAccess()
        {
            return new EmployeeAttendanceRepo(_context);
        }
    }
}