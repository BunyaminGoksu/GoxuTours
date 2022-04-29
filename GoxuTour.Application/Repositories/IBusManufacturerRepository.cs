using GoxuTour.Application.BusManufacturers;
using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Repositories
{
    public interface IBusManufacturerRepository
    {
        IEnumerable<BusManufacturer> GetAll();
        BusManufacturer GetById(int id);

        void Create(BusManufacturer busManufacturer);

        void Update(BusManufacturer busManufacturer);   

        void Delete(BusManufacturer busManufacturer);
    }
}
