﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Models
{
    public class HotelDTO : CreateHotelDTO
    {
        public int Id { get; set; } // ukoliko ima id onda je po defaultu PK
        public CountryDTO Country { get; set; }

    }

    public class CreateHotelDTO
    {

        [Required]
        [StringLength(maximumLength: 150, ErrorMessage = "Too long")]

        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 250, ErrorMessage = "Too long")]

        public string Adress { get; set; }
        [Required]
       [Range(1,5)]
        public double Rating { get; set; }
        
        [Required]
        public int CountryId { get; set; }

    }

}