namespace RentACar.Model.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        public int? CompanyID { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public long? TelNum { get; set; }

        [StringLength(50)]
        public string Role { get; set; }

        public bool? Status { get; set; }

        public virtual Company Company { get; set; }
    }
}
