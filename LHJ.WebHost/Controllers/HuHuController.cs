using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LHJ.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HuHuController : ControllerBase
    {
        // 定义允许的文件扩展名
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        // 定义文件保存的目录
        private static readonly string UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            // 检查文件是否为空
            if (file == null || file.Length == 0)
            {
                return BadRequest("未上传文件或文件为空。");
            }

            // 检查文件扩展名是否允许
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(fileExtension) || !AllowedExtensions.Contains(fileExtension))
            {
                return BadRequest("不支持的文件类型。");
            }

            // 确保上传目录存在
            if (!Directory.Exists(UploadFolder))
            {
                Directory.CreateDirectory(UploadFolder);
            }

            // 生成唯一的文件名
            var fileName = Path.GetRandomFileName() + fileExtension;
            var filePath = Path.Combine(UploadFolder, fileName);

            // 保存文件到服务器
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // 返回文件路径或成功消息
            return Ok(new { FilePath = filePath, Message = "文件上传成功。" });
        }
    }
}
