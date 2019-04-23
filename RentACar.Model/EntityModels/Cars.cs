namespace RentACar.Model.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cars
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cars()
        {
            Transactions = new HashSet<Transactions>();
        }

        [Key]
        public int CarID { get; set; }

        public int? CompanyID { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(50)]
        public string Model { get; set; }

        public int? CarLicenceAge { get; set; }

        [StringLength(1)]
        public string DriverType { get; set; }

        public int? CarDriverAge { get; set; }

        public double? DailyKm { get; set; }

        public double? CurrentKm { get; set; }

        public bool? HasAirbag { get; set; }

        public int? LuggageValume { get; set; }

        public int? NumSeats { get; set; }

        [Column(TypeName = "money")]
        public decimal? RentPrice { get; set; }

        public bool? Status { get; set; }

        public virtual Company Company { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
