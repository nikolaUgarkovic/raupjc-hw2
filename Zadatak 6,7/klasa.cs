using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_6_7
{
    public class klasa
    {
        public static async Task LetsSayUserClickedAButtonOnGuiMethod()
        {
            var result = await GetTheMagicNumber();
            Console.WriteLine(result);
        }
        private static async Task<int> GetTheMagicNumber()
        {
            return await IKnowIGuyWhoKnowsAGuy();
        }
        private static async Task<int> IKnowIGuyWhoKnowsAGuy()
        {
            return await IKnowWhoKnowsThis(10) + await IKnowWhoKnowsThis(5);
        }
        private static async Task<int> IKnowWhoKnowsThis(int n)
        {
            return  FactorialDigitSum(n).Result;
        }

        private static async Task<int> FactorialDigitSum(int n)
        {
            int result = await Task.Run(() =>
            {
                int factorial = 1;
                for (int i = n; i > 1; i--)
                {
                    factorial *= i;
                }
                int sum = 0;
                while (factorial != 0)
                {
                    sum += factorial % 10;
                    factorial /= 10;
                }
                return sum;
            });

            return result;
        }
    }
}
