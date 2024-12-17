
using System;
using Newtonsoft.Json;
using static System.Reflection.Metadata.BlobBuilder;

class ProductManager
{
    private List<SanPham> products;
    private string filePath = "product.json";

    public ProductManager()
    {
        loadData();
    }
    public void loadData()
    {
        if(!File.Exists(filePath)) {
            products = new List<SanPham>();
        }
        else
        {
            string json = File.ReadAllText(filePath);
            products = JsonConvert.DeserializeObject<List<SanPham>>(json);
        }
    }

    public void saveData()
    {
        //convert list to json
        string json = JsonConvert.SerializeObject(products, Formatting.Indented);

        //Save file
        File.WriteAllText(filePath, json);
        Console.WriteLine("Lưu file thành công");
    }

    public void addProduct(SanPham sanpham)
    {
        products.Add(sanpham);
        saveData();
    }

    public void addElectronic()
    {
        Console.WriteLine("Enter product ID: ");
        int productId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter product Name: ");
        string productName = Console.ReadLine();

        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter warranty: ");
        int warranty = Convert.ToInt32(Console.ReadLine());

        Electronics electronics = new Electronics(productId, productName, price, description, warranty);
        addProduct(electronics);
    }

    public void addFashion()
    {
        Console.WriteLine("Enter product ID: ");
        int productId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter product Name: ");
        string productName = Console.ReadLine();

        Console.WriteLine("Enter description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Enter price: ");
        double price = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter size: ");
        string size =Console.ReadLine();

        Fashion fashion = new Fashion(productId, productName, price, description, size);
        addProduct(fashion);
    }

    public void displayAllProduct()
    {
        products.Sort((p1, p2) => p2.Price.CompareTo(p1.Price));
        foreach (var product in products) 
        {
            product.displayInfo();
            Console.WriteLine("===============================");
        }
    }

    public void searchByName(string name)
    {
        SanPham? product = products.Find(p => p.ProductName.ToLower().Contains(name.ToLower()));
        if (product == null)
        {
            Console.WriteLine("Product not found!");
        }
        else
        {
            product.displayInfo();
        }
    }
}