
namespace session15_BTVN_2
{
    class ShopManagement
    {
        private List<SanPham> sanPhams;
        private string filePath = "shop.json";

       
   

        private void addSanPham(SanPham sanPham)
        {
            sanPhams.Add(sanPham);
        }

        public int getID()
        {
            return sanPhams.Count + 1;
        }


        public void addDienTu()
        {
            Console.WriteLine("Nhập tên sản phẩm: ");
            string tenSanPham = Console.ReadLine();

            Console.WriteLine("Nhập giá gốc: ");
            double giaGoc = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập thuế bảo hành (%): ");
            double thueBaoHanh = Convert.ToDouble(Console.ReadLine());

            DienTu dienTu = new DienTu(getID(), tenSanPham, giaGoc, thueBaoHanh);
            addSanPham(dienTu);
        }

        public void addThoiTrang()
        {
            Console.WriteLine("Nhập tên sản phẩm: ");
            string tenSanPham = Console.ReadLine();

            Console.WriteLine("Nhập giá gốc: ");
            double giaGoc = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập giảm giá theo mùa (%): ");
            double giamGia = Convert.ToDouble(Console.ReadLine());

            ThoiTrang thoiTrang = new ThoiTrang(getID(), tenSanPham, giaGoc, giamGia);
            addSanPham(thoiTrang);
        }

        public void addThucPham()
        {
            Console.WriteLine("Nhập tên sản phẩm: ");
            string tenSanPham = Console.ReadLine();

            Console.WriteLine("Nhập giá gốc: ");
            double giaGoc = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập phí vận chuyển: ");
            double phiVanChuyen = Convert.ToDouble(Console.ReadLine());

            ThucPham thucPham = new ThucPham(getID(), tenSanPham, giaGoc, phiVanChuyen);
            addSanPham(thucPham);
        }

        public void HienThiDanhSachSanPham()
        {

            foreach (var sanPham in sanPhams)
            {
                sanPham.HienThiThongTin();
                Console.WriteLine("===============================");
            }
        }

        public bool XoaSanPham(int maSanPham)
        {
            SanPham sanPham = sanPhams.Find(p => p.MaSanPham == maSanPham);
            if (sanPham != null)
            {
                sanPhams.Remove(sanPham);
                return true;
            }    
            else
                return false; 
        }

        public double tinhTongDoanhThu()
        {
            double tong = 0;
            foreach (SanPham sanPham in sanPhams)
            {
                tong += sanPham.TinhGiaBan();
            }
            return tong;
        }
    }
}
