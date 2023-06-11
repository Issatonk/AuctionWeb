using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.DAL.MSSQL.Entity;

public class Bet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User User { get; set; }
    [Required]
    public Guid LotId { get; set; }
    [ForeignKey(nameof(LotId))]
    public Lot Lot { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public DateTime Time { get; set; }

}