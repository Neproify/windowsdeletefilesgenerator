using System;

namespace windowsdeletefilesgenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            string fileName = "";
            string outputPath = "";
            string output = "";

            Console.WriteLine("Hello to windows delete files bat generator.");
            Console.WriteLine("Type path to the folder here:");
            path = Console.ReadLine();
            Console.WriteLine("Type name of generated bat file:");
            fileName = Console.ReadLine();

            output += "@echo off\n";

            string[] directories;
            directories = System.IO.Directory.GetDirectories(path);

            string[] files;
            files = System.IO.Directory.GetFiles(path);

            foreach(var directory in directories)
            {
                output += "RMDIR /Q /S " + directory.Replace(path + "\\", "") + "\n";
            }

            foreach(var file in files)
            {
                output += "DEL /Q /S " + file.Replace(path + "\\", "") + "\n";
            }

            outputPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\" + fileName;
            System.IO.File.WriteAllText(outputPath, output);

            Console.WriteLine("Done, press anything to end.");
            Console.ReadKey();
        }
    }

}
