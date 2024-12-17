class SuiteRoom : Room
{
    public string extraService { get; set; }
    public string premiumService { get; set; }

    public SuiteRoom(int roomID, string roomName, double basePrice, string extraService, string premiumService)
        :base(roomID, roomName, basePrice)
    {
        this.extraService = extraService;  
        this.premiumService = premiumService;  
    }

    public override double calculatePrice()
    {
        return this.BasePrice + 200;
    }

    public override void displayInfo()
    {
        base.displayInfo();
        Console.WriteLine($"Extra Service: {extraService}");
        Console.WriteLine($"Premium Service: {premiumService}");
    }
}