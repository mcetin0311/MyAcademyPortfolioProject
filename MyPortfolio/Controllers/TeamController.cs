using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TeamController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Team
        public ActionResult Index()
        {
            var values = db.TblTeams.ToList();
            return View(values);
        }
        public ActionResult AddTeam()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AddTeam(TblTeams team)
        {
       
            db.TblTeams.Add(team);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTeam(TblTeams team)
        {
            var value = db.TblTeams.Find(team.TeamId);

            value.ImageUrl = team.ImageUrl;
            value.NameSurname = team.NameSurname;
            value.Description = team.Description;
            value.TwitterUrl = team.TwitterUrl;
            value.FacebookUrl = team.FacebookUrl;
            value.LinkedinUrl = team.LinkedinUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTeam(int id)
        {
            var value = db.TblTeams.Find(id);
            db.TblTeams.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}