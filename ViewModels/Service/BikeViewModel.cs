using BikeService.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.ViewModels.Service
{
    public class BikeViewModel
    {
        [Key]
        public int BikeId { get; set; }
        [Display(Name="Data przyjęcia roweru")]
        public DateTime YearOfProduction { get; set; }
        [Display(Name = "Typ roweru")]
        public string BikeType { get; set; }
        [Display(Name = "Kondycja roweru")]
        public string TechnicalCondition { get; set; }
        [Display(Name = "Przeznaczenie")]
        public string BikeDestiny { get; set; }
        [Display(Name = "Kampania reklamowa")]
        public string CurrentAdvertisingCampaign { get; set; }
        [Display(Name = "Status roweru")]
        public BikeStatus BikeStatus { get; set; }
    }
}
