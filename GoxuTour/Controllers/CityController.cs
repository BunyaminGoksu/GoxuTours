using GoxuTour.Application.Cities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;

namespace GoxuTour.Presentation.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult Index()
        {
            var cities = _cityService.GetAll();
            return View(cities);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(CityDTO city)
        {

            var result = _cityService.Create(city);
            if (result.IsSucceeded)
            {
                //Serialize => Stringleştirme
                var resultJson = JsonConvert.SerializeObject(result);
                TempData["CommandResult"] = resultJson;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CommandResult = result;
                return View();
            }

        }
        public IActionResult GetById(int id)
        {
            var city = _cityService.GetById(id);
            return View(city);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var city = _cityService.GetById(id);
            return View(city);
        }

        [HttpPost]
        public IActionResult Update(CityDTO city)
        {
            {
                var result = _cityService.Update(city);
                if (result.IsSucceeded)
                {

                    var jsonResult = JsonConvert.SerializeObject(result);
                    TempData["CommandResult"] = jsonResult;

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CommandMessage = result;
                    return View();
                }
            }
        }
        public IActionResult Delete(CityDTO cityDTO)
        {

            var city = _cityService.GetById(cityDTO.Id);

            var result = _cityService.Delete(city);

            if (result.IsSucceeded)
            {
                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.CommandMessage = result;
                return RedirectToAction("Index");
            }
        }
    }
}