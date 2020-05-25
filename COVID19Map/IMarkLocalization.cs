using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    public interface IMarkLocalization
    {
        string getCountryText();
        string getTotalCasesText();
        string getConvalesText();
        string getDiedText();
    }
}
