using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
   public interface IEmployeeMgr
    {
        IEnumerable<Employee> GetAll();
        IQueryable<Employee> GetAll(int skipcount, int takeount);
        Employee Get(long id);
        void Add(Employee entity);
        void Update(Employee employee, Employee entity);
        void Delete(Employee employee);
        int RecordCountEmployee();


    }
}
