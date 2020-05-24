using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    static class DataCollector
    {
        public static List<CountryData> GetData()
        {
            var data = new List<CountryData>();
            DataParser.ParseStatistics(data);
            var count = data.Count;
            for (var i = 0; i < count; i++)
            {
                DataParser.ParseСoordinates(data[i]);
                if (data[i].Latitude + data[i].Longitude == 0.0)
                {
                    data.Remove(data[i]);
                    count--;
                }
            }
            return data;
        }
    }
}
