using Microsoft.AspNetCore.Mvc;
using session40_50.Models;
using session40_50.Interfaces;
using session40_50.Services;
using session40_50.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace session40_50.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productSevice;

        public ProductController(IProductService productSevice)
        {
            _productSevice = productSevice;
        }

        //define API GetAllProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllProducts()
        {
            var products = await _productSevice.GetAllProductAsync();
            return Ok(products);
        }

        //define API GetProductsById
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductsById(int id)
        {
            var product = await _productSevice.GetProductByIdAsync(id);
            if (product == null)
            {
                return BadRequest(new
                {
                    Errormessage = "Product not found"
                });
            }
            return Ok(product);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductResponseDTO>> CreateProduct(ProductRequestDTO productDTO)
        {
            //checkk model invalid
            // 2xx: 200(ok), 201 (created), .... => success
            //from client 4xx: 400 (Bad request), 401(unauthorized), 403(forbidden), 404(not found), 409(conflict), 413(request entity too large), 415(unsupported media type), 422(unprocessable entity
            // => client error
            // 5xx: 500(internal server ) => server error
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //check role
            //user này là property của principalClaim
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (userRole != "Admin")
            {
                return Unauthorized(new { message = "Only admin user can create products" });
            }

            var createdProduct = await _productSevice.CreateProductAsync(productDTO);
            return Ok(createdProduct);
        }

        [HttpPut]
        public async Task<ActionResult<ProductResponseDTO>> UpdateProduct(int Id, ProductRequestDTO productDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //note: check product data already exist have been used in layer service so no need to check in layer controller
            var updatedProduct = await _productSevice.UpdateProductAsync(Id, productDTO);
            if (updatedProduct == null)
                return NotFound();
            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductResponseDTO>> DeleteProduct(int id)
        {
            var product = await _productSevice.DeleteProductAsync(id);
            if (product == null)
            {
                return BadRequest(new
                {
                    Errormessage = "Product not found"
                });
            }
            return Ok(new
            {
                Errormessage = "Product deleted successfully"
            });
        }
    }
}
