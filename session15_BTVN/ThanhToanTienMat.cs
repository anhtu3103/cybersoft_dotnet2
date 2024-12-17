using session15_BTVN;

class ThanhToanTienMat : ThanhToan, IThanhToan
{
    public ThanhToanTienMat(int maThanhToan, double soTien) : base(maThanhToan, soTien)
    {
        this.PhuongThuc = "Tiền mặt";
    }

    public double ThanhToan(double soTien)
    {
        Console.WriteLine("Thanh toán tiền mặt thành công");
        return soTien;
    }
}