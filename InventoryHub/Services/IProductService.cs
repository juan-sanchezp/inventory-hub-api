
using InventoryHub.DTOs;

namespace InventoryHub.Services
{
    public interface IProductService
    {

        List<ProductDTO> GetAll();
        ProductDTO GetById(int id);
        ProductDTO Save(ProductDTO productDTO);

        ProductDTO Update(int id, ProductDTO productDTO);

        ProductDTO DeleteById(int id);
    }
}
