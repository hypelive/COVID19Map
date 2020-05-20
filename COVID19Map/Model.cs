﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    class Model
    {
        //data to visualisation
        //plugins for statisctics

        private List<object> data;
        private string pathToStatModules;

        public IEnumerable<object> getCOVIDData()
        {
            foreach (var countryData in data)
            {
                yield return countryData;
            }

            yield break;
        }
    }
}
