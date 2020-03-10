using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CSharpAssignment.Models;
using CSharpAssignment.ViewModel;

namespace CSharpAssignment.Areas.CityArea.Controllers
{
    [HandleError(View = "Error")]
    public class CitiesController : Controller
    {
        private CSharpAssignmentEntities db = new CSharpAssignmentEntities();

        // GET: CityArea/Cities
        [OutputCache(CacheProfile = "Cache20Sec")]
        public ActionResult Index()
        {
            ViewBag.time = DateTime.Now;
            List<CityViewModel> cityViewModel = new List<CityViewModel>();
            List<City> cities;

            using (var db = new CSharpAssignmentEntities())
            {
                cities = db.Cities.ToList<City>();

                foreach (var city in cities)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<City, CityViewModel>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var source = new City();
                    source = city;
                    

                    var dest = mapper.Map<City, CityViewModel>(source);
                    
                    cityViewModel.Add(dest);
                }
            }
            return View(cityViewModel);

        }

        // GET: CityArea/Cities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // GET: CityArea/Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CityArea/Cities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CityId,CityName,CreatedDate,UpdatedDate")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Cities.Add(city);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(city);
        }

        // GET: CityArea/Cities/Edit/5
        
        public ActionResult Edit(int? id)
        {
            Constants constant = new Constants();
            Debug.WriteLine(constant.EmailAlreadyExist);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: CityArea/Cities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CityId,CityName,CreatedDate,UpdatedDate")] City city)
        {
            if (ModelState.IsValid)
            {
                db.Entry(city).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: CityArea/Cities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            City city = db.Cities.Find(id);
            if (city == null)
            {
                return HttpNotFound();
            }
            return View(city);
        }

        // POST: CityArea/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            City city = db.Cities.Find(id);
            db.Cities.Remove(city);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
