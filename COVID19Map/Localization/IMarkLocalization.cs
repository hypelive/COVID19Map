using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    public interface IMarkLocalization
    {
        string GetCountryText();
        string GetTotalCasesText();
        string GetConvalesText();
        string GetDiedText();
    }
}
