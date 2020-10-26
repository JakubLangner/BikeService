using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Bike
    {
        [Key]
        public int BikeId { get; set; }
        public DateTime YearOfProduction { get; set; }
        public string BikeType { get; set; }
        public string TechnicalCondition { get; set; }
        public string BikeDestiny { get; set; }
        public string CurrentAdvertisingCampaign { get; set; }
    }
}
