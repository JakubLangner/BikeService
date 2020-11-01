using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Interfaces
{
    public interface IBikeRepository
    {
        public List<Bike> GetAllBikes();
        public Bike GetBike(int id);
        public void AddBike(Bike bike);
        public void EditBike(Bike bike);
        public void DeleteBike(Bike bike);

        public List<Bike> GetBikesInService();
        public List<Bike> GetBikesWithoutFaults();
    }
}
