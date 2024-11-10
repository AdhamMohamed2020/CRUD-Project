using CRUD_BLL.Interfaces;
using CRUD_DAL.Contexts;
using CRUD_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CRUDAppDbContext _dbContext;

        public EmployeeRepository(CRUDAppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> SearchEmployeesByName(string Name)
       
            => _dbContext.Employees.Where(E => E.Name.Contains(Name));

    }
}
