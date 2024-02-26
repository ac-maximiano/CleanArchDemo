using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : BaseService<ICategoryRepository>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _repository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(entity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var entity = _mapper.Map<Category>(categoryDTO);

            await _repository.CreateAsync(entity);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var entity = _mapper.Map<Category>(categoryDTO);

            await _repository.UpdateAsync(entity);
        }

        public async Task Remove(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);

            await _repository.RemoveAsync(entity);
        }
    }
}
