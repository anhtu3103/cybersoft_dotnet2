using Newtonsoft.Json;
using System;

namespace session15_BTVN
{
    class ThanhToanManager
    {
        private List<ThanhToan> thanhToans;
        private string filePath = "thanhtoan.json";

        public ThanhToanManager()
        {
            loadData();
        }
        public void loadData()
        {
            if (!File.Exists(filePath))
            {
                thanhToans = new List<ThanhToan>();
            }
            else
            {
                string json = File.ReadAllText(filePath);
                thanhToans = JsonConvert.DeserializeObject<List<ThanhToan>>(json);
            }
        }

        public void saveData()
        {
            //convert list to json
            string json = JsonConvert.SerializeObject(thanhToans, Formatting.Indented);

            //Save file
            File.WriteAllText(filePath, json);
            Console.WriteLine("Lưu file thành công");
        }

        private void addThanhToan(ThanhToan thanhToan)
        {
            thanhToans.Add(thanhToan);
            saveData();
        }

        public int getID()
        {
            return thanhToans.Count + 1;
        }

        public double nhapSoTien()
        {
            double soTien = 0;
            try
            {
                while (true)
                {
                    Console.WriteLine("Nhập số tiền cần thanh toán");
                    soTien = Convert.ToDouble(Console.ReadLine());
                    if (soTien <= 0)
                    {
                        Console.WriteLine("Số tiền phải lớn hơn không. Mời nhập lại");
                    }
                    else
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Số tiền không hợp lệ");
            }
            return soTien;
        }


        public void addThanhToanTienMat()
        {
            double soTien = nhapSoTien();
            ThanhToanTienMat thanhToan = new ThanhToanTienMat(getID(), soTien);
            if (thanhToan.ThanhToan(soTien) > 0)
                addThanhToan(thanhToan);
        }

        public void addThanhToanThe()
        {
            double soTien = nhapSoTien();
            ThanhToanBangThe thanhToan = new ThanhToanBangThe(getID(), soTien);
            if (thanhToan.ThanhToan(soTien) > 0)
                addThanhToan(thanhToan);
        }

        public void addThanhToanOnline()
        {
            double soTien = nhapSoTien();
            ThanhToanOnline thanhToan = new ThanhToanOnline(getID(), soTien);
            if (thanhToan.ThanhToan(soTien) > 0)
                addThanhToan(thanhToan);
        }

        public void inLichSuThanhToan()
        {

            foreach (var thanhToan in thanhToans)
            {
                thanhToan.inThongTin();
                Console.WriteLine("===============================");
            }
        }
    }
}
