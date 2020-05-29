using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class RuMarkLocalization : IMarkLocalization
    {
        public string GetConvalesText()
        {
            return "Выздоровело";
        }

        public string GetCountryText()
        {
            return "Страна";
        }

        public string GetDiedText()
        {
            return "Умерло";
        }

        public string GetTotalCasesText()
        {
            return "Всего случаев";
        }
    }
}
