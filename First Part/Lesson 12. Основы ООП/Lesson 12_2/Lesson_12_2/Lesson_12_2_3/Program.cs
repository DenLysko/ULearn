using System;

namespace Lesson_12_2_3
{
    public class Program
    {
        static void Main()
        {
			var directoryInfo = new DirectoryInfo(".");
			var fileInfo = new List<FileInfo>();
			

			foreach (var file in directoryInfo.GetFiles())
            {
				fileInfo.Add(file);
                Console.WriteLine(file);
                Console.WriteLine(file.GetType());
            }
			foreach(var file in fileInfo)
            {
                Console.WriteLine(file.Name);
            }
            Console.WriteLine();
			var result = GetAlbums(fileInfo);
            foreach (var album in result)
            {
                Console.WriteLine(album.ToString());
            }

        }

        public static List<DirectoryInfo> GetAlbums(List<FileInfo> files)
        {
            var directoryList = new List<DirectoryInfo>();
            var dictionary = new Dictionary<string, DirectoryInfo>();
            foreach (var file in files)
            {
                var str = file.Name;
                var length = str.Length;
                var substr = str.Substring(length - 4);
                if (substr == ".mp3" || substr == ".wav")
                    if (!dictionary.ContainsKey(file.Directory.ToString()))
                        dictionary[file.Directory.ToString()] = file.Directory;
            }
            foreach (var element in dictionary)
            {
                directoryList.Add(element.Value);
            }



            return directoryList;
        }
    }
}