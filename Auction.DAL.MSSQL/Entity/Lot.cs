using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.DAL.MSSQL.Entity;

public class Lot
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public User Owner { get; set; }


    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MaxLength(300)]
    public string Description { get; set; }


    [Required]
    public decimal StartPrice { get; set; }

    [Required]
    public DateTime FinalDate { get; set; }

    [Required]
    public string Category { get; set; }

    public string? PathPhoto { get; set; }

    public bool IsSold { get; set; }

    public decimal HighestBid { get; set; }

    public User HighestBidder { get; set; }

    public Lot()
    {
        HighestBid = StartPrice;
        HighestBidder = null;
    }


}
