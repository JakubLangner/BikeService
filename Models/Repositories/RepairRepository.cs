using BikeService.Models.Database;
using BikeService.Models.Enums;
using BikeService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly DatabaseContext _context;

        public RepairRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddRepair(Repair repair)
        {
            _context.Repairs.Add(repair);
            _context.SaveChanges();
        }

        public void DeleteRepair(Repair repair)
        {
            _context.Repairs.Remove(repair);
            _context.SaveChanges();
        }

        public void EditRepair(Repair repair)
        {
            _context.Repairs.Update(repair);
            _context.SaveChanges();
        }

        public Repair GetRepair(int id)
        {
            return _context.Repairs.FirstOrDefault(x => x.RepairId == id);
        }

        public List<Repair> GetRepairs()
        {
            return _context.Repairs.ToList();
        }

        public List<Repair> GetRepairsByPriority(string priority)
        {
            return _context.Repairs.Where(x => x.RepairPriority == priority).ToList();
        }

        public List<Repair> GetRepairsByStatus(string status)
        {
            return _context.Repairs.Where(x => x.RepairStatus == status).ToList();
        }
    }
}
