using System;
using session13_BTVN;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Nhập mã lớp:");
        string classId = Console.ReadLine();

        Console.WriteLine("Nhập tên lớp: ");
        string className = Console.ReadLine();
        HocSinhManager hocSinhManager = new HocSinhManager(classId, className);

        int ma;
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== Library Management Menu ===");
            Console.WriteLine("1. Thêm học sinh vào lớp");
            Console.WriteLine("2. Tìm học sinh theo tên");
            Console.WriteLine("3. Cập nhật điểm số học sinh");
            Console.WriteLine("4. Xóa học sinh");
            Console.WriteLine("5. Xóa học sinh");
            Console.WriteLine("6. Hiển thị danh sách các học sinh và xếp loại");
            Console.WriteLine("7. Hiển thị danh sách các học sinh và điểm trung bình tăng dần");
            Console.WriteLine("7. Hiển thị danh sách các học sinh sắp xếp theo tên");
            Console.WriteLine("9. Hiển thị danh sách các học sinh");
            Console.WriteLine("10. Exit");
            Console.WriteLine("Vui lòng chọn chức năng (1-4): ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    hocSinhManager.addHocSinh();
                    break;
                case 2:
                    Console.WriteLine("Nhập tên cần tìm:");
                    string ten = Console.ReadLine();
                    hocSinhManager.timKiemTheoTen(ten);
                    break;
                case 3:
                    Console.WriteLine("Nhập mã học sinh cần cập nhật: ");
                    ma = Convert.ToInt32(Console.ReadLine());
                    hocSinhManager.capNhatDiemSo(ma);
                    break;
                case 4:
                    Console.WriteLine("Nhập mã học sinh cần xóa: ");
                    ma = Convert.ToInt32(Console.ReadLine());
                    hocSinhManager.xoaHocSinh (ma);
                    break;
                case 5:
                    Console.WriteLine("Nhập mã học sinh cần xóa: ");
                    ma = Convert.ToInt32(Console.ReadLine());
                    hocSinhManager.xoaHocSinh(ma);
                    break;
                case 6:
                    hocSinhManager.xuatThongTinHsVaXepLoai();
                    break;
                case 7:
                    hocSinhManager.sapXepHocSinhTheoDTB();
                    break;
                case 8:
                    hocSinhManager.sapXepHocSinhTheoTen();
                    break;
                case 9:
                    hocSinhManager.displayAllClass();
                    break;
                case 10:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Vui lòng chọn chức năng từ 1-4");
                    break;
            }
        }
    }
}