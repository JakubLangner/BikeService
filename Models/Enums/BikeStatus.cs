using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Models.Enums
{
    public enum BikeStatus
    {
        [Display(Name ="W serwisie")]
        InService,
        [Display(Name ="Do naprawy")]
        ForRepair,
        [Display(Name ="Gotowy do wyjazdu")]
        ReadyToGo
    }
}
