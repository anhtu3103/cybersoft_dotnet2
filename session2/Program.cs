


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

//BT6:
Console.WriteLine(split);
Console.WriteLine("BT6:");
Console.Write("Nhập số dư tài khoản: ");
string balanceAmountStr = Console.ReadLine();
decimal balanceAmount = Convert.ToDecimal(balanceAmountStr);

Console.Write("Nhập số tiền cần rút: ");
string withdrawAmountStr = Console.ReadLine();
decimal withdrawAmount = Convert.ToDecimal(withdrawAmountStr);

decimal remainAmount = balanceAmount - withdrawAmount;
Console.WriteLine($"Số tiền còn lại: {remainAmount} VND");

//BT7:
Console.WriteLine(split);
Console.WriteLine("BT7:");
Console.Write("Nhập quãng đường đã đi (km): ");
string kilometerStr = Console.ReadLine();
decimal kilometer = Convert.ToDecimal(kilometerStr);

Console.Write("Nhập số giờ đã đi (h): ");
string hoursStr = Console.ReadLine();
decimal time = Convert.ToDecimal(hoursStr);

decimal speed = kilometer / time;
Console.WriteLine($"Vận tốc: {speed} km/h");

//BT8:
Console.WriteLine(split);
Console.WriteLine("BT8:");
Console.Write("Nhập một số: ");
string numberStr = Console.ReadLine();
decimal number = Convert.ToDecimal(numberStr);

Console.Write("Nhập một tổng số: ");
string totalNumberStr = Console.ReadLine();
decimal totalNumber = Convert.ToDecimal(totalNumberStr);

decimal percent = number / totalNumber * 100;
Console.WriteLine($"tỉ lệ phần trăm của {number}/{totalNumber} là: {percent}%");

//BT9:
Console.WriteLine(split);
Console.WriteLine("BT9:");
Console.Write("Nhập vận tốc (km/h): ");
string speedKmPerHoursStr = Console.ReadLine();
double speedKmPerHours = Convert.ToDouble(speedKmPerHoursStr);
double speedMeterPerSecond = speedKmPerHours / 3.6;
Console.WriteLine($"{speedKmPerHours} km/h = {speedMeterPerSecond} m/s");

//BT10:
const int runCalories = 10, cyclingCalories = 15, swimmingCalories = 20;

Console.WriteLine(split);
Console.WriteLine("BT10:");
Console.Write("Nhập số phút tập thể dục: ");
string minutesExcerciseStr = Console.ReadLine();
double minutesExcercise = Convert.ToDouble(minutesExcerciseStr);

Console.Write("Nhập hình thức tập thể dục (1: Chạy, 2: Đạp xe, 3: Bơi lội): ");
string ExerciseTypeStr = Console.ReadLine();
int ExerciseType = Convert.ToInt32(ExerciseTypeStr);

double burnColories = 0;
if (ExerciseType == 1)
    burnColories = minutesExcercise * runCalories;
else if (ExerciseType == 2)
    burnColories = minutesExcercise * cyclingCalories;
else if (ExerciseType == 3)
    burnColories = minutesExcercise * swimmingCalories;

Console.WriteLine($"số calo đã tiêu thụ {burnColories}");

#endregion


