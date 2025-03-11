using Emgu.CV.CvEnum;
using Emgu.CV;
using LHJ.Application;
using LHJ.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LHJ.IService.IServices;

namespace LHJ.WebHost.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HuHuController : ControllerBase
{
    private readonly IHuHuLogService HuHuLogService;

    public HuHuController(IHuHuLogService huHuLogService) { this.HuHuLogService = huHuLogService; }

    [Tags("获取指定图标位置")]
    [HttpPost("UploadImages")]
    public async Task<IActionResult> UploadTwoImages(IFormFile msterImage, IFormFile templateImage)
    {
        // 确保上传目录存在
        if (!Directory.Exists(CommonStatic.UploadFolder))
        {
            Directory.CreateDirectory(CommonStatic.UploadFolder);
        }
        string filePath1 = await SaveFile(msterImage);

        string filePath12 = await SaveFile(templateImage);

        Mat _mainImage = CvInvoke.Imread(filePath1, ImreadModes.Color);

        Mat _templateImage = CvInvoke.Imread(filePath12, ImreadModes.Color);

        // 创建一个结果矩阵
        Mat result = new Mat();
        CvInvoke.MatchTemplate(_mainImage, _templateImage, result, TemplateMatchingType.CcoeffNormed);

        // 找到最佳匹配位置
        double minVal = 0, maxVal = 0;
        System.Drawing.Point minLoc = new System.Drawing.Point();
        System.Drawing.Point maxLoc = new System.Drawing.Point();
        CvInvoke.MinMaxLoc(result, ref minVal, ref maxVal, ref minLoc, ref maxLoc);

        await HuHuLogService.Add(new SqlSugarCore.Entities.HuHuLog()
        {
            CreateDate = DateTime.Now,
            Desc = $"【模板图片的位置：({maxLoc.X}, {maxLoc.Y})】_主图片路径【{filePath1}】_模板路径【{filePath12}】",
        });

        // 返回文件路径或成功消息
        return Ok(new
        {
            result = $"找到模板图片的位置：({maxLoc.X}, {maxLoc.Y})",
            Message = "两张图片上传成功。"
        });
    }
    // 保存文件到服务器
    private async Task<string> SaveFile(IFormFile file)
    {
        // 生成唯一的文件名
        var fileName = Path.GetRandomFileName() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(CommonStatic.UploadFolder, fileName);

        // 保存文件到服务器
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return filePath;
    }
}
