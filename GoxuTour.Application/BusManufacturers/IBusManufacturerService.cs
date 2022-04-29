using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.BusManufacturers
{
    public interface IBusManufacturerService
    {
        IEnumerable<BusManufacturerDTO> GetAll();
        BusManufacturerDTO GetById(int id);
        void Create(BusManufacturerDTO busManufacturerDTO);
        void Update(BusManufacturerDTO busManufacturerDTO);
        void Delete(BusManufacturerDTO busManufacturerDTO);
    }
}
