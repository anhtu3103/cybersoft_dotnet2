class NormalRoom : Room
{
    public NormalRoom(int roomID, string roomName, double basePrice)
        :base(roomID, roomName, basePrice)
    {
        
    }

    public override void displayInfo()
    {
        base.displayInfo();
    }

    public override double calculatePrice()
    {
        return BasePrice;
    }
}