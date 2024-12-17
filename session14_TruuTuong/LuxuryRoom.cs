class LuxuryRoom : Room
{
    public string extraService { get; set; }

    public LuxuryRoom(int roomID, string roomName, double basePrice, string extraService)
        :base(roomID, roomName, basePrice)
    {
        this.extraService = extraService;    
    }

    public override double calculatePrice()
    {
        return this.BasePrice + 100;
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Extra Service: {extraService}");
    }
}