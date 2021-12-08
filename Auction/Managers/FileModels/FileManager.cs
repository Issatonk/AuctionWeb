using Auction.Storage;
using Auction.Storage.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.FileModels
{
    public class FileManager : IFileManager
    {
        AuctionContext _context;
        public FileManager(AuctionContext context)
        {
            _context = context;
        }
        public ICollection<FileModel> GetByLotId(Guid lotId)
        {
            return _context.FileModel.Where(fm => fm.lotId == lotId).ToList();
        }
        public async Task AddFiles(ICollection<FileModel> files)
        {
            await _context.AddRangeAsync(files);
            await _context.SaveChangesAsync();
        }
        public void AddFile(FileModel file)
        {
            _context.AddAsync(file);
            _context.SaveChangesAsync();
        }
    }
}
