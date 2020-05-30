using StatsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class DataCollector
    {
        private IParser parser;

        public DataCollector(IParser currentParser)
        {
            parser = currentParser;
        }

        public List<CountryData> GetData()
        {
            var data = new List<CountryData>();
            parser.ParseStatistics(data);
            var count = data.Count;
            for (var i = 0; i < count; i++)
            {
                var db = new DataBase();
                var currentData = db.GetFromDB(data[i].Name);
                if (currentData.Name is null)
                {
                    parser.ParseСoordinates(data[i]);
                    if (data[i].Latitude + data[i].Longitude == 0.0)
                    {
                        data.Remove(data[i]);
                        count--;
                    }
                    else
                    {
                        db.SetToDB(data[i]);
                    }
                }
                else
                {
                    data[i].Latitude = currentData.Latitude;
                    data[i].Longitude = currentData.Longitude;
                }
            }
            return data;
        }
    }
}
