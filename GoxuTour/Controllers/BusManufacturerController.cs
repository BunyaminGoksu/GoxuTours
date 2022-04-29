using GoxuTour.Application.BusManufacturers;
using Microsoft.AspNetCore.Mvc;

namespace GoxuTour.Presentation.Controllers
{
    public class BusManufacturerController : Controller
    {
        private readonly IBusManufacturerService _busManufacturerService;

        public BusManufacturerController(IBusManufacturerService busManufacturerService)
        {
            _busManufacturerService = busManufacturerService;
        }

        public IActionResult Index()
        {
            var busManu = _busManufacturerService.GetAll();
            return View(busManu);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(BusManufacturerDTO busManufacturerDTO)
        {
            if (busManufacturerDTO != null)
            {
                _busManufacturerService.Create(busManufacturerDTO);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "Boş gönderemezsiniz!!";
                return View();
            }

        }

        public IActionResult GetById(int id)
        {
          var busManu=  _busManufacturerService.GetById(id);
            return View(busManu);

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var busManu = _busManufacturerService.GetById(id);
            
            return View(busManu);
        }

        [HttpPost]
        public IActionResult Update(BusManufacturerDTO busManufacturerDTO)
        {
            if(busManufacturerDTO != null)
            {
                var busManu = new BusManufacturerDTO()
                {
                    Id = busManufacturerDTO.Id,
                    Name = busManufacturerDTO.Name
                };
                _busManufacturerService.Update(busManu);
                return RedirectToAction("Index");

            }
            return Content("Hatalı İşlem");

        }

        public IActionResult Delete(BusManufacturerDTO busManufacturerDTO)
        {
            if(busManufacturerDTO != null)
            {
                var busManu = _busManufacturerService.GetById(busManufacturerDTO.Id);
                _busManufacturerService.Delete(busManu);
                return RedirectToAction("Index");
            }
            return Content("Silinecek kayıt bulunamadı");
        }
    }
}
