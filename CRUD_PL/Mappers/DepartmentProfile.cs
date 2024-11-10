using AutoMapper;
using CRUD_DAL.Entities;
using CRUD_PL.ViewModels;

namespace CRUD_PL.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
        }
    }
}
