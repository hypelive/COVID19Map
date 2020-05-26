using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    interface IParser
    {
        void ParseСoordinates(CountryData country);
        void ParseStatistics(List<CountryData> countryDatas);
    }
}
