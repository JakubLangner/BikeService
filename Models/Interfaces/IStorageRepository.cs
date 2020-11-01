using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Interfaces
{
    public interface IStorageRepository
    {
        public List<Storage> GetAllParts();
        public Storage GetPart(int id);
        public void AddPart(Storage part);
        public void EditPart(Storage part);
        public void DeletePart(Storage part);

    }
}
