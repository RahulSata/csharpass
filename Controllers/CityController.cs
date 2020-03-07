using CSharpAssignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpAssignment.Models;
using AutoMapper;

namespace CSharpAssignment.Controllers
{
    public class CityController : Controller
    {
        // GET: City
        public List<CityViewModel> Index()
        {
            List<CityViewModel> activityViewModel = new List<CityViewModel>();
            List<City> activities;

            using (var db = new CSharpAssignmentEntities())
            {
                activities = db.Cities.ToList<City>();
            }
            foreach (var activity in activities)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<City, CityViewModel>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new City();
                source = activity;
                var dest = mapper.Map<City, CityViewModel>(source);
                activityViewModel.Add(dest);
            }

            return activityViewModel;

        }



        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            CityViewModel cityvm = new CityViewModel()
            {
                CityId = 1,
                CityName = "Rajkot"
            };

            
            return View();
        }

        // POST: City/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: City/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
