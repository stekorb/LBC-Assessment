using AutoMapper;
using VacationManager.Common.Helpers;
using VacationManager.Dto.Employee;
using VacationManager.Dto.Vacation;
using VacationManager.Models;

namespace VacationManager.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Employee
            CreateMap<EmployeeCreateDto, EmployeeModel>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => EncryptingHelper.HashPassword(src.Password)));
            CreateMap<EmployeeModel, EmployeeDto>().ReverseMap();

            //Vacation
            CreateMap<VacationModel, VacationDto>().ReverseMap();
            CreateMap<VacationCreateDto, VacationModel>();
        }
    }
}
