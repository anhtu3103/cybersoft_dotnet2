using session40_50.DTOs;

namespace session40_50.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> GetAllProductAsync();
        Task<ProductResponseDTO> GetProductByIdAsync(int Id);
        Task<ProductResponseDTO> CreateProductAsync(ProductRequestDTO productRequestDTO);
        Task<ProductResponseDTO> UpdateProductAsync(int id, ProductRequestDTO productRequestDTO);
        Task<ProductResponseDTO> DeleteProductAsync(int id);
    }
}