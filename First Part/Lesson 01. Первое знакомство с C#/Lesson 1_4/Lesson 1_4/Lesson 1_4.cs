namespace Lesson_1_4
{
    class Program
    {
        public static int DivideAndRound(double a, double b)
        {
            return (int)Math.Round(a / b);
        }

        /// <summary>
        /// Вычисляет округленое частное аргументов
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <returns>Округленное частное</returns>
        public static int DivideAndRound(int a, int b)
        {
            Console.WriteLine("suda");
            return (int)Math.Round((double)a / b);
        }

        static void Main()
        {
            double a = 5.5;
            double b = 0.8;
            var c = DivideAndRound(a, b);
            Console.WriteLine(c);
            Console.WriteLine(DivideAndRound(2,3));
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(123);
            double b = Math.Ceiling(5.5);
        
        }
    }
}