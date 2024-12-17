using session15_BTVN;

class ThanhToanBangThe : ThanhToan, IThanhToan
{
    public ThanhToanBangThe(int maThanhToan, double soTien) : base(maThanhToan, soTien)
    {
        this.PhuongThuc = "Thanh toán thẻ";
    }
    private int matMaThe = 9999;
    public double ThanhToan(double soTien)
    {
        if (nhapMaPin())
        {
            Console.WriteLine("Thanh toán tiền mặt thành công");
            return soTien;
        }
        else
        {
            Console.WriteLine("Mã pin không hợp lệ, thanh toán bị hủy");
            return 0;
        }
    }

    public bool nhapMaPin()
    {
        int maPin;
        Console.WriteLine("Vui lòng nhập mã pin thẻ gồm 4 số: ");
        try
        {
            maPin = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex) 
        {
            throw new ArgumentException("Xin vui lòng nhập số");
        }
        
        return maPin == matMaThe;
    }



}