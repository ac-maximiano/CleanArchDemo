using AutoMapper;

namespace CleanArchMvc.Application.Services
{
    public abstract class BaseService<TRepository> 
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;

        protected BaseService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

    }
}
