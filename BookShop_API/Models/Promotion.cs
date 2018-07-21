namespace BookShop_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Promotion")]
    public partial class Promotion
    {
        [Key]
        public int PromoID { get; set; }

        [Required]
        [StringLength(20)]
        public string Scope { get; set; }

        [Required]
        [StringLength(180)]
        public string PromoItem { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public int DiscountAmt { get; set; }
    }
}
