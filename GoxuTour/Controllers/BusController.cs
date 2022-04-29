using GoxuTour.Application.Buses;
using GoxuTour.Application.BusModels;
using Microsoft.AspNetCore.Mvc;

namespace GoxuTour.Presentation.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;
        private readonly IBusModelService _busModelService;

        public BusController(IBusService busService, IBusModelService busModelService)
        {
            _busService = busService;
            _busModelService = busModelService;
        }

        public IActionResult Index()
        {
            var bus = _busService.GetAll();
            var busModels = _busModelService.GetAll();
            ViewBag.BusModelsList = busModels;

            return View(bus);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var busModel = _busModelService.GetAll();
            ViewBag.busModelList = busModel;
            return View();
        }

        [HttpPost]
        public IActionResult Create(BusDTO busDTO)
        {
            _busService.Create(busDTO);
            return RedirectToAction("Index");
        }

        public IActionResult GetById(int id)         
        {
            var bus = _busService.GeyById(id);
            return View(bus);
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var bus = _busService.GeyById(id);

            var busModel = _busModelService.GetAll();
            ViewBag.busModelList = busModel;

            return View(bus); ;
        }
        

        [HttpPost]
        public IActionResult Update(BusDTO busDTO)
        {

            if (busDTO != null)
            {
                _busService.Update(busDTO);

                return RedirectToAction("Index");

            }

            return Content("Güncellenemedi.");

        }

        public IActionResult Delete(BusDTO busDTO) {

            var bus = _busService.GeyById(busDTO.Id);
            _busService.Delete(bus);

            return RedirectToAction("Index");

        }
    }
}
