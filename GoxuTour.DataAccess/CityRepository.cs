using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using GoxuTour.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoxuTour.DataAccess
{
    public class CityRepository : ICityRepository
    {
        public void Create(City city)
        {
            var dbContext = new GoxuTourDbContext();
             dbContext.Cities.Add(city);
             dbContext.SaveChanges();    
        }

        public void Delete(City city)
        {
            var dbContext = new GoxuTourDbContext();
             var cityEntity= dbContext.Cities.Find(city.Id);
            dbContext.Cities.Remove(cityEntity);
            dbContext.SaveChanges();

        }

        public IEnumerable<City> GetAll()
        {
            var DbContext = new GoxuTourDbContext();
            return DbContext.Cities.ToList();
        }

        public City GetById(int id)
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.Cities.Find(id);
        }

        public void Update(City city)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.Cities.Update(city);
            dbContext.SaveChanges();

        }
    }
}
