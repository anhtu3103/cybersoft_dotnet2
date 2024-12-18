using session15_BTVN_2;

internal class Program
{
    private static void Main(string[] args)
    {
        ShopManagement shopManagement = new ShopManagement();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== Chào mừng đến với shop online ===");
            Console.WriteLine("1. Thêm sản phẩm");
            Console.WriteLine("2. Hiển thị danh sách sản phẩm ");
            Console.WriteLine("3. Tính tổng doanh thu");
            Console.WriteLine("4. Xóa sản phẩm");
            Console.WriteLine("5. Thoát");
            Console.WriteLine("Vui lòng chọn chức năng (1-5): ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    while (true)
                    {
                        Console.WriteLine("Chọn loại sản phẩm");
                        Console.WriteLine("1. Điện tử");
                        Console.WriteLine("2. Thời trang");
                        Console.WriteLine("3. Thực phẩm");
                        Console.WriteLine("Vui lòng chọn sản phẩm (1-3): ");
                        int subChoice = Convert.ToInt32(Console.ReadLine());
                        if (subChoice == 1)
                        {
                            shopManagement.addDienTu();
                            break;
                        }
                        else if (subChoice == 2)
                        {
                            shopManagement.addThoiTrang();
                            break;
                        }
                        else if (subChoice == 3)
                        {
                            shopManagement.addThucPham();
                            break;
                        }
                        else
                            Console.WriteLine("Lựa chọn không hợp lệ mời nhập lại");
                    }
                    break;
                case 2:
                    shopManagement.HienThiDanhSachSanPham();
                    break;
                case 3:
                    Console.WriteLine($"Tổng doanh thu dự kiến: {shopManagement.tinhTongDoanhThu()}");
                    break;
                case 4:
                    Console.WriteLine("Nhập mã sản phẩm cần xóa: ");
                    int maSanPham = Convert.ToInt32(Console.ReadLine());
                    if (shopManagement.XoaSanPham(maSanPham))
                        Console.WriteLine("Xóa sản phẩm thành công");
                    else
                        Console.WriteLine("Mã sản phẩm không tồn tại");
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Vui lòng chọn chức năng từ 1-5");
                    break;
            }

        }

    }
}