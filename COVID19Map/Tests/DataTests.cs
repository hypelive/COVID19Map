using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StatsResources;

namespace COVID19Map
{
    public class COVID_19MapTests
    {
        [TestCase("Польша", 49, 15)]
        [TestCase("England", 10.0001, -45.9)]
        [TestCase("Russia", 0.004, 19.8)]
        [TestCase("Moscow", -4.90, -7.87)]
        [TestCase("Kipr", 0.0000001, -0.0009)]
        [TestCase("Валенсия", 36.90, 78.9080889)]
        public void CorrectSetInDB(string name, double longitude, double latitude)
        {
            var db = new DataBase();
            var countryData = new CountryData {Name = name, Longitude = longitude, Latitude = latitude};
            db.SetToDB(countryData);
            var currentData = db.GetFromDB(name);
            Assert.AreEqual(latitude, currentData.Latitude);
            Assert.AreEqual(longitude, currentData.Longitude);
        }

        [TestCase("Россия", 97.74531, 64.68632)]
        [TestCase("Испания", -4.003104, 40.002804)]
        [TestCase("Великобритания", -3.276575, 54.702354)]
        [TestCase("Италия", 12.674297, 42.638428)]
        [TestCase("Франция", 1.888333, 46.603355)]
        [TestCase("Германия", 10.423447, 51.08342)]
        [TestCase("Турция", 34.924965, 38.95976)]
        [TestCase("Индия", 78.66774, 22.351114)]
        [TestCase("Иран", 52.947132, 32.94075)]
        public void ParseCoordinatesTest(string name, double longitude, double latitude)
        {
            var countryData = new CountryData{Name = name};
            var parser = new DataParser();
            parser.ParseСoordinates(countryData);
            Assert.AreEqual(longitude, countryData.Longitude);
            Assert.AreEqual(latitude, countryData.Latitude);
        }
    }
}
