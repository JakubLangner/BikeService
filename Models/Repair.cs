using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Repair
    {
        public int RepairId { get; set; }
        public int BikeId { get; set; }
        public int UserId { get; set; }
        public TimeSpan timeSpan { get; set; }
        public string DefectDescription { get; set; }
        public string Note { get; set; }
        public string RepairStatus { get; set; }

    }
}
