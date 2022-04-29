using GoxuTour.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Application.Buses
{
    public class BusDTO
    {
        public int Id { get; set; }

        public int BusModelId { get; set; }

        public string RegistrationPlate { get; set; }

        public short Year { get; set; }
        public int SeatCount { get; set; }

        public SeatingType SeatMapping { get; set; }


        public int DistanceTraveled { get; set; }
    }
}
