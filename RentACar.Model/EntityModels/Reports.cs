namespace RentACar.Model.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reports
    {
        [Key]
        public int ReportID { get; set; }

        [Column(TypeName = "money")]
        public decimal? TotalMoney { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReportDate { get; set; }
    }
}
