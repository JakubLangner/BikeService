using BikeService.Models;
using BikeService.Models.Enums;
using BikeService.Models.Interfaces;
using BikeService.ViewModels.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IBikeRepository _bikeRepository;

        public ServiceController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }
        public IActionResult Card()
        {
            return View();
        }
        public IActionResult AllBikes()
        {
            return View(_bikeRepository.GetAllBikes());
        }
        [HttpGet]
        public IActionResult CreateBike()
        {
                return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateBike(BikeViewModel model)
        {
            Bike bike = new Bike();
            bike.YearOfProduction = model.YearOfProduction;
            bike.BikeDestiny = model.BikeDestiny;
            bike.BikeType = model.BikeType;
            bike.CurrentAdvertisingCampaign = model.CurrentAdvertisingCampaign;
            bike.TechnicalCondition = model.TechnicalCondition;
            bike.BikeStatus = model.BikeStatus.ToString();
            _bikeRepository.AddBike(bike);
            TempData["AddBike"] = "Dodałeś rower";

            return RedirectToAction("AllBikes", "Service");
        }
        
        [HttpGet]
        public IActionResult ChangeStatus()
        {
            return View();
        }

    }
}
