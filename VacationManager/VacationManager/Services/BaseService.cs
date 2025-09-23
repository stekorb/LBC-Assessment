using AutoMapper;

namespace VacationManager.Services
{
    public abstract class BaseService
    {
        public readonly IMapper _mapper;

        public BaseService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
