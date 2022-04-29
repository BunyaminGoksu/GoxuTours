using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.BusModels
{
    public class BusModelService : IBusModelService
    {
        private readonly IBusModelRepository _busModelRepository;

        public BusModelService(IBusModelRepository busModelRepository)
        {
            _busModelRepository = busModelRepository;
        }

        public void Create(BusModelDTO busModelDTO)
        {
            var busModel = new BusModel(busModelDTO.Id, busModelDTO.Name, busModelDTO.BusManufacturerId, busModelDTO.Type, busModelDTO.SeatCapacity, busModelDTO.HasToilet);

            _busModelRepository.Create(busModel);
           
            
        }

        public void Delete(BusModelDTO busModelDTO)
        {
            var busModel = _busModelRepository.GetById(busModelDTO.Id);
            _busModelRepository.Delete(busModel);

        }

        public IEnumerable<BusModelDTO> GetAll()
        {
            var busModel = _busModelRepository.GetAll();
            var busModelDTOs = new List<BusModelDTO>();
            foreach (var bus in busModel)
            {
                busModelDTOs.Add(new BusModelDTO()
                {
                    Id = bus.Id,
                    Name = bus.Name,
                    BusManufacturerId = bus.BusManufacturerId,
                    Type = bus.Type,
                    SeatCapacity = bus.SeatCapacity,
                    HasToilet = bus.HasToilet
                });
            }
            return busModelDTOs;
        }

        public BusModelDTO GetById(int id)
        {

            var busModel = _busModelRepository.GetById(id);
            if(busModel != null)
			{
                var busModelDTO = new BusModelDTO()
                {
                    Id = busModel.Id,
                    Name = busModel.Name,
                    BusManufacturerId = busModel.BusManufacturerId,
                    Type = busModel.Type,
                    SeatCapacity = busModel.SeatCapacity,
                    HasToilet = busModel.HasToilet
                };
                return busModelDTO;
			}
            return null;

        }

        public void Update(BusModelDTO busModelDTO)
        {
            var busModel = _busModelRepository.GetById(busModelDTO.Id);

            busModel.Id = busModelDTO.Id;
            busModel.Name = busModelDTO.Name;

			
            _busModelRepository.Update(busModel);
        }
    }
}
