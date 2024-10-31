int a = 9;
int b = 3;
if (a >= b && Math.Pow(b, 2) == a)
{
    int result = (int)Math.Pow(b, 2) + a * 3;
    Console.WriteLine("Kết quả là: " + result);
}
else
{
    Console.WriteLine("Điều kiện không thoả mãn");
}