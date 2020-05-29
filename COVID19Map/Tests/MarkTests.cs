using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    [TestFixture]
    class MarkTests
    {
        private string testCountryName = "test";

        [Test]
        public void MarkCreationTest()
        {
            Mark.Localization = new RuMarkLocalization();
            new Mark(testCountryName, new GMap.NET.PointLatLng(0, 0), 12345, 0, 0);
        }

        [Test]
        public void MarkTipTextTest()
        {
            Mark.Localization = new RuMarkLocalization();
            var mark = new Mark(testCountryName, new GMap.NET.PointLatLng(0, 0), 12345, 0, 0);
            Assert.True(mark.ToolTipText.Contains(testCountryName));
            Assert.True(mark.ToolTipText.Contains(12345.ToString()));
        }

        [Test]
        public void MarkPositiveRadiusTest()
        {
            Mark.Localization = new RuMarkLocalization();
            var mark = new Mark(testCountryName, new GMap.NET.PointLatLng(0, 0), 12345, 0, 0);
            Assert.True(mark.Radius > 0);
        }

        [Test]
        public void MarkZeroRadiusTest()
        {
            Mark.Localization = new RuMarkLocalization();
            var mark = new Mark(testCountryName, new GMap.NET.PointLatLng(0, 0), 0, 0, 0);
            Assert.AreEqual(0, mark.Radius, 1e-21);
        }
    }
}
