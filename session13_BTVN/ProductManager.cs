using System;
using Newtonsoft.Json;
class ProductManager
{
    public string Id { get; set; }
    public string productName { get; set; }
    public List<Product> products { get; set; }
    public string filePath = "product.json";

    public ProductManager(string Id, string productName)
    {
        this.Id = Id;
        this.productName = productName;
        loadFromFile();
    }

    private void loadFromFile()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            //convert json to list
            products = JsonConvert.DeserializeObject<List<Product>>(json);
            Console.WriteLine("Load file thành công");
        }
        else
        {
            products = new List<Product>();
            Console.WriteLine("file không tồn tại. Tạo mới danh sách");
        }
    }

    private void saveToFile()
    {
        //convert list to json
        string json = JsonConvert.SerializeObject(products, Formatting.Indented);

        //Save file
        File.WriteAllText(filePath, json);
        Console.WriteLine("Lưu file thành công");
    }

    public void addProduct(Product product)
    {
        if (products.Any(b => b.MaSanPham == product.MaSanPham))
        {
            Console.WriteLine("Mã sản phẩm đã tồn tại. Vui lòng nhập mã khác!");
        }
        else
        {
            products.Add(product);
            saveToFile();
            Console.WriteLine("Thêm sản phẩm thành công");
        }
    }

    public void addProduct()
    {
        Console.WriteLine("Nhập mã sản phẩm: ");
        int maSanPham = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Nhập tên sản phẩm: ");
        string tenSanPham = Console.ReadLine();

        Console.WriteLine("Nhập giá bán: ");
        double giaBan = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nhập số lượng tồn kho: ");
        int soLuongTonKho = Convert.ToInt32(Console.ReadLine());

        Product product = new Product(maSanPham, tenSanPham, giaBan, soLuongTonKho);
        addProduct(product);
    }


    public void displayAllProduct()
    {
        Console.WriteLine("====== Sản phẩm ======");
        if (products.Count == 0)
        {
            Console.WriteLine("Không có sản phẩm nào!");
            return;
        }
        foreach (Product product in products)
        {
            product.xuatThongTinSanPham();
        }
        double tongGiaTri = tinhTongGiaTriKho();
        Console.WriteLine($"Tổng giá trị kho hàng: {tongGiaTri}");
    }

    public void timKiemTheoTen(string tenSanPham)
    {
        Console.WriteLine("Ket qua tim kiem: ");
        bool flag = false;
        foreach (Product product in products)
        {
            if (product.TenSanPham.ToLower().Contains(tenSanPham.ToLower()))
            {
                product.xuatThongTinSanPham();
                flag = true;
            }
        }
        if (!flag)
        {
            Console.WriteLine("Không tìm thấy sản phẩm nào");
        }
    }

    public void capNhatSanPham(int ma)
    {
        foreach (Product product in products)
        {
            if (product.MaSanPham == ma)
            {
                Console.WriteLine("Nhập giá bán: ");
                double giaBan = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Nhập số lượng tồn kho: ");
                int soLuongTonKho = Convert.ToInt32(Console.ReadLine());

                product.GiaBan = giaBan;
                product.SoLuongTonKho = soLuongTonKho;

                Console.WriteLine("Chỉnh sửa thành công");
                saveToFile();
                return;
            }
        }
        Console.WriteLine("Mã không tồn tại trong danh sách");
    }


    public void xoaSanPham(int ma)
    {
        foreach (Product product in products)
        {
            if (product.MaSanPham == ma)
            {
                products.Remove(product);
                Console.WriteLine("Xóa thành công");
                saveToFile();
                return;
            }
        }
        Console.WriteLine("Mã không tồn tại trong danh sách");
    }

    public void hienThiSanPhamTheoTen()
    {
        List<Product> Pro = products.OrderBy(p => p.TenSanPham.Split(' ').Reverse().ElementAt(0).ToLower()).ToList();
        foreach (Product product in Pro)
        {
            product.xuatThongTinSanPham();
        }
    }

    public void sapXepSanPhamTheoTen()
    {
        products.Sort((x, y) => x.TenSanPham.CompareTo(y.TenSanPham));
        saveToFile();
    }


    public void hienThiSanPhamTheoGiaBan()
    {
        List<Product> Pro = products.OrderBy(p => p.GiaBan).ToList();
        foreach (Product product in Pro)
        {
            product.xuatThongTinSanPham();
        }
    }
    public void sapXepSanPhamTheoGiaBan()
    {
        products.Sort((x, y) => x.GiaBan.CompareTo(y.GiaBan));
        saveToFile();
    }

    public double tinhTongGiaTriKho()
    {
        double tong = 0;
        foreach (Product product in products)
        {
            tong += product.GiaBan * product.SoLuongTonKho;
        }
        return tong;
    }
}