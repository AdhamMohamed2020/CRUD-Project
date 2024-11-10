using CRUD_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BLL.Interfaces
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName);

        IQueryable<Employee> SearchEmployeesByName(string name);
        
    }
}
