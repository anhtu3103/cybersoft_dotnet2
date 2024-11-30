public class HocSinh {
    public string hoTen;
    public int tuoi;
    public string gioiTinh;
    public string email;

    public void xuatThongtin()
    {
        Console.WriteLine("Thông tin học sinh :");
        Console.WriteLine($"Họ tên: {hoTen}");
        Console.WriteLine($"Tuổi: {tuoi}");
        Console.WriteLine($"Giới tính: {gioiTinh}");
        Console.WriteLine($"Email: {email}");
    }
}