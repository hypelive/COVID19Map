using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsResources
{
    public interface IStatPlugin
    {
        void ShowStatistic(List<CountryData> data);
    }
}
