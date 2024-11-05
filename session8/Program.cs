
using System;

int[] IstNumber = new int[12]{20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20};
int total = 0;
for(int i = 0; i < IstNumber.Length; i++) 
{
    total += IstNumber[i];
}
Console.WriteLine($"{total}");
