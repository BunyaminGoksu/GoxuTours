using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Stations
{
    public interface IStationService
    {
        public IEnumerable<StationDTO> GetAll();

        StationDTO GetById(int id);

        CommandResult Create(StationDTO stationDTO);

        CommandResult Update(StationDTO stationDTO);

        void Delete(StationDTO stationDTO);
    }
}
