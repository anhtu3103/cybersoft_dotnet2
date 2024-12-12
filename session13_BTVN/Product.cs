class Product
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

    private double giaBan;
    public double GiaBan
    {
        get { return giaBan; }
        set { giaBan = value; }
    }

    private int soLuongTonKho;
    public int SoLuongTonKho
    {
        get { return soLuongTonKho; }
        set { soLuongTonKho = value; }
    }

    public Product(int maSanPham, string tenSanPham, double giaBan, int soLuongTonKho)
    {
        MaSanPham = maSanPham;
        TenSanPham = tenSanPham;
        GiaBan = giaBan;
        SoLuongTonKho = soLuongTonKho;
    }

    public void xuatThongTinSanPham()
    {
        Console.WriteLine($"Mã sản phẩm: {maSanPham}");
        Console.WriteLine($"Tên sản phẩm:  {tenSanPham}");
        Console.WriteLine($"Giá bán: {giaBan}");
        Console.WriteLine($"Số lượng tồn kho: {soLuongTonKho}");
        Console.WriteLine("--------------------------------------");
    }
}