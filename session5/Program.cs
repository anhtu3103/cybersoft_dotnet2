internal class Program
{
    private static void Main(string[] args)
    {
        int result = tinhTong(5, 10);
        Console.WriteLine($"Tổng 2 số là {result}");
    }

    private static int tinhTong(int a, int b)
    {
        return a + b;
    }
}