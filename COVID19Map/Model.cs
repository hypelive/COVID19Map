using StatsResources;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class Model
    {
        //data to visualisation
        //plugins for statisctics

        private List<CountryData> Data { get; set; }
        public List<IStatPlugin> StatPlugins { get; private set; }
        private readonly string statPluginsPath = Path.Combine(Directory.GetCurrentDirectory(), "Stats");

        public Model()
        {
            //Data = DataCollector.GetData();
            var cd = new CountryData() { Name = "USA", CasesCount = 500000 };
            var p = new DataParser();
            p.ParseСoordinates(cd);
            Data = new List<CountryData>() { cd };

            InitStatPlugins();
        }

        private void InitStatPlugins()
        {
            StatPlugins = new List<IStatPlugin>();
            DirectoryInfo statsDirectoryInfo = new DirectoryInfo(statPluginsPath);
            if (!statsDirectoryInfo.Exists)
                statsDirectoryInfo.Create();

            var libraries = Directory.GetFiles(statPluginsPath, "*.dll");
            foreach (var library in libraries)
            {
                var assembly = Assembly.LoadFrom(library);
                var classes = assembly
                    .GetTypes()
                    .Where(type => type.GetInterfaces()
                        .Any(inter => inter.FullName == typeof(IStatPlugin).FullName));
                foreach (var type in classes)
                {
                    StatPlugins.Add((IStatPlugin)assembly.CreateInstance(type.FullName));
                }
            }
        }

        public IEnumerable<CountryData> GetCOVIDData()
        {
            foreach (var countryData in Data)
            {
                yield return countryData;
            }
        }
    }
}
