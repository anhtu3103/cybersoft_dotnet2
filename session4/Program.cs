Console.Write("Nhập số: ");
string number = Console.ReadLine();
int formatNumber = Convert.ToInt32(number);
int count = 1;
while(count <= formatNumber)
{
    Console.WriteLine(count);
    count++;
}


