namespace RentACar.Model.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transactions
    {
        [Key]
        public int TransactionID { get; set; }

        public int? CarID { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        public double? CurrentKm { get; set; }

        public double? ReturnKm { get; set; }

        [Column(TypeName = "money")]
        public decimal? RentPrice { get; set; }

        public virtual Cars Cars { get; set; }

        public virtual Customers Customers { get; set; }
    }
}
