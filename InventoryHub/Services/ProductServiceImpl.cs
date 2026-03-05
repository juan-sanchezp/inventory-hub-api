using AutoMapper;
using InventoryHub.DTOs;
using InventoryHub.Models;
using InventoryHub.Repositories;

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
            Console.WriteLine("test consult");

            return _mapper.Map<List<ProductDTO>>(productsEntity);
        }

        ProductDTO IProductService.GetById(int id)
        {
            ProductEntity product = _productAccessBd.GetById(id);

            if (product == null)
                return null;

            return _mapper.Map<ProductDTO>(product);
        }

        ProductDTO IProductService.Save(ProductDTO productDTO)
        {
            ProductEntity entity = _mapper.Map<ProductEntity>(productDTO);

            var saved = _productAccessBd.Add(entity);

            if (saved == null)
                return null;

            return _mapper.Map<ProductDTO>(saved);
        }

        ProductDTO IProductService.Update(int id, ProductDTO productDTO)
        {
            ProductEntity existingProduct = _productAccessBd.GetById(id);

            if (existingProduct == null)
                return null;

            // Actualiza propiedades
            _mapper.Map(productDTO, existingProduct);

            ProductEntity updated = _productAccessBd.Update(existingProduct);

            return _mapper.Map<ProductDTO>(updated);
        }

        ProductDTO IProductService.DeleteById(int id)
        {
            ProductEntity product = _productAccessBd.GetById(id);

            if (product == null)
                return null;

            _productAccessBd.Delete(product);

            return _mapper.Map<ProductDTO>(product);
        }
    }
}