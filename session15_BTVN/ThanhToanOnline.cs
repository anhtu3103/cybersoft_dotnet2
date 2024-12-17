using session15_BTVN;

class ThanhToanOnline : ThanhToan, IThanhToan
{
    public ThanhToanOnline(int maThanhToan, double soTien) : base(maThanhToan, soTien)
    {
        this.PhuongThuc = "Thanh toán online";
    }

    private int OTP = 333111;
    public double ThanhToan(double soTien)
    {
        if (nhapOTP())
        {
            Console.WriteLine("Thanh toán tiền mặt thành công");
            return soTien;
        }
        else
        {
            Console.WriteLine("Mã OTP không hợp lệ, thanh toán bị hủy");
            return 0;
        }
    }

    public bool nhapOTP()
    {
        int otp;
        Console.WriteLine("Vui lòng nhập mã OTP gồm 6 số: ");
        try
        {
            otp = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Xin vui lòng nhập số");
        }

        return otp == this.OTP;
    }
}

