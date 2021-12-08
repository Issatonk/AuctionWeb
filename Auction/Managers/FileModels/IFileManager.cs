using Auction.Storage.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Managers.FileModels
{
    public interface IFileManager
    {
        Task AddFiles(ICollection<FileModel> files);
        ICollection<FileModel> GetByLotId(Guid lotId);
        void AddFile(FileModel file);
    }
}
