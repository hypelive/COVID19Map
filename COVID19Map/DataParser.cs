using StatsResources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace COVID19Map
{
    static class DataParser
    {
        private static string statisticURL = "https://coronavirus-monitor.info";
        private static string coordinatesURL = "http://search.maps.sputnik.ru/search/addr?q=";
        private static string startName = "США";

        public static void ParseСoordinates(CountryData country)
        {
            string data = GetCode(coordinatesURL + country.Name);
            var coordRegex = new Regex(@"coordinates"":.*?(-*\d*\.\d*),(-*\d*\.\d*)");
            var coordinates = coordRegex.Match(data);
            var style = NumberStyles.Any;
            var culture = CultureInfo.InvariantCulture;
            double.TryParse(coordinates.Groups[1].Value, style, culture, out country.Longitude);
            double.TryParse(coordinates.Groups[2].Value, style, culture, out country.Latitude);
        }

        public static void ParseStatistics(List<CountryData> countryDatas)
        {
            var isStart = false;
            string data = GetCode(statisticURL);
            Regex dataRegex = new Regex(@"<a href=""/country/.*?"">(.*?>){12}");
            MatchCollection matches = dataRegex.Matches(data);
            foreach (Match match in matches)
            {
                var currentData = MakeDataElement(match.Value);
                if (currentData.Name == startName)
                    isStart = true;
                if (isStart)
                    countryDatas.Add(currentData);
            }
        }

        private static CountryData MakeDataElement(string data)
        {
            var result = new CountryData();
            var nameRegex = new Regex(@">(\D*?)<");
            var caseRegex = new Regex(@">(\d+?)<");
            var convalesRegex = new Regex(@">(\d+?)</d");
            var dieRegex = new Regex(@"s=""(\d*?)""");
            var name = nameRegex.Match(data);
            var cases = caseRegex.Match(data);
            var convales = convalesRegex.Match(data);
            var died = dieRegex.Match(data);
            result.Name = name.Groups[1].ToString();
            int.TryParse(cases.Groups[1].ToString(), out result.CasesCount);
            int.TryParse(convales.Groups[1].ToString(), out result.СonvalesCount);
            int.TryParse(died.Groups[1].ToString(), out result.DiedCount);
            return result;
        }

        private static string GetCode(string url)
        {
            string data = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = response.CharacterSet == null
                        ? new StreamReader(receiveStream)
                        : new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                }
                return data;
            }
            catch (WebException e)
            {
                return "";
            }
        }
    }
}
