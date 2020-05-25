using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class RuMarkLocalization : IMarkLocalization
    {
        public string getConvalesText()
        {
            return "Выздоровело";
        }

        public string getCountryText()
        {
            return "Страна";
        }

        public string getDiedText()
        {
            return "Умерло";
        }

        public string getTotalCasesText()
        {
            return "Всего случаев";
        }
    }
}
