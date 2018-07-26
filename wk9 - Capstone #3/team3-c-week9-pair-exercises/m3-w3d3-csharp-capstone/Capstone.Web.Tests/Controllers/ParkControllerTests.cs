using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Moq;
using System.Web;
using System.Web.Routing;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class ParkControllerTests
    {
        // Get/Index Test
        [TestMethod()]
        public void ParkController_IndexAction_ReturnIndexView()
        {
            //Arrange
            Mock<IWeatherDAO> mockIWeatherDAO = new Mock<IWeatherDAO>();
            Mock<IParkDAO> mockIParkDAO = new Mock<IParkDAO>();
            ParkController controller = new ParkController(mockIParkDAO.Object, mockIWeatherDAO.Object);

            //Act
            // Cast ActionResult to ViewResult
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
            mockIParkDAO.Verify(m => m.GetAllParks()); //verify that our test called GetAllParks on the Mock IParkDAL
        }

        // Get/Details Test
        [TestMethod()]
        public void SurveyController_DetailsAction_ReturnDetailsView()
        {
            //Arrange
            Mock<IWeatherDAO> mockIWeatherDAO = new Mock<IWeatherDAO>();
            Mock<IParkDAO> mockIParkDAO = new Mock<IParkDAO>();
            ParkController controller = new ParkController(mockIParkDAO.Object, mockIWeatherDAO.Object);

            // Weird stuff
            var httpContextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
            sessionMock.Setup(n => n["TempUnit"]).Returns('F');
            httpContextMock.Setup(n => n.Session).Returns(sessionMock.Object);
            sessionMock.Setup(n => n["ShouldUnitChange"]).Returns(false);
            httpContextMock.Setup(n => n.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(),controller);


            //Act
            // Cast ActionResult to ViewResult
            string paraString = "CVNP";
            ViewResult result = controller.Details(paraString) as ViewResult;

            //Assert
            Assert.AreEqual("Details", result.ViewName);
            mockIWeatherDAO.Verify(m => m.GetForcast(paraString)); //verify that our test called GetForcast on the Mock IWeatherDAL
        }

        /*
        * TEST
        *   saves record
        *   returns RedirectToRouteResult
        */
        [TestMethod()]
        public void ParkController_ChangeTemperatureUnit_ChangesSessionAndReturnsRedirect()
        {
            //Arrange
            Mock<IWeatherDAO> mockIWeatherDAO = new Mock<IWeatherDAO>();
            Mock<IParkDAO> mockIParkDAO = new Mock<IParkDAO>();
            ParkController controller = new ParkController(mockIParkDAO.Object, mockIWeatherDAO.Object);
            string parameterString = "Boya!";

            // More Weird stuff
            var httpContextMock = new Mock<HttpContextBase>();
            var sessionMock = new Mock<HttpSessionStateBase>();
           // sessionMock.Setup(n => n["ShouldUnitChange"]).Returns(false);
            httpContextMock.Setup(n => n.Session).Returns(sessionMock.Object);

            controller.ControllerContext = new ControllerContext(httpContextMock.Object, new RouteData(), controller);

            //Act
            RedirectToRouteResult result = controller.ChangeTemperatureUnit(parameterString) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Details", result.RouteValues["action"]);
        }
    }
}
