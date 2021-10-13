﻿using HotelAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sandal Resort and Spa",
                    Adress = "Negril",
                    CountryId = 1,
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Grand Palldium",
                    Adress = "Nassua",
                    CountryId = 2,
                    Rating = 4
                },
                   new Hotel
                   {
                       Id = 3,
                       Name = "Hotel Grof Drakula",
                       Adress = "Tranasilvania",
                       CountryId = 3,
                       Rating = 4.8
                   });
        }
    }
}
