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
        public const long Population = 7763035303L;
        private const double Coefficient = .0185d;

        private void AddStat(StringBuilder statistic, string timeLabel, int days,
            double casesPart, double convalesPart, double diedPart)
        {
            var cases = (long)(GetPercentAfterTime(days, casesPart) * Population);
            statistic.Append($"{timeLabel}:\n");
            statistic.Append($"    Total cases: {cases}\n");
            statistic.Append($"    Convales: {(long)(cases * convalesPart)}\n");
            statistic.Append($"    Died: {(long)(cases * diedPart)}\n\n");
        }

        public double GetPercentAfterTime(int time, double nowPercent) => nowPercent / (nowPercent + (1- nowPercent) / Math.Pow(Math.E, Coefficient * time));

        public void CalculatePercents(List<CountryData> data,
            out double casesPart, out double convalesPart, out double diedPart)
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

            casesPart = (double)totalCases / Population;
            convalesPart = (double)totalConvales / totalCases;
            diedPart = (double)totalDied / totalCases;
        }

        public string GetLabel()
        {
            return "Predict statistic";
        }

        public string GetStatistic(List<CountryData> data)
        {
            CalculatePercents(data,
                out var casesPart, out var convalesPart, out var diedPart);
            
            var statistic = new StringBuilder();
            AddStat(statistic, "now", 0, casesPart, convalesPart, diedPart);
            AddStat(statistic, "1 day", 1, casesPart, convalesPart, diedPart);
            AddStat(statistic, "7 days", 7, casesPart, convalesPart, diedPart);
            AddStat(statistic, "30 days", 30, casesPart, convalesPart, diedPart);
            return statistic.ToString();
        }
    }
}
