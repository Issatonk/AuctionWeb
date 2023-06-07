using Auction.DAL.MSSQL.Entity;
using Auction.DAL.MSSQL;
using AutoFixture;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class DataSeeder
{
    private readonly AuctionContext _context;
    private readonly Fixture _fixture;

    public DataSeeder(AuctionContext context)
    {
        _context = context;
        _fixture = new Fixture();

    }

    private int _lotCounter = 1;
    private string GetNextLotName()
    {
        var result = $"Lot{_lotCounter}";
        _lotCounter++;
        return result ;
    }

    private string GetRandomCategory(List<string> categories)
    {
        var random = new Random();
        int index = random.Next(categories.Count);
        return categories[index];
    }

    public void Seed()
    {
        if (_context.Lots.Any())
        {
            return;
        }

        var user = _fixture.Create<User>();

        var lots = _fixture.Build<Lot>()
             .Without(l => l.Name)
             .With(l => l.Owner, user)
             .Without(l => l.PathPhoto)
             .CreateMany(10)
             .ToList();
        foreach (var lot in lots)
        {
            lot.Name = GetNextLotName();
        }
        _context.Users.Add(user);
        _context.Lots.AddRange(lots);
        _context.SaveChanges();
        
    }
}
