using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingMVC.Models;

namespace CascadingMVC.Controllers
{
    public class CasController : Controller
    {
        // GET: Cas
        public ActionResult Index()
        {
            SampleDBEntities sd = new SampleDBEntities();
            ViewBag.countryList = new SelectList(GetCountryList(),"cid","cname");
            return View();
        }
        public List<country> GetCountryList()
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<country> countries = sd.countries.ToList();
            return countries;
        }
        public ActionResult GetStateList(int Cid)
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<state> selectList = sd.states.Where(x => x.cid== Cid).ToList();
            ViewBag.Slist = new SelectList(selectList,"Sid","Sname");
            return PartialView("DisplayStatess");
        }
        public ActionResult GetCityList(int Sid)
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<city> selectList = sd.cities.Where(x => x.sid == Sid).ToList();
            ViewBag.Citylist = new SelectList(selectList, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }
    }
}