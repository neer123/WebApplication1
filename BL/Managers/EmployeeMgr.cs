using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
   public class EmployeeMgr : IEmployeeMgr
    {
        readonly App1DBContext _employeeContext;

        public EmployeeMgr(App1DBContext context)
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
