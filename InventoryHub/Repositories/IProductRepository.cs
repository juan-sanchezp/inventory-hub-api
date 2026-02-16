using InventoryHub.DTOs;
using InventoryHub.Models;

namespace InventoryHub.Repositories
{
    public interface IProductRepository
    {
        List<ProductEntity> GetAll();
        ProductEntity GetById(int id);
        ProductEntity Add (ProductEntity productEntity);
        ProductEntity Update (ProductEntity productEntity);
        bool Delete (ProductEntity productEntity);
    }
}