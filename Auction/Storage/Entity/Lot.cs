using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Storage.Entity
{
    public class Lot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [ForeignKey(nameof(OwnerID))]
        public User Owner { get; set; }


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }


        [Required]
        public double CurrentPrice { get; set; } //начальная цена

        [Required]
        public DateTime FinalDate { get; set; }

        [Required]
        public string Category { get; set; }

        public string PathPhoto { get; set; }
    }
}
