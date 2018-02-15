using IHSMarkitTask.Interface;
using IHSMarkitTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHSMarkitTask
{
    class ResidentsCounter : IResidentsCounter
    {
        public List<City> CountResidentsInCity(List<City> cities)
        {
            List<City> amountResidentsInCity = new List<City>();
            int flag = 1;

            for (int i = 0; i < cities.Count; i++)
            {
                if (amountResidentsInCity.Count == 0)
                {
                    amountResidentsInCity.Add(new City { Name = cities[i].Name, CountResident = cities[i].CountResident });
                    i++;
                }
                for (int j = 0; j < amountResidentsInCity.Count; j++)
                {
                    if (cities[i].Name == amountResidentsInCity[j].Name)
                    {
                        amountResidentsInCity[j].CountResident += cities[i].CountResident;
                        flag = 0;
                    }
                    else if (flag == 1 && j == amountResidentsInCity.Count - 1)
                    {
                        amountResidentsInCity.Add(new City { Name = cities[i].Name, CountResident = cities[i].CountResident });
                        break;
                    }
                }
                flag = 1;
            }

            return amountResidentsInCity;
        }
    }
}
