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

        public ProductServiceImpl(IProductRepository productAccessBd)
        {
            _productAccessBd = productAccessBd;
        }

        List<ProductDTO> IProductService.GetAll()
        {
            List<ProductEntity> productsEntity = _productAccessBd.GetAll();
            Console.WriteLine("test consult ");
            List<ProductDTO> productDTO = ProductMapper.ToDTOList(productsEntity);
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
            ProductEntity productEntity = ProductMapper.ToEntity(productDTO);
            ProductEntity aux = _productAccessBd.Add(productEntity);
            return ProductMapper.ToDTO(aux);        
        }

        ProductDTO IProductService.Update(int id, ProductDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}

