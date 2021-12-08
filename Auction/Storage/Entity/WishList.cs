using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Auction.Storage.Entity
{
    public class WishList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Guid LotId { get; set; }

        [Required]
        public double WishPrice { get; set; }
    }
}