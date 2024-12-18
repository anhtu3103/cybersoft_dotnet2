namespace session15_BTVN_2
{
    class ThoiTrang : SanPham
    {
        private double giamGia;
        public double GiamGia
        {
            get { return giamGia; }
            set { giamGia = value; }
        }
        public ThoiTrang(int maSanPham, string tenSanPham, double giaGoc, double giamGia) : base(maSanPham, tenSanPham, giaGoc)
        {
            GiamGia = giamGia;
        }

        public override double TinhGiaBan()
        {
            return GiaGoc - (GiaGoc * giamGia / 100);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá bán: {TinhGiaBan()}");
        }
    }
}
