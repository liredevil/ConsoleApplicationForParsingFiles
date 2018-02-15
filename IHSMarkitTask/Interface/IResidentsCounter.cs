using IHSMarkitTask.Model;
using System.Collections.Generic;

namespace IHSMarkitTask.Interface
{
    interface IResidentsCounter
    {
        List<City> CountResidentsInCity(List<City> cities);
    }
}
