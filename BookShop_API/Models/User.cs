namespace BookShop_API.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int UserID { get; set; }

        [Required]
        [StringLength(30)]
        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string UserType { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(120)]
        public string ShippingAddress { get; set; }

        [Required]
        [StringLength(30)]
        public string Passcode { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateJoined { get; set; }
    }
}
