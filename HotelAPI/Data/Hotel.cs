using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Data
{
    public class Hotel
    {
        public int Id { get; set; } // ukoliko ima id onda je po defaultu PK

        public string Name { get; set; }

        public string Adress { get; set; }

        public double Rating { get; set; }

        [ForeignKey(nameof(Country))] // FK iz klase Country
        public int CountryId { get; set; }

        public Country Country { get; set; }

    }
}
