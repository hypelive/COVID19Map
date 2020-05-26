using StatsResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasesPrediction
{
    public class CasesPrediction : IStatPlugin
    {
        private const long Population = 7763035303L;
        private const double Coefficient = .18d;

        private double GetPercentAfterTime(int time, double nowPercent) => nowPercent / (nowPercent + (1- nowPercent) / Math.Pow(Math.E, Coefficient * time));

        public string GetLabel()
        {
            return "Predict total cases";
        }

        public string GetStatistic(List<CountryData> data)
        {
            var totalCases = data
                .Select((cd) => cd.CasesCount)
                .Sum();
            double nowPercent = (double)totalCases / Population;
            var statistic = new StringBuilder();
            statistic.Append($"now: {totalCases}\n");
            statistic.Append($"1 day: {(long)(GetPercentAfterTime(1, nowPercent) * Population)}\n");
            statistic.Append($"7 day: {(long)(GetPercentAfterTime(7, nowPercent) * Population)}\n");
            statistic.Append($"30 day: {(long)(GetPercentAfterTime(30, nowPercent) * Population)}\n");
            return statistic.ToString();
        }
    }
}
