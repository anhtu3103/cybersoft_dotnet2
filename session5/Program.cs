using System;

internal class Program
{
    private static void Main(string[] args)
    {
        // int result = tinhTong(5, 10);
        // Console.WriteLine($"Tổng 2 số là {result}");
        // Console.WriteLine("Hello World!");
        string result = calculate(10, 10, 10);
        Console.WriteLine($"{result}");
    }

    private static int tinhTong(int a, int b)
    {
        return a + b;
    }

    private static string calculate(int toan, int ly, int hoa)
    {
        //your code here
        double DTB = (Convert.ToDouble(toan) + ly + hoa) / 3;

        if (DTB < 0 || DTB > 10)
            return "Not graded.";
        if (DTB < 5)
            return "Grade: Poor";
        else if (5 <= DTB && DTB <= 6.5)
            return "Grade: Average";
        else if (5 <= DTB && DTB < 6.5)
            return "Grade: Average";
        else if (6.5 <= DTB && DTB < 8)
            return "Grade: Good";
        else if (8 <= DTB && DTB <= 8)
            return "Grade: Excellent";

        return "";
    }

}