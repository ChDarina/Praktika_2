using System;
using System.IO;
using System.Text;

namespace praktika_2
{
    class Program
    {
        static public int InputNumber(StreamReader reader, int left, int right)
        {
            int num = 0;
            try
            {
                num = Convert.ToInt32(reader.ReadLine());
                if (num >= left && num <= right) return num;
                else
                {
                    Console.WriteLine("В строке должно быть число от {0} до {1}!", left, right);
                }
            }
            catch
            {
                Console.WriteLine("Неверный ввод числа!");
            }
            return -1;
        }
        static void Main(string[] args)
        {
            string input_f = "INPUT.TXT", output_f = "OUTPUT.TXT";
            int num=0;
            using (FileStream sf = new FileStream(input_f, FileMode.OpenOrCreate)) { }
            using (StreamReader reader = new StreamReader(input_f, Encoding.Default))
            {
                if (reader.Peek() == -1)
                {
                    Console.WriteLine("Файл пуст");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.WriteLine("INPUT.TXT\n");
                try
                {
                    num = InputNumber(reader, 1, 2*(int)Math.Pow(10,9));
                }
                catch
                {
                    Console.WriteLine("\n\nФайл заполнен неверно. В строке должно быть одно число");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                if (num == -1)
                {
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            Console.WriteLine(num);
            int razryad = (int)Math.Log10(num) + 1;
            int[] arr = new int[razryad];
            for (int i = 1; i < razryad+1; i++)
                arr[i-1] = (num % (int)Math.Pow(10, i))/(int)Math.Pow(10, i-1);
            Array.Sort(arr);
            int min=0, max=0;
            for (int i = 0; i < razryad; i++)
            {
                max += arr[i] * (int)Math.Pow(10, i);
            }
            int change=0;
            while (arr[change] == 0) change++;
            if (change != 0)
            {
                arr[0] = arr[change];
                arr[change] = 0;
            }
            for (int i = 1; i < razryad + 1; i++)
            {
                min += arr[i - 1] * (int)Math.Pow(10, razryad - i);
            }
            using (FileStream sf = new FileStream(output_f, FileMode.OpenOrCreate)) { }
            using (StreamWriter writer = new StreamWriter(output_f))
            {
                writer.Write(min + ", " + max);
            }
            Console.WriteLine("\nOUTPUT.TXT\n\n" + min + ", " + max);
            Console.ReadKey();
        }
    }
}
