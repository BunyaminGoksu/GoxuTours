using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.BusModels
{
    public class BusModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusManufacturerId { get; set; }
        public Bustype Type { get; set; }
        public int SeatCapacity { get; set; }
        public bool HasToilet { get; set; }
    }
}
