class TruongPhong : NhanVien
{
    private double heSoLuong;
    public double HeSoLuong
    {
        get { return heSoLuong;}
        set {heSoLuong = value;}
    }

    public TruongPhong(string maNV, string hoTen, double luongCoBan, double heSoLuong)
        :base(maNV, hoTen, luongCoBan)
    {
        HeSoLuong = heSoLuong;
    }

    public override double tinhLuong()
    {
        return LuongCoBan * heSoLuong;
    }
}