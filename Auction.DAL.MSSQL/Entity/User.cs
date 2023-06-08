using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Auction.DAL.MSSQL.Entity;

public class User : IdentityUser<Guid>
{
    [Required]
    public virtual Balance Balance { get; set; }

}
