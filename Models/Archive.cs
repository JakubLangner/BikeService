using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models
{
    public class Archive
    {
        [Key]
        public int ArchiveId { get; set; }
        public virtual int RepairId { get; set; }
        public virtual Repair Repair { get; set; }
    }
}
