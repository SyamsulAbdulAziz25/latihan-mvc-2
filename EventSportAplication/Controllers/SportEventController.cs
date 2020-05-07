using SportEvent.Controllers;
using SportEvent.Core;
using SportEvent.Core.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventSportAplication.Controllers
{
    public class SportEventController : Controller
    {
        // GET: SportEvent
        private readonly ISportEventBussinesLayer sportEventBussinesLayer;

        public SportEventController(ISportEventBussinesLayer sportEventBussinesLayer)
        {
            this.sportEventBussinesLayer = sportEventBussinesLayer;
        }
        // GET: SportEvent
        public ActionResult Index()
        {
            return View(sportEventBussinesLayer.GetActiveEvents());
        }
        public ActionResult ViewAllData()
        {
            return View(sportEventBussinesLayer.GetActiveAllEvents());
        }

        // GET: SportEvent/Details/5
        public ActionResult Details(String id)
        {
            try
            {
                return View(sportEventBussinesLayer.FindUser(id));
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage");
            }
        }

        // GET: SportEvent/Create
        public ActionResult Create()
        {   
            return View();
        }
        // POST: SportEvent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event ev)
        {

            try
            {
                // TODO: Add insert logic here

                if (ev.Date < DateTime.Now)
                {

                    ModelState.AddModelError("Date", "Must be grate than today");
                    return View();
                }
                else
                {
                    sportEventBussinesLayer.InsertUser(ev);
                    return RedirectToAction("ViewAllData");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SportEvent/Edit/5
        public ActionResult Edit(String id)
        {
            try
            {

                return View(sportEventBussinesLayer.FindUser(id));
            }
            catch (Exception)
            {

                return RedirectToAction("ErrorPage");
            }
        }

        // POST: SportEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, SportEventOutput sportEventOutput)
        {
            try
            {
                if (sportEventOutput.Date < DateTime.Now)
                {
                    ModelState.AddModelError("Date", "Must be grate than today");
                    return View();
                }
                else
                {
                    sportEventBussinesLayer.UpdateUser(id, sportEventOutput);
                    return RedirectToAction("ViewAllData");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SportEvent/Delete/5
        public ActionResult Delete(String id)
        {
            return View(sportEventBussinesLayer.FindUserForDelete(id));
        }

        // POST: SportEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, Event @event)
        {
            try
            {
                sportEventBussinesLayer.DeleteUser(id);

                return RedirectToAction("ViewAllData");
            }
            catch
            {
                return View();
            }
        }

        //Error Page
        public ActionResult ErrorPage()
        {
            return View();

        }
        public Event dataEvent { get; set;   }

    }
}