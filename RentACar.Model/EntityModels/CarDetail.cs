namespace RentACar.Model.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarDetail")]
    public partial class CarDetail
    {
        [Key]
        public int CarDetailsID { get; set; }

        public int? CarID { get; set; }

        public int? TransactionID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BeginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        public int? DailyKm { get; set; }

        public virtual Cars Cars { get; set; }

        public virtual Transactions Transactions { get; set; }
    }
}
