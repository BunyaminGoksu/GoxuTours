using System;
using System.Collections.Generic;
using System.Text;

namespace GoxuTour.Domain
{
	public class BusManufacturer
	{
		public BusManufacturer(int id,String name)
		{
			Id = id;
			Name = name;
		}
		public int Id { get; set; }	

		public string Name { get; set; }
	}
}
