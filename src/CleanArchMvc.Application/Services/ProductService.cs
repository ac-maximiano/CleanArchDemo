using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : BaseService<IProductRepository>, IProductService
    {
        public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper) { }
        
        public async Task<ProductDTO> GetById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(entity);
        }
        
        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var entities = await _repository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(entities);
        }

        public async Task Add(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);

            await _repository.CreateAsync(entity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var entity = _mapper.Map<Product>(productDto);

            await _repository.UpdateAsync(entity);
        }

        public async Task Delete(int? id)
        {
            var entity = await _repository.GetByIdAsync(id);

            await _repository.RemoveAsync(entity);
        }
    }
}
