using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session15_BTVN
{
    abstract class ThanhToan
    {
        private int maThanhToan;
        public int MaThanhToan
        {
            get { return maThanhToan; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Mã thanh toán phải lớn hơn 0");
                }
                maThanhToan = value;
            }
        }
        private string phuongThuc;
        public string PhuongThuc
        {
            get { return phuongThuc; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phương thức phải có giá trị");
                }
                phuongThuc = value;
            }
        }
        private double soTien;
        public double SoTien
        {
            get { return soTien; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số tiền thanh toán phải có giá trị");
                }
                soTien = value;
            }
        }

        protected ThanhToan(int maThanhToan, double soTien)
        {
            MaThanhToan = maThanhToan;
            SoTien = soTien;
        }
        protected ThanhToan(int maThanhToan, string phuongThuc,double soTien)
        {
            MaThanhToan = maThanhToan;
            PhuongThuc = phuongThuc;
            SoTien = soTien;
        }

        public void inThongTin()
        {
            Console.WriteLine($"Mã thanh toán: {maThanhToan}");
            Console.WriteLine($"Phương thức thanh toán: {phuongThuc}");
            Console.WriteLine($"Số tiền: {soTien}");
        }
    }
}
