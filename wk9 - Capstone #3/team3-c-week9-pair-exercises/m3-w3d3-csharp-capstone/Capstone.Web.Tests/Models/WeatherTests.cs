using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using System.Web;

namespace Capstone.Web.Models.Tests
{
    [TestClass()]
    public class WeatherTests
    {
        [TestMethod()]
        public void WeatherModel_ConvertToFahrenheit()
        {
            // Arrange
            Weather model = new Weather();
            int parameterCelcius = 100;

            // Act
            int result = model.ConvertToFahrenheit(parameterCelcius);

            // Assert
            Assert.AreEqual(212, result);
        }

        [TestMethod()]
        public void WeatherModel_ConvertToCelcius()
        {
            // Arrange
            Weather model = new Weather();
            int parameterFahrenheit = 32;

            // Act
            int result = model.ConvertToCelcius(parameterFahrenheit);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
