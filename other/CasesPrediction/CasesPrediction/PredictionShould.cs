using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StatsResources;

namespace CasesPrediction
{
    [TestFixture]
    public class PredictionTests
    {
        [Test]
        public void CalcPercentsOneCaseTest()
        {
            var testData = new List<CountryData>() { new CountryData() { CasesCount = 1, DiedCount = 0, СonvalesCount = 1 } };
            var predicter = new CasesPrediction();
            predicter.CalculatePercents(testData,
                out var casesPart, out var convalesPart, out var diedPart);
            Assert.AreEqual(0, casesPart, 1e-8);
            Assert.AreEqual(0, diedPart, 1e-20);
            Assert.AreEqual(1, convalesPart, 1e-20);
        }

        [Test]
        public void CalcPercentsRealDataTest()
        {
            //data from 29.05 - 30.05
            var testData = new List<CountryData>() { new CountryData() { CasesCount = 5800000, DiedCount = 360000, СonvalesCount = 2400000 } };
            var predicter = new CasesPrediction();
            predicter.CalculatePercents(testData,
                out var casesPart, out var convalesPart, out var diedPart);

            Assert.AreEqual(7.4 * 1e-3, casesPart, 1e-1);
            Assert.AreEqual(0.062, diedPart, 1e-2);
            Assert.AreEqual(0.413, convalesPart, 1e-2);
        }

        [Test]
        public void PredictSampleTest()
        {
            //data from 29.05 - 30.05
            var testData = new List<CountryData>() { new CountryData() { CasesCount = 5800000, DiedCount = 360000, СonvalesCount = 2400000 } };
            var predicter = new CasesPrediction();
            predicter.CalculatePercents(testData,
                out var casesPart, out var convalesPart, out var diedPart);

            Assert.AreEqual(108000, CasesPrediction.Population*predicter.GetPercentAfterTime(1, casesPart) - testData[0].CasesCount, 1000);
        }

        //[Test] TODO INT -> LONG
        //public void CalcPercentsWholePopulationTest()
        //{
        //    var testData = new List<CountryData>() { new CountryData() { CasesCount = CasesPrediction.Population, DiedCount = 0, СonvalesCount = 1 } };
        //    var predicter = new CasesPrediction();
        //    predicter.CalculatePercents(testData,
        //        out var casesPart, out var convalesPart, out var diedPart);
        //    Assert.AreEqual(0, casesPart, 1e-8);
        //    Assert.AreEqual(0, diedPart, 1e-20);
        //    Assert.AreEqual(1, convalesPart, 1e-20);
        //}
    }
}
