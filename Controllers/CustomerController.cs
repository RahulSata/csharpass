using AutoMapper;
using CSharpAssignment.Models;
using CSharpAssignment.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpAssignment.Controllers
{
    [HandleError(View = "Error")]
    [RoutePrefix("CustomerDetails")]
    public class CustomerController : Controller
    {
        //Enter URL : /Customer/Exception_handler for Error Handling.
        public void Exception_handler() {
            throw new Exception();
        }

        public ActionResult ViewAllCustomers()
        {
            List<CustomerViewModel> customerViewModel = new List<CustomerViewModel>();
            List<Customer> customers;

            using (var db = new CSharpAssignmentEntities())
            {
                customers = db.Customers.ToList<Customer>();

                foreach (var customer in customers)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Customer, CustomerViewModel>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var source = new Customer();
                    source = customer;
                    var cityname = db.Cities.Find(source.CityId).CityName;

                    var dest = mapper.Map<Customer, CustomerViewModel>(source);
                    dest.CityName = cityname;
                    customerViewModel.Add(dest);
                }
            }
            return View(customerViewModel);
        }

        // GET: Cutomer
        [Route("CustomerList")]
        public ActionResult Index()
        {
            List<CustomerViewModel> customerViewModel = new List<CustomerViewModel>();
            List<Customer> customers;

            using (var db = new CSharpAssignmentEntities())
            {
                customers = db.Customers.ToList<Customer>();

                foreach (var customer in customers)
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<Customer, CustomerViewModel>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var source = new Customer();
                    source = customer;
                    var cityname = db.Cities.Find(source.CityId).CityName;
                    var dest = mapper.Map<Customer, CustomerViewModel>(source);
                    dest.CityName = cityname;
                    customerViewModel.Add(dest);
                }
            }
            return View(customerViewModel);
        }

        


        // GET: Cutomer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cutomer/Create
        public ActionResult Create()
        {
            var db = new CSharpAssignmentEntities();

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "CityName");

            return View();
        }

        // POST: Cutomer/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            try
            {
                using (var db = new CSharpAssignmentEntities())
                {
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<CustomerViewModel, Customer>();
                    });

                    IMapper mapper = config.CreateMapper();
                    var source = new CustomerViewModel();
                    source = customerViewModel;
                    Customer customer = mapper.Map<CustomerViewModel, Customer>(source);
                    DateTime t = DateTime.Now;
                    customer.CreatedDate = t;
                    customer.UpadatedDate = t;
                    db.Customers.Add(customer);
                    db.SaveChanges();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cutomer/Edit/5
        public ActionResult Edit(int id)
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            Customer customer;

            using (var db = new CSharpAssignmentEntities())
            {
                customer = db.Customers.Find(id);
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            var source = new Customer();
            source = customer;
            CustomerViewModel dest = mapper.Map<Customer, CustomerViewModel>(source);


            return View(dest);
        }

        // POST: Cutomer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel customerViewModel)
        {
            using (var db = new CSharpAssignmentEntities())
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<CustomerViewModel, Customer>();
                });

                IMapper mapper = config.CreateMapper();

                var source = new CustomerViewModel();
                source = customerViewModel;
                Customer customer = mapper.Map<CustomerViewModel, Customer>(source);


                customer.CustomerId = id;
                DateTime t = DateTime.Now;

                customer.UpadatedDate = t;
                db.Entry(customer).State = EntityState.Modified;
                //db.Customers.Attach(cust);
                db.SaveChanges();
            }
            // TODO: Add update logic here

            return RedirectToAction("Index");

        }

        // GET: Cutomer/Delete/5
        public ActionResult Delete(int id)
        {
            CustomerViewModel dest = new CustomerViewModel();
            if (id != 0)
            {
                CustomerViewModel customerViewModel = new CustomerViewModel();
                Customer customer;

                using (var db = new CSharpAssignmentEntities())
                {
                    customer = db.Customers.Find(id);
                }

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerViewModel>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new Customer();
                source = customer;
                dest = mapper.Map<Customer, CustomerViewModel>(source);
            }
                return Json(dest, JsonRequestBehavior.AllowGet);
            
        }

        public ActionResult DeleteCustomer(int id)
        {

            CustomerViewModel customerViewModel = new CustomerViewModel();
            Customer customer;

            using (var db = new CSharpAssignmentEntities())
            {
                customer = db.Customers.Find(id);


                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerViewModel>();
                });

                IMapper mapper = config.CreateMapper();
                var source = new Customer();
                source = customer;
                CustomerViewModel dest = mapper.Map<Customer, CustomerViewModel>(source);
                var cityname = db.Cities.Find(source.CityId).CityName;
                dest.CityName = cityname;
                return View(dest);
            }
        }


        // POST: Cutomer/Delete/5
        [HttpPost]
        public ActionResult DeleteCustomer(int id, CustomerViewModel customerViewModel)
        {
            try
            {
                using (CSharpAssignmentEntities db = new CSharpAssignmentEntities())
                {
                    Customer cm = db.Customers.Find(id);
                    db.Customers.Remove(cm);
                    db.SaveChanges();
                }
                return Json(new { url = Url.Action("Index", "Customer") });
            }
            catch
            {
                return View();
            }
        }
    }
}
