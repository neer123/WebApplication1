using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly SchoolContext _employeeContext;

        public EmployeeManager(SchoolContext context)
        {
            _employeeContext = context;

        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }
        public IQueryable<Employee> GetAll(int skipcount, int takeount)
        {
            return _employeeContext.Employees.Skip(skipcount).Take(takeount);
        }

        public Employee Get(long id)
        {
            return _employeeContext.Employees
                  .FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            //employee.FirstName = entity.FirstName;
            //employee.LastName = entity.LastName;
            //employee.Email = entity.Email;
            //employee.DateOfBirth = entity.DateOfBirth;
            //employee.PhoneNumber = entity.PhoneNumber;

            _employeeContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public int RecordCountEmployee()
        {
             return _employeeContext.Employees.Count();
        }
    }
}
