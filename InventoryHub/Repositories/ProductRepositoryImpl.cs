using InventoryHub.Data;
using InventoryHub.Mapping;
using InventoryHub.Models;
using System;

namespace InventoryHub.Repositories
{
    public class ProductRepositoryImpl : IProductRepository
    {

        private readonly AppDbContext _context;

        public ProductRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }
        public ProductEntity? Add(ProductEntity productEntity)
        {
            var existing = _context.Products
                .FirstOrDefault(p => p.Name == productEntity.Name);

            if (existing != null)
            {
                return null; // ya existe
            }

            _context.Products.Add(productEntity);
            _context.SaveChanges();

            return productEntity;
        }

        public bool Delete(ProductEntity productEntity)
        {
            _context.Products.Remove(productEntity);
            _context.SaveChanges();
            return true;
        }

        public List<ProductEntity> GetAll()
        {
            return _context.Products.ToList();
        }

        public ProductEntity GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public ProductEntity Update(ProductEntity productEntity)
        {
            _context.Products.Update(productEntity);
            _context.SaveChanges();
            return productEntity;
        }
    }
}