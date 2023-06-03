using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auction.DAL.MSSQL.Entity;

public class Income
{

    [Key]
    public DateTime Id { get; set; }

    [Required]
    public double IncomeSum { get; set; }
}
