using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task = Task.Run(() => MainAsync());
            Task.WaitAll(task);

            Console.Read();

            // Main method is the only method that
            // can ’t be marked with async .
            // What we are doing here is just a way for us to simulate
            // async - friendly environment you usually have with
            // other .NET application types ( like web apps , win apps etc .)
            // Ignore main method , you can just focus on
            // LetsSayUserClickedAButtonOnGuiMethod() as a
            // first method in call hierarchy .
            var t = Task.Run(() => LetsSayUserClickedAButtonOnGuiMethod());
            Console.ReadLine();
        }
        private static void LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static int GetTheMagicNumber()
        {
            return IKnowIGuyWhoKnowsAGuy();
        }
        private static int IKnowIGuyWhoKnowsAGuy()
        {
            return IKnowWhoKnowsThis(10) + IKnowWhoKnowsThis(5);
        }
        private static int IKnowWhoKnowsThis(int n)
        {
            return FactorialDigitSum(n).Result;
        }

        private static async void MainAsync()
        {
            Console.WriteLine(await FactorialDigitSum(1));
            Console.WriteLine(await FactorialDigitSum(2));
            Console.WriteLine(await FactorialDigitSum(3));
            Console.WriteLine(await FactorialDigitSum(10));
            Console.WriteLine(await FactorialDigitSum(20));
            Console.WriteLine(await FactorialDigitSum(50));
        }

        public static async Task<int> FactorialDigitSum(int num)
        {
            Task<int> task = Task.Run(() => (GetFactorial(num).ToString().Sum(c => c - '0')));
            await task;
            return task.Result;
        }

        private static long GetFactorial(int num)
        {
            long result = num;
            for (int i = 1; i < num; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}