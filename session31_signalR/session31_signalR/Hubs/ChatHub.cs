using Microsoft.AspNetCore.SignalR;

public class ChatHub: Hub
{
    //Server nhận event từ client
    public async Task SendPrivateMessage(string user, string message)
    {
        //gửi event đến client
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendGroupMessage(string roomKey, string user, string message)
    {
        Console.WriteLine("SendGroupMessage");
        //send event to client in group
        await Clients.Group(roomKey).SendAsync("ReceiveMessageGroup", roomKey, user, message);
    }

    public async Task JoinGroup(string room, string user)
    {
        Console.WriteLine("JoinGroup");
        await Groups.AddToGroupAsync(Context.ConnectionId, room);
        //send notification user A joined group
        await Clients.Group(room).SendAsync("ReceiveMessageGroup", room, "System", $"{user} joined {room}");
    }

    //Leave group
    public async Task LeaveGroup(string room, string user)
    {
        Console.WriteLine("LeaveGroup");
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, room);
        await Clients.Group(room).SendAsync("ReceiveMessageGroup", room, "System", $"{user} has left {room}");
    }
}