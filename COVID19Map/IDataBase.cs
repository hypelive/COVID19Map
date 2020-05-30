using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatsResources;

namespace COVID19Map
{
    interface IDataBase
    {
        void SetToDB(CountryData data);
        CountryData GetFromDB(string name);
    }
}
