using System;

class SanPham
{
    private int productId;
    public int ProductId
    {
        get { return productId; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("ID must be greater than 0");
            }
            productId = value;
        }
    }
    private string productName;
    public string ProductName
    {
        get { return productName; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Product name must have value!");
            }
            productName = value;
        }
    }
    private double price;
    public double Price
    {
        get { return price; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("price must be greater or equal than 0");
            }
            price = value;
        }
    }
    private string description;
    public string Description
    {
        get { return description; }
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Product name must have value!");
            }
            description = value;
        }
    }

    public SanPham(int productId, string productName, double price, string description)
    {
        ProductId = productId;
        ProductName = productName;
        Price = price;
        Description = description;
    }

    public virtual void displayInfo() {
        Console.WriteLine($"Product ID: {ProductId}");
        Console.WriteLine($"Product Nam: {ProductName}");
        Console.WriteLine($"Price: {Price}");
        Console.WriteLine($"Description: {Description}");
    }

    
    //exception: 5 loại lỗi
    //1. Lỗi logic
    //2. Lỗi dữ liệu
    //3. Lỗi hệ thống
    //4. Lỗi IO và mạng
    //5. Lỗi luồng và đa nhiệm
}