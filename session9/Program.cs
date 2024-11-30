using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // BaiViet baiviet1 =  new BaiViet();
        // baiviet1.tieuDe = "Tieu de 1";
        // baiviet1.hinhAnh = "hinhanh1.png";
        // baiviet1.noiDung = "Noi dung 1";
        // baiviet1.xuatThongtin();


        // BaiViet baiviet2 =  new BaiViet();
        // baiviet2.tieuDe = "Tieu de 1";
        // baiviet2.hinhAnh = "hinhanh1.png";
        // baiviet2.noiDung = "Noi dung 1";

        HocSinh hs1 = new HocSinh();
        hs1.hoTen = "Nguyễn Văn A";
        hs1.tuoi = 20;
        hs1.gioiTinh = "nam";
        hs1.email = "nguyenvana@gmail.com";
        hs1.xuatThongtin();
    }
}