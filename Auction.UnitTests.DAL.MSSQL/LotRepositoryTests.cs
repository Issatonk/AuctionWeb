using Auction.DAL.MSSQL;
using Auction.DAL.MSSQL.Entity;
using Auction.DAL.MSSQL.Repositories;
using Auction.Interfaces.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;


namespace Auction.UnitTests.DAL.MSSQL;

public class LotRepositoryTests
{
    private readonly DbContextOptions<AuctionContext> _dbContextOptions;

    public LotRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<AuctionContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
    }

    [Fact]
    public async Task GetMany_ShouldReturnCorrectLots()
    {
        // Arrange
        var lot1 = new Lot { Id = Guid.NewGuid(), Name = "Lot 1", Category = "Category 1", IsSold = false, Description="", PathPhoto = "" };
        var lot2 = new Lot { Id = Guid.NewGuid(), Name = "Lot 2", Category = "Category 2", IsSold = false, Description = "", PathPhoto = "" };
        var lot3 = new Lot { Id = Guid.NewGuid(), Name = "Lot 3", Category = "Category 1", IsSold = true, Description = "", PathPhoto = "" };

        using var context = new AuctionContext(_dbContextOptions);
        
        context.Lots.AddRange(new List<Lot> { lot1, lot2, lot3 });
        context.SaveChanges();
        

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var lotRepository = new LotRepository(context);

        // Act
        var result = await lotRepository.GetMany(filtres: null, 
            sorts: null, 
            include: null, 
            pageIndex: 0, 
            pageSize: 10, 
            disableTracking: true);

        // Assert
        Assert.Equal(3, result.Count());
    }

    [Fact]
    public async Task GetFirstOrDefault_ShouldReturnCorrectLot()
    {
        // Arrange
        var lot1 = new Lot { Id = Guid.NewGuid(), Name = "Lot 1", Category = "Category 1", IsSold = false, Description = "", PathPhoto = "" };
        var lot2 = new Lot { Id = Guid.NewGuid(), Name = "Lot 2", Category = "Category 2", IsSold = false, Description = "", PathPhoto = "" };
        var lot3 = new Lot { Id = Guid.NewGuid(), Name = "Lot 3", Category = "Category 1", IsSold = true, Description = "", PathPhoto = "" };

        using var context = new AuctionContext(_dbContextOptions);
    
        context.Lots.AddRange(new List<Lot> { lot1, lot2, lot3 });
        context.SaveChanges();
    

        var unitOfWorkMock = new Mock<IUnitOfWork>();
        var lotRepository = new LotRepository(context);

        // Act
        var result = await lotRepository.GetFirstOrDefault(filter: lot => lot.Name == "Lot 2", sorts: null, include: null, disableTracking: true);

        // Assert
        Assert.Equal("Lot 2", result?.Name);
    }

    // Add more test methods as needed...
}
