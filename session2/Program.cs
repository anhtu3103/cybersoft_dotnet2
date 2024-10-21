


#region BTVN 

string split = "--------------------------------------------------\n";

// //BT1: 
const int DayOfWeek = 7;
Console.WriteLine("BT1:");
Console.Write("Nhập số ngày bạn muốn tính: ");
string inputDay = Console.ReadLine();
int formatInputDay = Convert.ToInt32(inputDay);
int week = formatInputDay / 7;
int days = formatInputDay % DayOfWeek;
Console.WriteLine($"{week} tuần, {days} ngày");

// //BT2:
Console.WriteLine(split);
Console.WriteLine("BT2:");
Console.Write("Nhập giá trị của đơn hàng: ");
string priceStr = Console.ReadLine();
decimal price = Convert.ToDecimal(priceStr);

Console.Write("Nhập phần trăm giảm giá: ");
string discountStr = Console.ReadLine();
decimal discount = Convert.ToDecimal(discountStr);

decimal totalAmount = price - (price * discount / 100);
Console.WriteLine($"Tổng tiền cần phải trả là: {totalAmount}");

//BT3:
Console.WriteLine(split);
Console.WriteLine("BT3:");
const int minutesPerHour = 60;
Console.Write("Nhập số phút bạn muốn tính: ");
string inputMinutes = Console.ReadLine();
int minutes = Convert.ToInt32(inputMinutes);
int hours = minutes / minutesPerHour;
minutes -= hours * minutesPerHour;
Console.WriteLine($"{hours} giờ và {minutes} phút");

//BT4:
Console.WriteLine(split);
Console.WriteLine("BT4:");
Console.Write("Nhập số tiền gốc: ");
string amountStr = Console.ReadLine();
decimal amount = Convert.ToDecimal(amountStr);

Console.Write("Nhập phần trăm thuế VAT: ");
string VATstr = Console.ReadLine();
decimal VAT = Convert.ToDecimal(VATstr);

decimal totalAmountInclVAT = amount + (amount * VAT / 100);
Console.WriteLine($"Tổng tiền sau khi cộng thuế: {totalAmountInclVAT}");

//BT5:
Console.WriteLine(split);
Console.WriteLine("BT5:");
Console.Write("Nhập số tiền USD cần đổi: ");
string USDamountStr = Console.ReadLine();
decimal USDamount = Convert.ToDecimal(USDamountStr);

Console.Write("Nhập tỷ giá chuyển đổi: ");
string exchangeRateStr = Console.ReadLine();
decimal exchangeRate = Convert.ToDecimal(exchangeRateStr);

decimal exchangeAmount = exchangeRate * USDamount;
Console.WriteLine($"Số tiền sau khi chuyển đổi: {exchangeAmount} VND");

#endregion


