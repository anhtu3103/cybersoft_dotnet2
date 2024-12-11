using System;
using System.Collections.Generic;

class Fashion : SanPham
{
    private string size { get; set; }
    public string Size
    {
        get { return size; }
        set
        {
            List<string> validSizes = new List<string> { "S", "M", "L", "XL", "XXL" };
            if (string.IsNullOrEmpty(value) || !validSizes.Contains(value))
            {
                throw new ArgumentException("Size must be one of the following: S, M, L, XL, XXL");
            }
        }
    }

    public Fashion(int productId, string productName, double price, string description, string size)
        :base(productId, productName, price, description)
    {
        Size = size;
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Size: {Size}");
    }
}