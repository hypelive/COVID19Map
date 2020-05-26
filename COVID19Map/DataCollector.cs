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
            var parser = new DataParser();
            parser.ParseStatistics(data);
            var count = data.Count;
            for (var i = 0; i < count; i++)
            {
                var currentData = DataBase.GetFromDB(data[i].Name);
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
                        DataBase.SetToDB(data[i]);
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
