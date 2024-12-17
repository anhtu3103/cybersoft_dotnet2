internal class Program
{
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n=== Product Management Menu ===");
            Console.WriteLine("1. Add electronic");
            Console.WriteLine("2. Add fashion");
            Console.WriteLine("3. Display all product");
            Console.WriteLine("4. Search by name");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Vui lòng chọn chức năng (1-5): ");

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    productManager.addElectronic();
                    break;
                case 2:
                    productManager.addFashion();
                    break;
                case 3:
                   productManager.displayAllProduct();
                    break;
                case 4:
                    Console.WriteLine("Enter name: ");
                    string ten = Console.ReadLine();
                    productManager.searchByName(ten);
                    break;
                case 5:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Vui lòng chọn chức năng từ 1-5");
                    break;
            }
        }
    }
}