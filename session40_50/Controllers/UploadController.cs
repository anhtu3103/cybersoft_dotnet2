using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using session40_50.Models;
using SixLabors.ImageSharp;

namespace session40_50.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly FileUploadSettings _settings;
        private readonly IWebHostEnvironment _env; //get folder save file

        public UploadController(IOptions<FileUploadSettings> settings, IWebHostEnvironment env)
        {
            _env = env;
            _settings = settings.Value;
        }

        [HttpPost("image")]
        public async Task<ActionResult> UploadImage(IFormFile file)
        {
            try
            {
                //Check file null
                if (file == null || file.Length == 0) 
                {
                    return BadRequest(new
                    {
                        Error = "File is null or empty"
                    });
                }

                //Check image size overlimit
                if(file.Length > _settings.MaxFileSize)
                {
                    return BadRequest(new
                    {
                        Error = "File size is to large"
                    });
                }

                //Check files extension are image
                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!_settings.AllowExtensions.Contains(extension))
                {
                    return BadRequest(new
                    {
                        Error = "File extension is not allowed"
                    });
                }

                //Create file name before save into project
                var fileName = $"{Guid.NewGuid()}.{extension}";
                var uploadPath = Path.Combine(_env.WebRootPath, _settings.UploadPath); // get full path of file

                //Save file
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                var image = await Image.LoadAsync(file.OpenReadStream());
                var filePath = Path.Combine(uploadPath, fileName);
                await image.SaveAsync(filePath);

                return Ok(new UploadResponse
                {
                    Success = true,
                    Message = "File uploaded successfully",
                    FilePath = filePath
                });


            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
