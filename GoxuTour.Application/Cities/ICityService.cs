using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Cities
{
    public interface ICityService
    {
        IEnumerable<CityDTO> GetAll();

        CityDTO GetById(int id);

        CommandResult Create(CityDTO cityDTO);

        CommandResult Update(CityDTO cityDTO);

        CommandResult Delete(CityDTO cityDTO);
    }
}
