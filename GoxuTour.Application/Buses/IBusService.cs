using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Buses
{
    public interface IBusService
    {
        IEnumerable<BusDTO> GetAll();

        BusDTO GeyById(int id);

        void Create(BusDTO busDTO);

        void Update(BusDTO busDTO);

        void Delete(BusDTO busDTO);

    }
}
