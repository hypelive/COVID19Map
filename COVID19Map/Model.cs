using StatsResources;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly string statPluginsPath = System.IO.Path.Combine(
                                                Directory.GetCurrentDirectory(),
                                                "Plugins");

        public Model()
        {
            //data = DataCollector.GetData();
            var cd = new CountryData() { Name = "USA", CasesCount = 10000 };
            DataParser.ParseСoordinates(cd);
            data = new List<CountryData>() { cd };
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
