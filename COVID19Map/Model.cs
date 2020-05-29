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
    class PluginException : Exception
    {
        //for logs
        public static string GetPluginExceptionMessage(Exception e, Type type) =>
            $"При добавлении плагина {type.FullName} было вызвано исключение:\n {e.Message}";

        public PluginException(Exception e, Type type) :
            base(GetPluginExceptionMessage(e, type), e) { }
    }

    class Model
    {
        private List<CountryData> Data { get; set; }
        public List<IStatPlugin> StatPlugins { get; private set; }
        private readonly string statPluginsPath = Path.Combine(Directory.GetCurrentDirectory(), "StatPlugins");

        public Model(IParser parser)
        {
            var dataCollector = new DataCollector(parser);
            Data = dataCollector.GetData();

            InitStatPlugins();
        }

        private void InitStatPlugins()
        {
            StatPlugins = new List<IStatPlugin>();
            DirectoryInfo statsDirectoryInfo = new DirectoryInfo(statPluginsPath);
            if (!statsDirectoryInfo.Exists)
            {
                statsDirectoryInfo.Create();
            }

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
                    try
                    {
                        StatPlugins.Add((IStatPlugin)assembly.CreateInstance(type.FullName));
                    }
                    catch (Exception e)
                    {
                        //write to log
                        continue;
                    }
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
