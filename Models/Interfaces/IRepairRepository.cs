using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Interfaces
{
    public interface IRepairRepository
    {
        public List<Repair> GetRepairs();
        public Repair GetRepair(int id);
        public void AddRepair(Repair repair);
        public void EditRepair(Repair repair);
        public void DeleteRepair(Repair repair);
        public List<Repair> GetRepairsByStatus(string status);
        public List<Repair> GetRepairsByPriority(string priority);
    }
}
