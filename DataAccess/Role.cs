//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Role
    {
        public decimal Role_ID { get; set; }
        public string Role_Name { get; set; }
        public string Role_Description { get; set; }
        public decimal CreatedBy { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public decimal ModifiedBy { get; set; }
        public System.DateTime ModifiedDateTime { get; set; }
        public bool IsActive { get; set; }
    }
}
