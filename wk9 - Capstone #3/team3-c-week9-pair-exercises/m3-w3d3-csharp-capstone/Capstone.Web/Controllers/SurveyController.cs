using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        ISurveyDAO dalSurvey;
        IParkDAO dalPark;
        public SurveyController(ISurveyDAO dalSurvey, IParkDAO dalPark)
        {
            this.dalSurvey = dalSurvey;
            this.dalPark = dalPark;
        }

        // GET: Survey/Index
        public ActionResult Index()
        {
            SurveyEntry survey = new SurveyEntry();
            survey.ParkList = dalPark.GetAllParks();
            return View("Index", survey);
        }

        [HttpPost]
        public ActionResult SubmitSurvey(SurveyEntry surveyEntry)
        {
            if (!ModelState.IsValid)
            {
                surveyEntry.ParkList = dalPark.GetAllParks();
                return View("Index", surveyEntry);
            }

            dalSurvey.InsertSurvey(surveyEntry);
            return RedirectToAction("Rankings", "Survey");
        }

        // GET: Survey/Rankings
        [HttpGet]
        public ActionResult Rankings()
        {
            List <SurveyResult> surveyResultsList = dalSurvey.GetTopFiveParks();
            return View("Rankings", surveyResultsList);
        }
    }
}