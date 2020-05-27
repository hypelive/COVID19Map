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
        private const double Coefficient = .0185d;

        private double GetPercentAfterTime(int time, double nowPercent) => nowPercent / (nowPercent + (1- nowPercent) / Math.Pow(Math.E, Coefficient * time));

        private void AddStat(StringBuilder statistic, string timeLabel, int days,
            double nowPercent, double convalesPercent, double diedPercent)
        {
            var cases = (long)(GetPercentAfterTime(days, nowPercent) * Population);
            statistic.Append($"{timeLabel}:\n");
            statistic.Append($"    Total cases: {cases}\n");
            statistic.Append($"    Convales: {cases * convalesPercent}\n");
            statistic.Append($"    Died: {cases * diedPercent}\n\n");
        }

        public string GetLabel()
        {
            return "Predict statistic";
        }

        public string GetStatistic(List<CountryData> data)
        {
            long totalCases = data
                .Select((cd) => cd.CasesCount)
                .Sum();
            long totalDied = data
                .Select((cd) => cd.DiedCount)
                .Sum();
            long totalConvales = data
                .Select((cd) => cd.СonvalesCount)
                .Sum();
            double nowPercent = (double)totalCases / Population;
            double convalesPercent = (double)totalConvales / totalCases;
            double diedPercent = (double)totalDied / totalCases;
            var statistic = new StringBuilder();
            AddStat(statistic, "now", 0, nowPercent, convalesPercent, diedPercent);
            AddStat(statistic, "1 day", 1, nowPercent, convalesPercent, diedPercent);
            AddStat(statistic, "7 days", 7, nowPercent, convalesPercent, diedPercent);
            AddStat(statistic, "30 days", 30, nowPercent, convalesPercent, diedPercent);
            return statistic.ToString();
        }
    }
}
