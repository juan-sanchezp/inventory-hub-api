using AutoMapper;
using InventoryHub.DTOs;
using InventoryHub.Mapping;
using InventoryHub.Models;
using InventoryHub.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace InventoryHub.Services
{
    public class ProductServiceImpl : IProductService
    {

        private readonly IProductRepository _productAccessBd;
        private readonly IMapper _mapper;

        public ProductServiceImpl(IProductRepository productAccessBd, IMapper mapper)
        {
            _productAccessBd = productAccessBd;
            _mapper = mapper;
        }

        List<ProductDTO> IProductService.GetAll()
        {
            List<ProductEntity> productsEntity = _productAccessBd.GetAll();
            Console.WriteLine("test consult ");
            List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(productsEntity);
            return productDTO;

        }

        
        ProductDTO IProductService.DeleteById(int id)
        {
            throw new NotImplementedException();
        }


        ProductDTO IProductService.GetById(int id)
        {
            throw new NotImplementedException();
        }

        ProductDTO IProductService.Save(ProductDTO productDTO)
        {
            ProductEntity productEntity = _mapper.Map<ProductEntity>(productDTO);
            ProductEntity saved = _productAccessBd.Add(productEntity);
            return _mapper.Map<ProductDTO>(saved);        
        }

        ProductDTO IProductService.Update(int id, ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}

