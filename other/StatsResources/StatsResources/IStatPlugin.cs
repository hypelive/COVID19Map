using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsResources
{
    public interface IStatPlugin
    {
        string GetStatistic(List<CountryData> data);
        string GetLabel();
    }
}
