using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class EngMarkLocalization : IMarkLocalization
    {
        public string getConvalesText()
        {
            return "Convales";
        }

        public string getCountryText()
        {
            return "Country";
        }

        public string getDiedText()
        {
            return "Died";
        }

        public string getTotalCasesText()
        {
            return "Total cases";
        }
    }
}
