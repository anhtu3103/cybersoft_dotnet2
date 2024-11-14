
using System;
using System.Collections.Generic;
using System.Linq;




//Bài 2

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Bài 1");
        int result1 = Bai1();
        Console.WriteLine($"{result1}");
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine($"Bài 2");
        Console.Write("Nhập target: ");
        string input2 = Console.ReadLine();
        int formatInput2 = Convert.ToInt32(input2);
        Bai2(formatInput2);
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine($"Bài 3");
        Bai3();
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine($"Bài 4");
        Console.Write("Nhập k: ");
        string input4 = Console.ReadLine();
        int formatInput4 = Convert.ToInt32(input4);
        Bai4(formatInput4);
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine($"Bài 5");
        Bai5();
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine($"Bài Extra 1:");
        BaiExtra1();
        Console.WriteLine("-----------------------------------------------");

        Console.WriteLine($"Bài Extra 2:");
        BaiExtra2();
        Console.WriteLine("-----------------------------------------------");
        
    }

    #region Bài tập chính
    //Bài 1
    private static int Bai1()
    {

        int[] lstNumber = new int[12] { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };
        int total = 0;
        for (int i = 0; i < lstNumber.Length; i++)
        {
            total += lstNumber[i];
        }
        return total;
    }

    private static void Bai2(int inputNumber)
    {
        List<int> lstNumber = new List<int> { 2, 7, 11, 15 };
        for (int i = 0; i < lstNumber.Count; i++)
        {
            for (int j = i + 1; j < lstNumber.Count; j++)
            {
                if (lstNumber[i] + lstNumber[j] == inputNumber)
                {
                    Console.WriteLine($"[{i}, {j}]");
                    return;
                }
            }
        }
        Console.WriteLine("Cannot find result in list");
        return;
    }
    private static void Bai3()
    {
        List<int> lstNumber = new List<int> { 1, 1, 2, 2, 2, 3, 4, 4, 5 };
        List<int> result = new List<int>();
        for (int i = 0; i < lstNumber.Count; i++)
        {
            if (!result.Contains(lstNumber[i]))
                result.Add(lstNumber[i]);
        }
        string resultStr = result.Count + " (Mảng mới là: [";
        for (int i = 0; i < result.Count; i++)
        {
            if (i == 0)
                resultStr += result[i].ToString();
            else
                resultStr += ", " + result[i].ToString();
        }
        resultStr += "])";
        Console.WriteLine(resultStr);
    }
    private static void Bai4(int k)
    {
        List<int> lstNumber = new List<int> { 1, 1, 1, 2, 2, 3 };
        Dictionary<int, int> countNumber = new Dictionary<int, int>();
        for (int i = 0; i < lstNumber.Count; i++)
        {
            if (!countNumber.ContainsKey(lstNumber[i]))
            {
                countNumber.Add(lstNumber[i], 0);
                for (int j = 0; j < lstNumber.Count; j++)
                {
                    if (lstNumber[j] == lstNumber[i])
                        countNumber[lstNumber[i]] += 1;
                }
            }

        }
        List<int> result = new List<int>();
        if (k > countNumber.Count)
            k = countNumber.Count;
        for (int i = 1; i <= k; i++)
        {
            KeyValuePair<int, int> firstItem = countNumber.First();
            int maxValue = firstItem.Value;
            int key = firstItem.Key;
            foreach (KeyValuePair<int, int> item in countNumber)
            {
                if (item.Value > maxValue)
                {
                    maxValue = item.Value;
                    key = item.Key;
                }
            }

            result.Add(key);
            countNumber.Remove(key);
        }
        string strResult = "";
        foreach (int item in result)
        {
            if (strResult == "")
                strResult = "[" + item;
            else
                strResult += ", " + item;
        }
        strResult += "]";
        Console.WriteLine(strResult);
    }

    private static void Bai5()
    {
        List<int> lstNumber = new List<int> { 7, 1, 5, 3, 6, 4 };
        Dictionary<int, int> countNumber = new Dictionary<int, int>();
        if (lstNumber.Count < 2)
            return;
        int maxProfit = 0;
        for (int i = 0; i < lstNumber.Count; i++)
        {
            for (int j = i + 1; j < lstNumber.Count; j++)
            {
                if (lstNumber[j] - lstNumber[i] > maxProfit)
                    maxProfit = lstNumber[j] - lstNumber[i];
            }
        }
        Console.WriteLine($"{maxProfit}");
    }
    #endregion

    #region Bài tập extra
    private static void BaiExtra1()
    {
        List<int> lstNumber = new List<int> { 20, 81, 97, 63, 72, 11, 20, 15, 33, 15, 41, 20 };
        List<int> lstNumberLessThan50 = new List<int>();
        int total = 0, totalLessThan40 = 0;
        int count = 0, countOdd = 0, countEven = 0, count15 = 0, countDivisible5 = 0;
        int max = lstNumber[0];
        float totalOfOdd = 0, averageOfOdd = 0, totalOfEven = 0, averageOfEven = 0;
        int idxOfTwenty = -1;
        for (int i = 0; i < lstNumber.Count; i++)
        {
            if (lstNumber[i] > 50)
                total += lstNumber[i];
            if (lstNumber[i] < 40)
                totalLessThan40 += lstNumber[i];
            if (lstNumber[i] > 30)
                count += 1;
            if (lstNumber[i] == 15)
                count15 += 1;
            if (lstNumber[i] % 5 == 0)
                countDivisible5 += 1;
            if (lstNumber[i] > max)
                max = lstNumber[i];
            if (lstNumber[i] % 2 != 0)
            {
                countOdd += 1;
                totalOfOdd += lstNumber[i];
            }
            if (lstNumber[i] % 2 == 0)
            {
                countEven += 1;
                totalOfEven += lstNumber[i];
            }
            if (idxOfTwenty == -1 && lstNumber[i] == 20)
                idxOfTwenty = i;
            if (lstNumber[i] < 50)
                lstNumberLessThan50.Add(lstNumber[i]);
        }
        averageOfOdd = totalOfOdd / countOdd;
        averageOfEven = totalOfEven / countEven;

        Console.WriteLine($"1. Tổng các số lớn hơn 50 trong danh sách: {total}");
        Console.WriteLine($"2. Số phần tử lớn hơn 30 là: {count}");
        Console.WriteLine($"3. Số lớn nhất trong mảng là: {max}");
        Console.WriteLine($"4. Trung bình số lẻ: {averageOfOdd}");
        Console.WriteLine($"5. Trung bình số chẵn: {averageOfEven}");
        Console.WriteLine($"6. Chỉ số đầu tiên của số 20 trong danh sách : {idxOfTwenty}");
        Console.WriteLine($"7. Số phần tử = 15: {count15}");
        Console.WriteLine($"8. Tổng các số nhỏ hơn 40 trong danh sách: {totalLessThan40}");
        Console.WriteLine($"9. Số phần tử chia hết cho 5 là: {countDivisible5}");

        string resultStr = "[";
        for (int i = 0; i < lstNumberLessThan50.Count; i++)
        {
            if (i == 0)
                resultStr += lstNumberLessThan50[i].ToString();
            else
                resultStr += ", " + lstNumberLessThan50[i].ToString();
        }
        resultStr += "])";
        Console.WriteLine($"10. Danh sách các số nhỏ hơn 50: {resultStr}");
    }

    private static void BaiExtra2()
    {
        List<string> lstStrings = new List<string> { "apple", "banana", "orange", "kiwi", "mango", "pineapple", "grape", "melon" };
        lstStrings.Sort();
        string result2Str = "", result5Str = "", result6Str = "", result8Str = "", result9Str = "", result10Str = "";
        int maxLength = lstStrings[0].Count();
        int idxMaxLength = 0;
        int countLengthLessThan6 = 0;
        for (int i = 0; i < lstStrings.Count; i++)
        {
            if (lstStrings[i].Count() > 5)
            {
                if (result2Str == "")
                    result2Str += lstStrings[i];
                else
                    result2Str += ", " + lstStrings[i];
            }

            if (lstStrings[i].Count() > maxLength)
            {
                maxLength = lstStrings[i].Count();
                idxMaxLength = i;
            }
            if (lstStrings[i].Contains("a"))
            {
                if (result5Str == "")
                    result5Str += lstStrings[i];
                else
                    result5Str += ", " + lstStrings[i];
            }
            if (lstStrings[i].StartsWith("m"))
            {
                if (result6Str == "")
                    result6Str += lstStrings[i];
                else
                    result6Str += ", " + lstStrings[i];
            }
            if (lstStrings[i].Count() < 6)
                countLengthLessThan6 += 1;
            if (result8Str == "")
                result8Str += lstStrings[i];
            else
                result8Str += ", " + lstStrings[i];
                
            if (result9Str == "")
                result9Str += lstStrings[i].ToUpper();
            else
                result9Str += ", " + lstStrings[i].ToUpper();
            if (result10Str == "")
                result10Str += lstStrings[i].Replace("banana", "pear");
            else
                result10Str += ", " + lstStrings[i].Replace("banana", "pear");
        }

        int SecondLength = 0, idxSecondLenth = 0;
        for (int i = 0; i < lstStrings.Count; i++)
        {
            if (i != idxMaxLength)
            {
                if (SecondLength < maxLength && SecondLength < lstStrings[i].Count())
                {
                    SecondLength = lstStrings[i].Count();
                    idxSecondLenth = i;
                }
            }
        }

        Console.WriteLine($"1. Số phần tử trong mảng: {lstStrings.Count}");
        Console.WriteLine($"2. Chuỗi có độ dài lớn hơn 5 kí tự: {result2Str}");
        Console.WriteLine($"3. Chuỗi có độ dài lớn nhất: {lstStrings[idxMaxLength]}");
        Console.WriteLine($"4. Chuỗi có chứa chữ a: {result5Str}");
        Console.WriteLine($"5. Chuỗi bắt đầu bằng chữ m: {result6Str}");
        Console.WriteLine($"6. Số chuỗi có độ dài bé hơn 6: {countLengthLessThan6}");
        Console.WriteLine($"7. Chuỗi có độ dài lớn thứ 2: {lstStrings[idxSecondLenth]}");
        Console.WriteLine($"8. Chuỗi kí tự đã sắp xếp: {result8Str}");
        Console.WriteLine($"9. Chuỗi kí tự in hoa: {result9Str}");
        Console.WriteLine($"10. Thay thế chuỗi banana bằng chuỗi pear : {result10Str}");
    }
    #endregion
}
