using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.BusModels
{
    public interface IBusModelService
    {


        IEnumerable<BusModelDTO> GetAll();

        BusModelDTO GetById(int id);

        void  Create(BusModelDTO busModelDTO);

        void Update(BusModelDTO busModelDTO);

        void Delete(BusModelDTO busModelDTO);


    }
}
