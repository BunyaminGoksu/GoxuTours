using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Cities
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public  CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public CommandResult Create(CityDTO cityDTO)
        {
            try
            {
                var city = new City()

                {
                    Id = cityDTO.Id,
                    Name = cityDTO.Name
                };
                _cityRepository.Create(city);
                //return new CommandResult()
                //{
                //    IsSucceeded = true
                //};
                return CommandResult.Success("Başarılı");

            }
            catch (Exception Ex)
            {

                //var result =  new CommandResult()
                //{
                //    IsSucceeded = false
                //};
                return CommandResult.Error("Ekleme işlemi sırasında hata meydana geldi");
            }
          
        }

        public CommandResult Delete(CityDTO cityDTO)
        {
            try
            {
                if (cityDTO != null)
                {
                    var city = new City()
                    {
                        Id = cityDTO.Id,
                        Name = cityDTO.Name
                    };

                    _cityRepository.Delete(city);
                }

                return CommandResult.Success("Silme işlemi başarılı");

            }
            catch (Exception ex)
            {

                return CommandResult.Error("Silme işlemi sırasında hata meydana geldi",ex.Message);

            }
             

                
            
        }

        public IEnumerable<CityDTO> GetAll()
        {
           var cityEnties = _cityRepository.GetAll();
           var cityDTOs = new List<CityDTO>();
            foreach (var entity in cityEnties)
            {
                cityDTOs.Add(new CityDTO()
                {
                    Id = entity.Id,
                    Name = entity.Name
                });
            }
            return cityDTOs;
        }

        public CityDTO GetById(int id)
        {
            var city = _cityRepository.GetById(id);
            if(city != null)
            {
                var cityDTO = new CityDTO()
                {
                    Id = city.Id,
                    Name = city.Name
                };
                return cityDTO;
            }
            else
            {
                return null;
            }
        }

        public CommandResult Update(CityDTO cityDTO)
        {
            try
            {
                var cityDTOs = _cityRepository.GetById(cityDTO.Id);
                cityDTOs.Name = cityDTO.Name;


                _cityRepository.Update(cityDTOs);
                return CommandResult.Success("Başarılı");
            }
            catch (Exception ex)
            {
                return CommandResult.Error("Güncelleme işlemi gerçekleştirilirken hata meydana geldi.");
            }
           

        }

     
    }
}
