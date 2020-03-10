using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpAssignment.ViewModel
{
    public class CustomerViewModel
    {
        Constants constant = new Constants();
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Nullable<int> CityId { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpadatedDate { get; set; }


    }

}