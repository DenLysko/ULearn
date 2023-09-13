using System;

namespace Lysko_Denis_Amicable_Numbers
{
    public class Program
    {
        public static void Main()
        {
            var ceiling = CheckInput();
            var start = DateTime.Now;

            var numberAndSumOfItsDivisors = new Dictionary<int, int>();

            // Auxiliary array for FillingInDictionary
            var arrayOfPrimeNumbersUntilSqrt = GetArrayOfPrimeNumbers((int)Math.Sqrt(ceiling) + 1);

            // The longest process
            numberAndSumOfItsDivisors = FillingInDictionary(ceiling, arrayOfPrimeNumbersUntilSqrt);

            var forOutput = CheckAmicableNumbers(ceiling, numberAndSumOfItsDivisors);

            PrintOutput(forOutput);
            Console.WriteLine(DateTime.Now - start);
        }

        public static int CheckInput()
        {
            var check = int.TryParse(Console.ReadLine(), out int number);
            if (!check)
            {
                Console.WriteLine("Input is not correct");
                return -1;
            }
            return number;
        }

        public static Dictionary<int, int> FillingInDictionary(int ceiling, int[] arrayOfPrimeNumbersUntilSqrt)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 1; i < ceiling + 1; i++)
                dic[i] = SumOfDivisors(i, arrayOfPrimeNumbersUntilSqrt);
            return dic;
        }

        public static int SumOfDivisors(int i, int[] arrayOfPrimeNumbersUntilSqrt)
        {
            int sum = 1;
            foreach (var auxiliaryNumber in arrayOfPrimeNumbersUntilSqrt)
            {
                if (i % auxiliaryNumber == 0)
                {
                    sum = SumOfDivisorsWithAuxiliaryNumber(i, auxiliaryNumber);
                    return sum;
                }
            }
            return sum;
        }

        public static int SumOfDivisorsWithAuxiliaryNumber(int i, int auxiliaryNumber)
        {
            int sum = 1;
            int partOfNumber = i / auxiliaryNumber + 1;
            for (int j = 2; j < partOfNumber + 1; j++)
            {
                if (i % j == 0)
                    sum += j;
            }
            return sum;
        }

        public static int[] GetArrayOfPrimeNumbers(int sqrt)
        {
            var listOfPrimeNumbers = new List<int>();
            for (int j = 2; j < sqrt; j++)
            {
                if (CheckPrime(j))
                    listOfPrimeNumbers.Add(j);
            }
            return listOfPrimeNumbers.ToArray();
        }

        public static bool CheckPrime(int numberForCheck)
        {
            var localCeiling = (int)Math.Sqrt(numberForCheck) + 1;
            for (int i = 2; i < localCeiling; i++)
            {
                if (numberForCheck % i == 0)
                    return false;
            }
            return true;
        }

        public static Dictionary<int, int> CheckAmicableNumbers(int ceiling, Dictionary<int, int> numberAndSumOfItsDivisors)
        {
            var forOutput = new Dictionary<int, int>();
            for (int i = 2; i < ceiling + 1; i++)
            {
                if (numberAndSumOfItsDivisors[i] >= ceiling || numberAndSumOfItsDivisors[i] == 1)
                    continue;
                var j = numberAndSumOfItsDivisors[i];
                if (numberAndSumOfItsDivisors[i] == j && numberAndSumOfItsDivisors[j] == i)
                {
                    if (j < i)
                    {
                        if (i != j)
                        {
                            forOutput[Math.Min(i, j)] = Math.Max(i, j);
                        }
                    }
                }
            }
            return forOutput;

        }

        public static void PrintOutput(Dictionary<int, int> forOutput)
        {
            foreach (var key in forOutput.Keys.OrderBy(x => x))
            {
                Console.WriteLine("{0}  {1}", key, forOutput[key]);
            }
        }
    }
}