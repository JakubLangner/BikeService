using BikeService.Models.Database;
using BikeService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Repositories
{
    public class StorageRepository : IStorageRepository
    {
        private readonly DatabaseContext _context;

        public StorageRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddPart(Storage part)
        {
            _context.Storage.Add(part);
            _context.SaveChanges();
        }

        public void DeletePart(Storage part)
        {
            _context.Storage.Remove(part);
            _context.SaveChanges();
        }

        public void EditPart(Storage part)
        {
            _context.Storage.Update(part);
            _context.SaveChanges();
        }

        public List<Storage> GetAllParts()
        {
            return _context.Storage.ToList();
        }

        public Storage GetPart(int id)
        {
            return _context.Storage.FirstOrDefault(x => x.StorageId == id);
        }


    }
}
