using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class Model
    {
        //data to visualisation
        //plugins for statisctics

        private List<CountryData> data;
        private string pathToStatModules;

        public Model()
        {
            data = new List<CountryData>() { new CountryData() { Name= "Russia" , Latitude= 55.75393, Longitude= 37.620695, CasesCount = 100000 } };
        }

        public IEnumerable<CountryData> GetCOVIDData()
        {
            foreach (var countryData in data)
            {
                yield return countryData;
            }
        }
    }
}
