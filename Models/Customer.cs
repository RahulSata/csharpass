
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CSharpAssignment.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Customer
{

    public int CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string Address1 { get; set; }

    public string Address2 { get; set; }

    public Nullable<int> CityId { get; set; }

    public string Country { get; set; }

    public string PostCode { get; set; }

    public string Email { get; set; }

    public string Mobile { get; set; }

    public Nullable<System.DateTime> BirthDate { get; set; }

    public Nullable<bool> Active { get; set; }

    public Nullable<System.DateTime> CreatedDate { get; set; }

    public Nullable<System.DateTime> UpadatedDate { get; set; }



    public virtual City City { get; set; }

}

}
