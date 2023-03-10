using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public string PartDescription { get; set; }
        public int Quantity { get; set; }
        public string BikeType { get; set; }
        public string PartName { get; set; }
        public string BikeAdvertisements { get; set; }
    }
}
