using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace session13_BTVN
{
    public class HocSinhManager
    {
        public string classId { get; set; }
        public string className { get; set; }
        public List<HocSinh> hocSinhs { get; set; }
        public string filePath = "class.json";

        public HocSinhManager(string classId, string className)
        {
            this.classId = classId;
            this.className = className;
            loadFromFile();
        }

        private void loadFromFile()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                //convert json to list
                hocSinhs = JsonConvert.DeserializeObject<List<HocSinh>>(json);
                Console.WriteLine("Load file thành công");
            }
            else
            {
                hocSinhs = new List<HocSinh>();
                Console.WriteLine("file không tồn tại. Tạo mới danh sách");
            }
        }

        private void saveToFile()
        {
            //convert list to json
            string json = JsonConvert.SerializeObject(hocSinhs, Formatting.Indented);

            //Save file
            File.WriteAllText(filePath, json);
            Console.WriteLine("Lưu file thành công");
        }

        public void addHocSinh(HocSinh hocSinh)
        {
            if (hocSinhs.Any(b => b.MaHocSinh == hocSinh.MaHocSinh))
            {
                Console.WriteLine("Mã học sinh đã tồn tại. Vui lòng nhập mã khác!");
            }
            else
            {
                hocSinhs.Add(hocSinh);
                saveToFile();
                Console.WriteLine("Thêm sách thành công");
            }
        }

        public void addHocSinh()
        {
            Console.WriteLine("Nhập mã học sinh: ");
            int maHocSinh = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhập họ và tên: ");
            string hoTen = Console.ReadLine();

            Console.WriteLine("Nhập điểm toán: ");
            double toan = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập điểm văn: ");
            double van = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Nhập điểm anh: ");
            double anh = Convert.ToDouble(Console.ReadLine());

            HocSinh hocSinh = new HocSinh(maHocSinh, hoTen, toan, van, anh);
            addHocSinh(hocSinh);
        }


        public void displayAllClass()
        {
            Console.WriteLine("====== Lớp học ======");
            if (hocSinhs.Count == 0)
            {
                Console.WriteLine("Không có học sinh nào trong lớp!");
                return;
            }
            foreach (HocSinh hocSinh in hocSinhs)
            {
                hocSinh.xuatThongTinHS();
            }
        }

        public void xuatThongTinHsVaXepLoai()
        {
            Console.WriteLine("====== Lớp học ======");
            if (hocSinhs.Count == 0)
            {
                Console.WriteLine("Không có học sinh nào trong lớp!");
                return;
            }
            foreach (HocSinh hocSinh in hocSinhs)
            {   
                hocSinh.tinhDiemTBvaXepLoai();
                hocSinh.xuatThongTinHSXepLoai();
            }
        }

        public void sapXepHocSinhTheoDTB()
        {
            foreach (HocSinh hocSinh in hocSinhs)
            {
                hocSinh.tinhDiemTBvaXepLoai();
            }
            List<HocSinh> hs = hocSinhs.OrderBy(p => p.Dtb).ToList();
            foreach (HocSinh hocSinh in hs)
            {
                hocSinh.tinhDiemTBvaXepLoai();
                hocSinh.xuatThongTinHSXepLoai();
            }
        }

        public void timKiemTheoTen(string hoTen)
        {
            Console.WriteLine("Ket qua tim kiem: ");
            bool flag = false;
            foreach (HocSinh hocSinh in hocSinhs)
            {
                if (hocSinh.HoTen.ToLower().Contains(hoTen.ToLower()))
                {
                    hocSinh.xuatThongTinHS();
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Không tìm thấy học sinh nào");
            }
        }

        public void capNhatDiemSo(int ma)
        {
            foreach (HocSinh hocSinh in hocSinhs)
            {
                if (hocSinh.MaHocSinh == ma)
                {
                    Console.WriteLine("Nhập điểm toán: ");
                    double toan = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Nhập điểm văn: ");
                    double van = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Nhập điểm anh: ");
                    double anh = Convert.ToDouble(Console.ReadLine());

                    hocSinh.Toan = toan;
                    hocSinh.Van = van;
                    hocSinh.Anh = anh;

                    Console.WriteLine("Chỉnh sửa thành công");
                    saveToFile();
                    return;
                }
            }
            Console.WriteLine("Mã không tồn tại trong danh sách học sinh");
        }


        public void xoaHocSinh(int ma)
        {
            foreach (HocSinh hocSinh in hocSinhs)
            {
                if (hocSinh.MaHocSinh == ma)
                {
                    hocSinhs.Remove(hocSinh);
                    Console.WriteLine("Xóa thành công");
                    saveToFile();
                    return;
                }
            }
            Console.WriteLine("Mã không tồn tại trong danh sách học sinh");
        }

        public void sapXepHocSinhTheoTen()
        {
            List<HocSinh> hs =  hocSinhs.OrderBy(p => p.HoTen.Split(' ').Reverse().ElementAt(0).ToLower()).ToList();
            foreach (HocSinh hocSinh in hs)
            {
                hocSinh.xuatThongTinHS(); 
            }
        }

        
    }
}
