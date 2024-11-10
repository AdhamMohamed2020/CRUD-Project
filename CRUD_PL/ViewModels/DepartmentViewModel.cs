using CRUD_DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace CRUD_PL.ViewModels
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Code is required!!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is required!!")]
        [MaxLength(50, ErrorMessage = "MAx length name is 50 chars")]
        public string Name { get; set; }


        // Navigational Property [Many]
        public ICollection<Employee> Employees { get; set; }
    }
}
