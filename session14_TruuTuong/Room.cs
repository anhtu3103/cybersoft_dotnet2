abstract class Room
{
    private int roomID;
    public int RoomID
    {
        get { return roomId;}
        set 
        {
            if (value <= 0)
            {
                throw ArgumentException("Room ID must greater than 0");
            }
            roomID = value;
        }
    }

    private string roomName;
    public string RoomName
    {
        get { return RoomName;}
        set 
        {
            if (string.IsNullOrEmpty(value))
            {
                throw ArgumentException("Room name must have value");
            }
            RoomName = value;
        }
    }

    private double basePrice;
    public string BasePrice
    {
        get { return basePrice;}
        set 
        {
            if (value <= 0)
            {
                throw ArgumentException("Base price must greater than 0");
            }
            basePrice = value;
        }
    }

    public Room(int roomID, string roomName, double basePrice)
    {
        RoomID = roomID;
        RoomName = roomName;
        BasePrice = basePrice;
    }

    public virtual void displayInfo()
    {
        Console.WriteLine($"Room ID: {roomID}");
        Console.WriteLine($"Room Name:  {roomName}");
        Console.WriteLine($"Base price: {basePrice}");
        Console.WriteLine("--------------------------------------");
    }

    public abstract double calculatePrice();
}