using IHSMarkitTask.Model;
using System.Collections.Generic;

namespace IHSMarkitTask.Interface
{
    interface IFileProcessing
    {
        List<City> ReadFiles(List<string> files);
        void WriteFile(List<City> cities);
    }
}
