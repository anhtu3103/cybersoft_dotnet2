using System;

public class BaiViet
{
    public string tieuDe { get; set; }
    public string noiDung { get; set; }
    public string hinhAnh { get; set; } 

    public void xuatThongtin(){
        Console.WriteLine("Thông tin bài viết:");
        Console.WriteLine($"Tiêu đề: {tieuDe}");
        Console.WriteLine($"Nội dung: {noiDung}");
        Console.WriteLine($"Hình ảnh: {hinhAnh}");
    }
}