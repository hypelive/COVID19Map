using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace COVID19Map
{
    class DataBase
    {
        private static string writePath = "DB.txt";
        public void SetToDB(CountryData data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    string json = JsonConvert.SerializeObject(data, Formatting.None);
                    sw.WriteLine(json);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public CountryData GetFromDB(string name)
        {
            using (StreamReader sr = new StreamReader(writePath, Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var country = JsonConvert.DeserializeObject<CountryData>(line);
                    if (country.Name == name)
                        return country;
                }
            }
            return new CountryData();
        }
    }
}
