using IHSMarkitTask.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IHSMarkitTask.Model;
using System.IO;
using System.Diagnostics;

namespace IHSMarkitTask
{
    abstract class FileProcessingBase : IFileProcessing
    {
        public List<City> ReadFiles(List<string> files)
        {
            List<City> cities = new List<City>();

            foreach (string file in files)
            {
                ReadLine(file, cities);
            }

            return cities;
        }

        private void ReadLine(string file, List<City> cities)
        {
            using (StreamReader sr = new StreamReader(file, Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line == "")
                    {
                        break;
                    }
                    else
                    {
                        try
                        {
                            GetCityList(ParseAndTranslateNameCity(line), ParseNumber(line), cities);
                        }
                        catch
                        {
                            Console.WriteLine("Неверный формат строки:" + line);
                            Process.GetCurrentProcess().Kill();
                        }
                    }
                }
            }
        }

        private void GetCityList(string nameCity, int countPeople, List<City> cities)
        {
            cities.Add(new City { Name = nameCity, CountResident = countPeople });
        }

        private string ParseAndTranslateNameCity(string line)
        {
            return TextTranslator.TranslateFromRuToEn(ParseNameCity(line));
        }

        private int ParseNumber(string line)
        {
            return Int32.Parse(SplitText(line).Last().Trim());
        }

        private string ParseNameCity(string line)
        {
            return SplitText(line).First().Trim();
        }

        private string[] SplitText(string line)
        {
            return line.Split(',');
        }

        public void WriteFile(List<City> cities)
        {
            string dirName = "output.txt";

            using (StreamWriter sw = new StreamWriter(dirName, false, System.Text.Encoding.Default))
            {
                foreach (City c in cities)
                {
                    sw.WriteLine(c.Name + "," + c.CountResident);
                }
            }
            Console.WriteLine("Successful");
        }

        public abstract void GetListFilesInDirectory(string dirName, List<string> pathToAllFiles);
        public abstract void WriteDataToNewFile(string dirName);
    }
}
