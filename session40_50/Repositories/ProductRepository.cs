using Microsoft.EntityFrameworkCore;
using session40_50.Data;
using session40_50.DTOs;
using session40_50.Interfaces;
using session40_50.Models;

namespace session40_50.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            //EF core will be change to SQL and connect to DB
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIDAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            //create data for CreateAt and UpdateAt
            product.CreatedAt = DateTime.UtcNow;
            product.UpdatedAt = DateTime.UtcNow;

             _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            //get product from db
            var existingProduct = await _context.Products.FindAsync(id);

            //Check product if not exist then return null
            if (existingProduct == null)
            {
                return null;
            }

            //if product exist then update and return to product entity
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.OriginalPrice = product.OriginalPrice;
            existingProduct.Discount = product.Discount;
            existingProduct.Stock = product.Stock;
            
            await _context.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<Product> DeleteProductAsync(int id)
        {
            var existingProduct = await _context.Products.FindAsync(id);

            //Check product if not exist then return null
            if (existingProduct == null)
            {
                return null;
            }

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
            return existingProduct;
        }
    }
}