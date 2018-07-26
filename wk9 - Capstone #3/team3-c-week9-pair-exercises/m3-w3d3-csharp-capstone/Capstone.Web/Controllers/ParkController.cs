using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.Controllers
{
    public class ParkController : Controller
    {
        IParkDAO dal;
        IWeatherDAO dal2;

        public ParkController(IParkDAO dal, IWeatherDAO dal2)
        {
            this.dal = dal;
            this.dal2 = dal2;
        }

        // GET: Park
        public ActionResult Index()
        {

            List<Park> parks = dal.GetAllParks();

            return View("Index", parks);
        }

        // GET: Park/Details
        public ActionResult Details(string id)
        {
            ParkDetails model = new ParkDetails();
            model.Weather = dal2.GetForcast(id);
            model.Park = dal.GetParkDetails(id);

            if (Session["TempUnit"] == null)
            {

                foreach (Weather weather in model.Weather)
                {
                    weather.Unit = 'F';
                    weather.Farhrenheit = true;
                    Session["TempUnit"] = weather.Unit;
                }
            }
            else if ((char)Session["TempUnit"] == 'C')
            {
                Session["TempUnit"] = 'F';
                foreach (Weather weather in model.Weather)
                {
                    weather.Unit = 'F';
                    weather.TempConversion('F');
                    weather.Celcius = true;
                    Session["TempUnit"] = weather.Unit;
                }
            }
            else
            {
                Session["TempUnit"] = 'C';
            }
            return View("Details", model);
        }
        
        //if (Session["TempUnit"] == null)
        //{
        //    Session["TempUnit"] = 'F';
        //}
        //else if ((bool)Session["ShouldUnitChange"])
        //{
        //    if ((char)Session["TempUnit"] == 'F')
        //    {
        //        foreach (Weather weather in model.Weather)
        //        {
        //            weather.TempConversion((char)Session["TempUnit"]);
        //        }
        //        Session["TempUnit"] = 'C';
        //    }
        //    else if ((char)Session["TempUnit"] == 'C')
        //    {
        //        Session["TempUnit"] = 'F';
        //    }
        //    Session["ShouldUnitChange"] = false;
        //}
        //else if ((char)Session["TempUnit"] == 'C')
        //{
        //    foreach (Weather weather in model.Weather)
        //    {
        //        weather.TempConversion('F');
        //    }
        //    if ((bool)Session["ShouldUnitChange"])
        //    {

        //        foreach (Weather weather in model.Weather)
        //        {
        //            weather.TempConversion((char)Session["TempUnit"]);
        //        }
        //        Session["TempUnit"] = 'F';
        //    }
        //}

        //address case for where the Session is already in Cel 'C'

        //model.Park = dal.GetParkDetails(id);
        //Session["TempUnit"] = model;
        //return View("Details", Session["TempUnit"]);


        public ActionResult ChangeTemperatureUnit(string parkCode)
        {

            ParkDetails model = new ParkDetails();
            model.Park = dal.GetParkDetails(parkCode);
            model.Weather = dal2.GetForcast(parkCode);

            foreach (Weather weather in model.Weather)
            {
                if (Session["TempUnit"] == null)
                {
                    weather.Farhrenheit = true;
                    weather.Celcius = false;
                    weather.Unit = 'F';
                }
                else if ((char)Session["TempUnit"] == 'F')
                {
                    weather.Farhrenheit = false;
                    weather.Celcius = true;
                    weather.Unit = 'C';

                }
                else
                {
                    weather.Celcius = false;
                    weather.Farhrenheit = true;
                    weather.Unit = 'F';
                }
            }

            return RedirectToAction("Details", new { id = parkCode });
        }

    }
}