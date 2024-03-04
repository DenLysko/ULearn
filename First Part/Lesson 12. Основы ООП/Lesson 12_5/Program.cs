using System.Globalization;

namespace Lesson_12_5;

internal class Program
{
    public class SuperBeautyImageFilter
    {
        public string ImageName;
        public double GaussianParameter;
        public void Run()
        {
            Console.WriteLine("Processing {0} with parameter {1}",
                ImageName,
                GaussianParameter.ToString(CultureInfo.InvariantCulture));
        }
    }
    public static void Main()
    {
        var filter = new SuperBeautyImageFilter();
        filter.ImageName = "Paris.jpg";
        filter.GaussianParameter = 0.4;
        filter.Run();
    }
}
