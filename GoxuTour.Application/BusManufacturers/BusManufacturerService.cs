using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.BusManufacturers
{
    public class BusManufacturerService : IBusManufacturerService
    {
        private readonly IBusManufacturerRepository _busManufacturerRepository;

        public BusManufacturerService(IBusManufacturerRepository busManufacturerRepository)
        {
            _busManufacturerRepository = busManufacturerRepository;
        }

        public void Create(BusManufacturerDTO busManufacturerDTO)
        {
            var busManufacturer = new BusManufacturer(busManufacturerDTO.Id,busManufacturerDTO.Name);
            
            _busManufacturerRepository.Create(busManufacturer);

        }

        public void Delete(BusManufacturerDTO busManufacturerDTO)
        {
            var busManu = _busManufacturerRepository.GetById(busManufacturerDTO.Id);


            var busManuDTO = new BusManufacturer(busManufacturerDTO.Id,busManufacturerDTO.Name);

            _busManufacturerRepository.Delete(busManuDTO);
        }

        public IEnumerable<BusManufacturerDTO> GetAll()
        {
            var busManu = _busManufacturerRepository.GetAll();
            var busManuDTOs = new List<BusManufacturerDTO>();
            foreach (var bus in busManu)
            {
                busManuDTOs.Add(new BusManufacturerDTO()
                {
                    Id = bus.Id,
                    Name = bus.Name
                });
            }
            return busManuDTOs;

        }

        public BusManufacturerDTO GetById(int id)
        {
            var busManu = _busManufacturerRepository.GetById(id);
            
            if(busManu != null)
            {
                var busManuDTO = new BusManufacturerDTO()
                {
                    Name = busManu.Name,
                    Id = busManu.Id
                };
                return busManuDTO;
            }
            else
            {
                return null;
            }

        }


        public void Update(BusManufacturerDTO busManufacturerDTO)
        {
            var busManu = _busManufacturerRepository.GetById(busManufacturerDTO.Id);

            busManu.Id = busManufacturerDTO.Id;
            busManu.Name = busManufacturerDTO.Name;

            _busManufacturerRepository.Update(busManu);
            
          
        }
    }
}
