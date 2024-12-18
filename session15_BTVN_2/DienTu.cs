namespace session15_BTVN_2
{
    class DienTu : SanPham
    {
        private double thueBaoHanh;
        public double ThueBaoHanh
        {
            get { return thueBaoHanh; }
            set { thueBaoHanh = value; }
        }
        public DienTu(int maSanPham, string tenSanPham, double giaGoc, double thueBaoHanh) : base(maSanPham, tenSanPham, giaGoc)
        {
            ThueBaoHanh = thueBaoHanh;
        }

        public override double TinhGiaBan()
        {
            return GiaGoc + (GiaGoc * thueBaoHanh / 100);
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã sản phẩm: {MaSanPham}, Tên sản phẩm: {TenSanPham}, Giá bán: {TinhGiaBan()}");
        }
    }
}
