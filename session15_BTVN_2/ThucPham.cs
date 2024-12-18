namespace session15_BTVN_2
{
    class ThucPham : SanPham
    {
        private double phiVanChuyen;
        public double PhiVanChuyen
        {
            get { return phiVanChuyen; }
            set { phiVanChuyen = value; }
        }
        public ThucPham(int maSanPham, string tenSanPham, double giaGoc, double phiVanChuyen) : base(maSanPham, tenSanPham, giaGoc)
        {
            PhiVanChuyen= phiVanChuyen;
        }

        public override double TinhGiaBan()
        {
            return GiaGoc + PhiVanChuyen;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá bán: {TinhGiaBan()}");
        }
    }
}
