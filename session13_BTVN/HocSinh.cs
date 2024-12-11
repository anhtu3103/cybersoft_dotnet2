using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session13_BTVN
{
    public class HocSinh
    {
        private int maHocSinh;
        public int MaHocSinh
        {
            get { return maHocSinh; }
            set { maHocSinh = value; }
        }

        private string hoTen;
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        private double toan;
        public double Toan
        {
            get { return toan; }
            set { toan = value; }
        }

        private double van;
        public double Van
        {
            get { return van; }
            set { van = value; }
        }

        private double anh;
        public double Anh
        {
            get { return anh; }
            set { anh = value; }
        }

        private double dtb;
        public double Dtb
        {
            get { return dtb; }
            set { dtb = value; }
        }


        private string xepLoai;
        public string XepLoai
        {
            get { return xepLoai; }
            set { xepLoai = value; }
        }
        public HocSinh(int maHocSinh, string hoTen, double toan, double van, double anh)
        {
            MaHocSinh = maHocSinh;
            HoTen = hoTen;
            Toan = toan;
            Van = van;
            Anh = anh;
        }

        public void tinhDiemTBvaXepLoai()
        {
            Dtb = (Toan + Van + Anh) / 3;
            if (dtb < 0 || dtb > 10)
                xepLoai = "Không phân loại.";
            if (dtb < 5)
                xepLoai = "Yếu";
            else if (5 <= dtb && dtb < 6.5)
                xepLoai = "Trung bình";
            else if (6.5 <= dtb && dtb < 8)
                xepLoai = "Khá";
            else if (8 <= dtb && dtb <= 8)
                xepLoai = "Giỏi";
        }


        public void xuatThongTinHS()
        {
            Console.WriteLine($"Mã học sinh: {maHocSinh}");
            Console.WriteLine($"Tên học sinh:  {hoTen}");
            Console.WriteLine($"Điểm toán {toan}");
            Console.WriteLine($"Điểm văn {van}");
            Console.WriteLine($"Điểm anh {anh}");
            Console.WriteLine("--------------------------------------");
        }

        public void xuatThongTinHSXepLoai()
        {
            Console.WriteLine($"Mã học sinh: {maHocSinh}");
            Console.WriteLine($"Tên học sinh:  {hoTen}");
            Console.WriteLine($"Điểm toán: {toan}");
            Console.WriteLine($"Điểm văn: {van}");
            Console.WriteLine($"Điểm anh: {anh}");
            Console.WriteLine($"Điểm trung bình: {dtb}");
            Console.WriteLine($"Xếp loại: {xepLoai}");
            Console.WriteLine("--------------------------------------");
        }
    }
}
