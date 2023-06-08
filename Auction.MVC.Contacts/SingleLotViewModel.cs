namespace Auction.MVC.Contracts;

public class SingleLotViewModel
{
    public Guid Id { get; set; }
    public Guid OwnerId { get; set; }
    public string OwnerName { get;set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal CurrentPrice { get; set; } 
    public DateTime FinalDate { get; set; }
    public string Category { get; set; }
    public string? PathPhoto { get; set; }
    public bool IsSold { get; set; }
}
