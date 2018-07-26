using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Moq;

namespace Capstone.Web.Controllers.Tests
{
    [TestClass()]
    public class SurveyControllerTests
    {
        // Get/Index Test
        [TestMethod()]
        public void SurveyController_IndexAction_ReturnIndexView()
        {
            //Arrange
            Mock<ISurveyDAO> mockISurveyDAO = new Mock<ISurveyDAO>();
            Mock<IParkDAO> mockIParkDAO = new Mock<IParkDAO>();
            SurveyController controller = new SurveyController(mockISurveyDAO.Object, mockIParkDAO.Object);

            //Act
            // Cast ActionResult to ViewResult
            ViewResult result = controller.Index() as ViewResult;

            //Assert
            Assert.AreEqual("Index", result.ViewName);
            mockIParkDAO.Verify(m => m.GetAllParks()); //verify that our test called GetAllParks on the Mock IParkDAL
        }

        /*
        * TEST
        *   saves record
        *   returns RedirectToRouteResult
        */
        [TestMethod()]
        public void SurveyController_SubmitSurvey_SavesRecordAndReturnsRedirect()
        {
            //Arrange
            Mock<ISurveyDAO> mockISurveyDAO = new Mock<ISurveyDAO>();
            Mock<IParkDAO> mockIParkDAO = new Mock<IParkDAO>();
            SurveyController controller = new SurveyController(mockISurveyDAO.Object, mockIParkDAO.Object);

            SurveyEntry parameter = new SurveyEntry
            {
                ParkCode = ".NET",
                EmailAddress = "adc124@booya.ninja",
                State = "Paris",
                ActivityLevel = "Potatoe"
            };

            //Act
            RedirectToRouteResult result = controller.SubmitSurvey(parameter) as RedirectToRouteResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Rankings", result.RouteValues["action"]);
            mockISurveyDAO.Verify(m => m.InsertSurvey(parameter)); //verify that our test called InsertSurvey on the Mock ISurveyDAO
        }

        // Get/Rankings Test
        [TestMethod()]
        public void SurveyController_Rankings_ReturnRankingsView()
        {
            //Arrange
            Mock<ISurveyDAO> mockISurveyDAO = new Mock<ISurveyDAO>();
            Mock<IParkDAO> mockIParkDAO = new Mock<IParkDAO>();
            SurveyController controller = new SurveyController(mockISurveyDAO.Object, mockIParkDAO.Object);

            //Act
            // Cast ActionResult to ViewResult
            ViewResult result = controller.Rankings() as ViewResult;

            //Assert
            Assert.AreEqual("Rankings", result.ViewName);
            mockISurveyDAO.Verify(m => m.GetTopFiveParks()); //verify that our test called GetTopFiveParks on the Mock ISurveyDAL
        }


    }
}