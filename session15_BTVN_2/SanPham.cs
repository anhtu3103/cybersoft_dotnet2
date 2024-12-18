namespace session15_BTVN_2
{
    abstract class SanPham
    {
        private int maSanPham;
        public int MaSanPham 
        { 
            get { return maSanPham; } 
            set { maSanPham = value; } 
        }

        private string tenSanPham;
        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }

        private double giaGoc;
        public double GiaGoc
        {
            get { return giaGoc; }
            set { giaGoc = value; }
        }

        public SanPham(int maSanPham, string tenSanPham, double giaGoc)
        {
            MaSanPham = maSanPham;
            TenSanPham= tenSanPham;
            GiaGoc = giaGoc;
        }

        public abstract double TinhGiaBan();

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã sản phẩm: {maSanPham}, Tên sản phẩm: {tenSanPham}, Giá gốc: {giaGoc}");
        }

    }
}
