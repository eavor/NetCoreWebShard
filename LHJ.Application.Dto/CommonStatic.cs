namespace LHJ.Application;

public static class CommonStatic
{
    // 定义允许的文件扩展名
    public static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

    // 定义文件保存的目录
    public static readonly string UploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
}
