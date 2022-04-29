using GoxuTour.Application.Repositories;
using GoxuTour.Domain;
using GoxuTour.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoxuTour.DataAccess
{
    public class BusRepository : IBusRepository
    {
        public void Create(Bus bus)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.buses.Add(bus);
            dbContext.SaveChanges();
        }

        public void Delete(Bus bus)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.buses.Remove(bus);
            dbContext.SaveChanges();
        }

        public IEnumerable<Bus> GetAll()
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.buses
                .Include("BusModel")
                .ToList();
        }

        public Bus GetById(int id)
        {
            var dbContext = new GoxuTourDbContext();
            return dbContext.buses.Find(id);
        }

        public void Update(Bus bus)
        {
            var dbContext = new GoxuTourDbContext();
            dbContext.buses.Update(bus);
            dbContext.SaveChanges();

        }
    }
}
