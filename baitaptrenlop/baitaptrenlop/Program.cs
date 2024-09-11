using System;

class Program
{
    static void Bai1()
    {
        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhập phần tử thứ {0}: ", i + 1);
            arr[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }

        Console.WriteLine("Tổng các phần tử trong mảng là: " + sum);
    }

    static void Bai2()
    {
        Console.Write("Nhập một chuỗi: ");
        string input = Console.ReadLine() ?? string.Empty;

        int count = 0;

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (!char.IsWhiteSpace(c) && !char.IsPunctuation(c))
            {
                count++;
            }
        }

        Console.WriteLine("Số lượng ký tự không bao gồm khoảng trắng và dấu câu là: " + count);
    }

    static void Bai3()
    {
        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhập phần tử thứ {0}: ", i + 1);
            arr[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        int max = arr[0];

        for (int i = 1; i < n; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
            }
        }

        Console.WriteLine("Phần tử lớn nhất trong mảng là: " + max);
    }

    static void Bai4()
    {
        Console.Write("Nhập một chuỗi: ");
        string input = Console.ReadLine() ?? string.Empty;

        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        string reversed = new string(charArray);

        Console.WriteLine("Chuỗi đảo ngược là: " + reversed);
    }

    static void Bai5()
    {
        Console.Write("Nhập số lượng phần tử của mảng: ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhập phần tử thứ {0}: ", i + 1);
            arr[i] = int.Parse(Console.ReadLine() ?? "0");
        }

        bool isPalindrome = true;

        for (int i = 0; i < n / 2; i++)
        {
            if (arr[i] != arr[n - 1 - i])
            {
                isPalindrome = false;
                break;
            }
        }

        if (isPalindrome)
        {
            Console.WriteLine("Mảng là mảng đối xứng.");
        }
        else
        {
            Console.WriteLine("Mảng không phải là mảng đối xứng.");
        }
    }

    static void Bai6()
    {
        Console.Write("Nhập một chuỗi: ");
        string input = Console.ReadLine() ?? string.Empty;

        Console.Write("Nhập ký tự cần đếm: ");
        string charInput = Console.ReadLine() ?? string.Empty;

        if (charInput.Length > 0)
        {
            char charToCount = charInput[0];

            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == charToCount)
                {
                    count++;
                }
            }

            Console.WriteLine($"Ký tự '{charToCount}' xuất hiện {count} lần trong chuỗi.");
        }
        else
        {
            Console.WriteLine("Ký tự nhập vào không hợp lệ.");
        }
    }

    static void Main(string[] args)
    {

        Program.Bai1();  
        Program.Bai2();  
        Program.Bai3();  
        Program.Bai4();  
        Program.Bai5();  
        Program.Bai6();  
    }
}