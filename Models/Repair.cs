using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Repair
    {
        [Key]
        public int RepairId { get; set; }
        public virtual int BikeId { get; set; }
        public virtual Bike Bike { get; set; }
        public virtual string UserId { get; set; }
        public virtual AppUser User { get; set; }
        public virtual int? PartId { get; set; }
        public virtual Parts Part { get; set; }
        public TimeSpan timeSpan { get; set; }
        public string DefectDescription { get; set; }
        public string Note { get; set; }
        public string RepairStatus { get; set; }

    }
}
