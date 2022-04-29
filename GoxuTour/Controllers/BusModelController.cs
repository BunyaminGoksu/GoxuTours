using GoxuTour.Application.BusManufacturers;
using GoxuTour.Application.BusModels;
using GoxuTour.Domain;
using Microsoft.AspNetCore.Mvc;

namespace GoxuTour.Presentation.Controllers
{
    public class BusModelController : Controller
    {
        private readonly IBusModelService _busModelService;
        private readonly IBusManufacturerService _busManufacturerService;
        public BusModelController(IBusModelService busModelService, IBusManufacturerService busManufacturerService)
        {
            _busModelService = busModelService;
            _busManufacturerService = busManufacturerService;
        }

        public IActionResult Index()
        {
            var busModel = _busModelService.GetAll();
            var busManu = _busManufacturerService.GetAll();
            ViewBag.BusManuList = busManu;

            return View(busModel);
        }
        public IActionResult Create()
        {
            var busManu = _busManufacturerService.GetAll();
            ViewBag.BusManuList = busManu;



            return View();
        }

        [HttpPost]
        public IActionResult Create(BusModelDTO busModelDTO)
        { 
            _busModelService.Create(busModelDTO);
            return RedirectToAction("Index");
        }

        public IActionResult GeById(int id)
		{
            _busManufacturerService.GetById(id);
            return View();
		}

        [HttpGet]
        public IActionResult Update(int id)
		{
            var busModel = _busModelService.GetById(id);


            return View(busModel);
		}
       
        [HttpPost]
        public IActionResult Update(BusModelDTO busModelDTO)           
		{
          
            _busModelService.Update(busModelDTO);
            return RedirectToAction("Index");
		}
        public IActionResult Delete(BusModelDTO busModelDTO)
		{
            var busModel = _busModelService.GetById(busModelDTO.Id);
            
            _busModelService.Delete(busModel);
            return RedirectToAction("Index");
		}
    }
}
