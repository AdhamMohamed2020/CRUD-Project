using CRUD_DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_DAL.Contexts
{
    public class CRUDAppDbContext : IdentityDbContext<ApplicationUser>
    {
        public CRUDAppDbContext(DbContextOptions<CRUDAppDbContext> option):base(option) 
        {
            
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
