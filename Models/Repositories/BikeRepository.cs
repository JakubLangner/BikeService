using BikeService.Models.Database;
using BikeService.Models.Enums;
using BikeService.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly DatabaseContext _context;

        public BikeRepository(DatabaseContext context)
        {
            _context = context;
        }
        public void AddBike(Bike bike)
        {
            _context.Bikes.Add(bike);
            _context.SaveChanges();
        }

        public void DeleteBike(Bike bike)
        {
            _context.Bikes.Remove(bike);
            _context.SaveChanges();
        }

        public void EditBike(Bike bike)
        {
            _context.Bikes.Update(bike);
            _context.SaveChanges();
        }

        public List<Bike> GetAllBikes()
        {
            return _context.Bikes.ToList();
        }

        public Bike GetBike(int id)
        {
            return _context.Bikes.FirstOrDefault(x => x.BikeId == id);
        }

        public List<Bike> GetBikesInService()
        {
            return _context.Bikes.Where(x => x.BikeStatus == BikeStatus.InService.ToString()).ToList();
        }

        public List<Bike> GetBikesWithoutFaults()
        {
            return _context.Bikes.Where(x => x.BikeStatus == BikeStatus.ReadyToGo.ToString()).ToList();
        }
    }
}
