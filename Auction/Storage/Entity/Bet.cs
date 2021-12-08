using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Storage.Entity
{
    public class Bet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Guid ManId { get; set; }
        [ForeignKey(nameof(ManId))]
        public User Man { get; set; }
        [Required]
        public Guid LotsId { get; set; }
        [ForeignKey(nameof(LotsId))]
        public Lot Lots { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public DateTime Time { get; set; }

    }
}