using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using session37_api.Data;
using session37_api.Models;

namespace session37_api.Controllers
{

    // rule đặt tên file controller
    // hậu tố phải là Controller. VD: ProductController
    // [controller] => Product
    [ApiController] // thông báo cho .NET biết controller mình tự tạo
    [Route("api/[controller]")] // api/Product
    public class ProductController : ControllerBase
    {
        // define attribute cho đối tượng ProductController
        private readonly ApplicationDbContext _context;

        // define hàm khởi tạo - constructor
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // define các API
        // API GET Product
        [HttpGet] // đánh dấu đây là API GET
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] string? search = null,
                                                                            [FromQuery] int page = 1,
                                                                            [FromQuery] int pageSize = 10)
        {
            //get header
            var userAgent = Request.Headers["User-Agent"].ToString();
            // log header
            Console.WriteLine($"User-Agent: {userAgent}");

            // query
            // cách 1: dùng AsQueryable() => recommend
            // lọc dữ liệu
            // phân trang
            // tìm kiếm
            // tối ưu hiệu suất
            // giảm tải cho database
            // Explain: 
            // - có cơ chế cache built-in
            // - lazy loading: load những dữ liệu cần thiết lên RAM
            // - không load liền từ db mà phải chờ đk filter, phân trang sau đó chờ có lệnh toListAsync thì mới xuống DB get data
            var query = _context.Products.AsQueryable();

            // cách 2: dùng FirstOrDefaultAsync()
            // kém hiệu quả vì hàm này connect tới db và lấy tất cả dữ liệu về, rồi sau đó mới filter dữ liệu

            // cách 3: Where().FirstOrDefaultAsync()
            // select * from product where id = @id

            //áp dụng các điều kiện tìm kiếm
            if (!string.IsNullOrEmpty(search))
            {
                //select * from product
                //where Name like '%search'
                query = query.Where(x => x.Name.Contains(search));
            }

            //phân trang
            var totalItems = await query.CountAsync();
            //vì parameter của hàm ceiling có kiểu là decimal
            //=> phải ép kiểu về số thực
            //vì datatype của hàm ceiling là double
            //=> ép kiểu về int để phù hợp với totalPages
            var totalPages = Math.Ceiling(totalItems / (double)pageSize);

            var products = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return Ok(new
            {
                data = products,
                Pagination = new
                {
                    TotalItem = totalItems,
                    TotalPages = totalPages,
                    CurrentPage = page,
                    PageSize = pageSize
                }
            });

            //return await _context.Products.ToListAsync();
        }


        //Define
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            //check input
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                });
            }

            //check product already exist
            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.Name == product.Name);
            if ((existingProduct != null))
            {
                return BadRequest(new { Message = "Product already exists" });
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Product created successfully",
                Data = product
            });
        }

        //Define API detail product
        [HttpGet("{id}")] //define parameter have name is id
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            // cách 1: dùng FindAsync() => recommened
            // tìm kiếm theo primary key (default index) nên việc truy xuất nhanh hơn
            // cơ chế cache built-in
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound(new
                {
                    Message = "Product not found"
                });
            }
            return Ok(product);
        }

        //define API PUT
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            //Check id from parameter with id from body
            if (id != product.Id)
            {
                return BadRequest(new
                {
                    Message = "Id mismatch"
                });
            }

            //check value of fields in object product
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                });
            }

            //check product already exists in db
            var existingProdct = await _context.Products.FindAsync(id);
            if (existingProdct == null)
            {
                return NotFound(new
                {
                    Message = "Product not found"
                });
            }

            //update product
            //chuyển entity product về mode update
            //_context.Entry(product).State = EntityState.Modified;
            existingProdct.Name = product.Name;
            existingProdct.Price = product.Price;
            existingProdct.Description = product.Description;
            var value = _context.Products.Update(existingProdct);
            await _context.SaveChangesAsync();

            return NoContent();

        }

        //define API delete
        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var existingProdct = await _context.Products.FindAsync(id);
            if(existingProdct == null)
            {
                return NotFound(new
                {
                    Message = "Product not found"
                });
            }

            _context.Products.Remove(existingProdct);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Product deleted successfully"
            });
        }
    }
}



