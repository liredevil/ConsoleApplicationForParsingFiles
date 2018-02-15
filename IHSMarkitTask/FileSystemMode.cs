using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IHSMarkitTask
{
    class FileSystemMode : FileProcessingBase
    {
        ResidentsCounter residentsCounter = new ResidentsCounter();

        public override void WriteDataToNewFile(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                WriteFile(residentsCounter.CountResidentsInCity(ReadFiles(GetFiles(GetAllDirectories(dirName)))));
            }
            else
            {
                Console.WriteLine("Directory does not exist:" + dirName);
            }
        }

        private List<string> GetFiles(List<string> allDirs)
        {
            List<string> pathToAllFiles = new List<string>();

            foreach (string s in allDirs)
            {
                GetListFilesInDirectory(s, pathToAllFiles);
            }

            return pathToAllFiles;
        }

        public override void GetListFilesInDirectory(string dirName, List<string> pathToAllFiles)
        {
            string[] getFilesInDirectory = Directory.GetFiles(dirName);
            
            for (int i = 0; i < getFilesInDirectory.Length; i++)
            {
                pathToAllFiles.Add(getFilesInDirectory[i]);
            }
        }

        private List<string> GetAllDirectories(string dirName)
        {
            List<string> allDirs = new List<string>();
            allDirs.Add(dirName);
            int i = 0;

            while (i < allDirs.Count())
            {
                GetDirectories(allDirs.ElementAt(i), allDirs);
                i++;
            }

            return allDirs;
        }

        private void GetDirectories(string dirName, List<string> allDirs)
        {
            if (Directory.Exists(dirName))
            {
                string[] arrayOfOneDirectory = Directory.GetDirectories(dirName);

                for (int i = 0; i < arrayOfOneDirectory.Length; i++)
                {
                    allDirs.Add(arrayOfOneDirectory[i]);
                }
            }
        }
    }
}
