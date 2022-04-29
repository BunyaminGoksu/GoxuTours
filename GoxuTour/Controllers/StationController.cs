using GoxuTour.Application.Cities;
using GoxuTour.Application.Stations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace GoxuTour.Presentation.Controllers
{
    public class StationController : Controller
    {
        private readonly IStationService _stationService;
        private readonly ICityService _cityService;

        public StationController(IStationService stationService, ICityService cityService)
        {
            _stationService = stationService;
            _cityService = cityService;

        }

        public IActionResult Index(bool redirected)
        {
            var stations = _stationService.GetAll();
            if (!redirected)
            {
                TempData.Remove("CommandResult");
            }
            var citys = _cityService.GetAll();
            ViewBag.CityList = citys;
            return View(stations);
        }

        public IActionResult Create()
        {
            var cities = _cityService.GetAll();
            ViewBag.CityList = new SelectList(cities, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(StationDTO stationDTO)
        {
            var result = _stationService.Create(stationDTO);


            if (result.IsSucceeded)
            {
                var jsonResult = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = jsonResult;
                return RedirectToAction("Index","Station",new { redirected = true});
            }
            else
            {
                var cities = _cityService.GetAll();
                
                ViewBag.CityList = new SelectList(cities, "Id", "Name");

                ViewBag.CommandMessage = result;

                return View();
            }

        }

        public IActionResult GetById(StationDTO stationDTO)
        {
            var station = _stationService.GetById(stationDTO.Id);
            return View(station);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var station = _stationService.GetById(id);
            var cities = _cityService.GetAll();
            ViewBag.CityList = new SelectList(cities, "Id", "Name");
            return View(station);
        }

        [HttpPost]
        public IActionResult Update(StationDTO stationDTO)
        { 
            var result = _stationService.Update(stationDTO);
			if (result.IsSucceeded)
			{
               
                TempData["CommandResult"] = JsonConvert.SerializeObject(result);

                return RedirectToAction("Index");
			}
			else
			{
                ViewBag.CommandMessage = result;
                return View();
			}
        }

        public IActionResult Delete(StationDTO stationDTO)
        {
            if (stationDTO != null)
            {

                var station = _stationService.GetById(stationDTO.Id);
                _stationService.Delete(stationDTO);
                return RedirectToAction("Index");
            }

            return Content("Station Bulunamadı");

        }

        public IActionResult GetByCityId(int cityId)
		{
            var allStations = _stationService.GetAll();

            var stationsByCity = allStations.Where(s => s.CityId == cityId).ToList();

            return Json(stationsByCity);
		}
    }
}
