using session15_BTVN;

internal class Program
{
    private static void Main(string[] args)
    {
        ThanhToanManager thanhToanManager = new ThanhToanManager(); 
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== Chào mừng đến với hệ thống thanh toán ===");
            Console.WriteLine("1. Thanh toán bằng tiền mặt");
            Console.WriteLine("2. Thanh toán bằng thẻ ");
            Console.WriteLine("3. Thanh toán online");
            Console.WriteLine("4. Xem lịch sử giao dịch");
            Console.WriteLine("5. Thoát");
            Console.WriteLine("Vui lòng chọn chức năng (1-5): ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {

                case 1:
                    thanhToanManager.addThanhToanTienMat();
                    break;
                case 2:
                    thanhToanManager.addThanhToanThe();
                    break;
                case 3:
                    thanhToanManager.addThanhToanOnline();
                    break;
                case 4:
                    thanhToanManager.inLichSuThanhToan();
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