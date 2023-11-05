using AutoMapper;
using WebPOCHub.Models;
using WebPOCHub.API.DTO;

namespace WebPOCHub.API.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Employee,EmployeeDTO>();

            CreateMap<NewEmployeeDTO, Employee>();

            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}
