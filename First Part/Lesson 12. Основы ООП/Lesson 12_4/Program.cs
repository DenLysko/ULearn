using System.Linq;

namespace Lesson_12_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        public class DirectoryInfoComparer : IEqualityComparer<DirectoryInfo>
        {
            public bool Equals(DirectoryInfo left, DirectoryInfo right) =>
                left.FullName == right.FullName;

            public int GetHashCode(DirectoryInfo di) =>
                di.FullName.GetHashCode();
        }

        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            DirectoryInfoComparer comparer = new();
            HashSet<DirectoryInfo> dirs = new(comparer);

            foreach(var file in files)
            {
                if ((file.Extension == ".mp3" || file.Extension == ".wav")
                    && !(dirs.Contains(file.Directory!)))
                    dirs.Add(file.Directory!);
            }

            return dirs.ToList();
        }
    }
}
