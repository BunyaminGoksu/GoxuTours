using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Buses
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public void Create(BusDTO busDTO)
        {
            var bus = new Bus(busDTO.Id,busDTO.BusModelId,busDTO.RegistrationPlate,busDTO.Year,busDTO.SeatMapping,busDTO.DistanceTraveled);

            _busRepository.Create(bus);
            
        }

        public void Delete(BusDTO busDTO)
        {
            var bus = _busRepository.GetById(busDTO.Id);
            _busRepository.Delete(bus);
        }

        public IEnumerable<BusDTO> GetAll()
        {
            var buses = _busRepository.GetAll();
            var busesDTO = new List<BusDTO>();

            foreach (var bus in buses)
            {

                busesDTO.Add(new BusDTO()
                {
                    Id = bus.Id,
                    BusModelId = bus.BusModelId,
                    RegistrationPlate = bus.RegistrationPlate,
                    Year = bus.Year,
                    SeatMapping=bus.SeatMapping,
                    DistanceTraveled = bus.DistanceTraveled,
                    SeatCount = bus.SeatCount

                });
            }
            return busesDTO;
        }

        public BusDTO GeyById(int id)
        {
            var bus = _busRepository.GetById(id);

            if(bus != null)
            {

                var busDTOs = new BusDTO()
                {
                    Id = bus.Id,
                    BusModelId = bus.BusModelId,
                    Year = bus.Year,
                    RegistrationPlate = bus.RegistrationPlate,
                    DistanceTraveled = bus.DistanceTraveled,
                    SeatMapping = bus.SeatMapping
                };
                return busDTOs;
            }
            return null;
        }

        public void Update(BusDTO busDTO)
        {
            var bus = _busRepository.GetById(busDTO.Id);

            if(bus!= null)
            {
                bus.Id= busDTO.Id;
                bus.SeatMapping = busDTO.SeatMapping;
                bus.DistanceTraveled = busDTO.DistanceTraveled;
            }
            _busRepository.Update(bus);
        }
    }
}
