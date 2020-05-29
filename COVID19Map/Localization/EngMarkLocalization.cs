using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class EngMarkLocalization : IMarkLocalization
    {
        public string GetConvalesText()
        {
            return "Convales";
        }

        public string GetCountryText()
        {
            return "Country";
        }

        public string GetDiedText()
        {
            return "Died";
        }

        public string GetTotalCasesText()
        {
            return "Total cases";
        }
    }
}
