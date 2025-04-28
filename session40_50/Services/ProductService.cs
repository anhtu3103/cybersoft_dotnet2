
using session40_50.Interfaces;
using session40_50.Models;
using session40_50.DTOs;

namespace session40_50.Services
{
    public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    
        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllProductAsync();

            //convert from entity to DTO
            return products.Select(p => MapToProductResponseDTO(p));
        }

        public async Task<ProductResponseDTO> GetProductByIdAsync(int Id)
        {
            var product = await _productRepository.GetProductByIDAsync(Id);
            if (product == null)
                return null;

            return MapToProductResponseDTO(product);
        }

        public async Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO productRequestDTO)
        {
            //create entity from productRequestDTO
            var product = new Product {
                CategoryID = productRequestDTO.CategoryID,
                Name = productRequestDTO.Name,
                Description = productRequestDTO.Description,
                Price = productRequestDTO.Price,
                OriginalPrice = productRequestDTO.OriginalPrice,
                Discount = productRequestDTO.Discount,
                Stock = productRequestDTO.Stock,
                Sold = 0,
                Rating = 0,
                ReviewCount = 0
            };

            //send entity to reporsitory
            var createdProduct = await _productRepository.CreateProductAsync(product);

            //return DTO
            return MapToProductResponseDTO(createdProduct);
        }

        public async Task<ProductResponseDTO> UpdateProductAsync(int id, ProductRequestDTO productRequestDTO)
        {
            //Lưu ý: có thể tạo updatedProductDTO
            var product = new Product
            {
                CategoryID = productRequestDTO.CategoryID,
                Name = productRequestDTO.Name,
                Description = productRequestDTO.Description,
                Price = productRequestDTO.Price,
                OriginalPrice = productRequestDTO.OriginalPrice,
                Discount = productRequestDTO.Discount,
                Stock = productRequestDTO.Stock,
                Sold = 0,
                Rating = 0,
                ReviewCount = 0
            };

            //send entity to repository
            var updateProduct = await _productRepository.UpdateProductAsync(id, product);

            return updateProduct != null ? MapToProductResponseDTO(updateProduct) : null;
        }

        //define function MapToProductResponseDTO
        //input: Product entity
        //output: ProductResponseDTO
        private ProductResponseDTO MapToProductResponseDTO(Product product)
        {
            return new ProductResponseDTO
            {
                ProductID = product.ProductID,
                CategoryID = product.CategoryID,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                Discount = product.Discount,
                Stock = product.Stock,
                Sold = product.Sold,
                Rating = product.Rating,
                ReviewCount = product.ReviewCount
            };
        }

        public async Task<ProductResponseDTO> DeleteProductAsync(int id)
        {
            var deleteProduct =  await _productRepository.DeleteProductAsync(id);
            return deleteProduct != null ? MapToProductResponseDTO(deleteProduct) : null;
        }
    }
}