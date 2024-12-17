using System;

abstract class NhanVien 
{
    private string maNV;
    public string MaNV 
    {
        get { return maNV;}
        set { maNV = value;}
    }

    private string hoTen;
    public string HoTen 
    {
        get { return hoTen;}
        set { hoTen = value;}
    }

    private double luongCoBan;
    public double LuongCoBan 
    {
        get { return luongCoBan;}
        set { luongCoBan = value;}
    }

    public NhanVien(string maNV, string hoTen, double luongCoBan)
    {
        MaNV = maNV;
        HoTen = hoTen;
        LuongCoBan = luongCoBan;
    }


    public virtual double chamCong()
    {
        Console.WriteLine("ChamCong");
    }

    public abstract double tinhLuong();
}