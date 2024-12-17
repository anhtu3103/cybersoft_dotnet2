using System;
using session13_BTVN;

internal class Program
{
    private static void Main(string[] args)
    {
        Room normalRoom = new NormalRoom(1, " normal 1", 50);
        Room luxuryRoom = new LuxuryRoom(2, " Luxury 1", 100);
        Room normalRoom = new SuiteRoom(3, " Suite 1", 150);


        Console.WriteLine($"Price of normal room: {normalRoom.calculatePrice()}");
        Console.WriteLine($"Price of Luxury room: {LuxuryRoom.calculatePrice()}");
        Console.WriteLine($"Price of Suite room: {normalRoom.SuiteRoom()}");
    }
}