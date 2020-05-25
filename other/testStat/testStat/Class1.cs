using StatsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testStat
{
    public class TestStat : IStatPlugin
    {
        public string GetLabel() => "Test";

        public string GetStatistic(List<CountryData> data) => "Hello test!";
    }
}
