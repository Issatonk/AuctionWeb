using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.DAL.MSSQL.Entity;

public class PurchaseHistory
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public Guid LotId { get; set; }

    [Required]
    public Guid OwnerId { get; set; }


}
