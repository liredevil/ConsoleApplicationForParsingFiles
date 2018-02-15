using IHSMarkitTask.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IHSMarkitTask
{
    class HttpMode : FileProcessingBase
    {
        List<string> pathesToFiles = new List<string>();
        ResidentsCounter residentsCounter = new ResidentsCounter();

        public override async void WriteDataToNewFile(string pathToFileWithlistAddresse)
        {
            FileInfo fileInf = new FileInfo(pathToFileWithlistAddresse);

            if (fileInf.Exists)
            {
                await DownloadMultipleFilesAsync(GetListUrlAddres(pathToFileWithlistAddresse));
                WriteFile(residentsCounter.CountResidentsInCity(ReadFiles(pathesToFiles)));
            }
            else
            {
                Console.WriteLine("Файл не сущесвует " + pathToFileWithlistAddresse);
                Process.GetCurrentProcess().Kill();
            }
        }

        private IEnumerable<DocumentObject> GetListUrlAddres(string dirName)
        {
            List<DocumentObject> listAddresses = new List<DocumentObject>();

            int i = 0;

            using (StreamReader sr = new StreamReader(dirName, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    listAddresses.Add(new DocumentObject { Name = "file" + i, Url = line });
                    i++;
                }
            }

            return listAddresses;
        }

        private async Task DownloadFileAsync(DocumentObject doc)
        {
            Directory.CreateDirectory("Files");
            string directory = @"Files\";
            string extension = ".txt";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    string downloadToDirectory = directory + doc.Name + extension;

                    await webClient.DownloadFileTaskAsync(new Uri(doc.Url), downloadToDirectory);

                    GetListFilesInDirectory(downloadToDirectory, pathesToFiles);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to download File: " + doc);
                Process.GetCurrentProcess().Kill();
            }
        }

        private async Task DownloadMultipleFilesAsync(IEnumerable<DocumentObject> doclist)
        {
            await Task.WhenAll(doclist.Select(doc => DownloadFileAsync(doc)));
        }

        public override void GetListFilesInDirectory(string dirName, List<string> pathesToFiles)
        {
            pathesToFiles.Add(dirName);
        }
    }
}
