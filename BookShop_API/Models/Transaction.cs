namespace BookShop_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TransactionID { get; set; }

        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserID { get; set; }

        [StringLength(40)]
        public string UserName { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(70)]
        public string ShippingAddress { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string PostalCode { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }
    }
}
