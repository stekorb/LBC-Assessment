using AutoMapper;
using VacationManager.Dto.Employee;
using VacationManager.Models;

namespace VacationManager.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Employee
            CreateMap<EmployeeCreateDto, EmployeeModel>();
            CreateMap<EmployeeModel, EmployeeDto>();
        }
    }
}
