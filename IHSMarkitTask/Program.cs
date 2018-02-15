using System;
using System.Diagnostics;

namespace IHSMarkitTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = "";
            string inputMode = "";

            if (args.Length != 0)
            {
                inputMode = args[0];
                dirName = args[1];
            }
            else
            {
                Console.WriteLine("Arguments is empty");
                Process.GetCurrentProcess().Kill();
            }

            if (inputMode == "filesystem")
            {
                FileSystemMode fileSystemMode = new FileSystemMode();
                fileSystemMode.WriteDataToNewFile(dirName);
            }
            else if (inputMode == "http") 
            {
                HttpMode httpMode = new HttpMode();
                httpMode.WriteDataToNewFile(dirName);
            }
            else
            {
                Console.WriteLine("Wrong format:" + inputMode);
            }

            Console.ReadKey();
        }
    }
}
