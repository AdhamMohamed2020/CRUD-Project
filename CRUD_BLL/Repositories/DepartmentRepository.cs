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

    public class DepartmentRepository : GenericRepository<Department> , IDepartmentRepository
    {
        public DepartmentRepository(CRUDAppDbContext dbContext):base(dbContext)
        {
            
        }

    }
}
