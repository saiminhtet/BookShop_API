namespace BookShop_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionDetail")]
    public partial class TransactionDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionDetail_ID { get; set; }

        public int OrderID { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }
    }
}
