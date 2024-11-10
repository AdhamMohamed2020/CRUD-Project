using AutoMapper;
using CRUD_DAL.Entities;
using CRUD_PL.ViewModels;

namespace CRUD_PL.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
