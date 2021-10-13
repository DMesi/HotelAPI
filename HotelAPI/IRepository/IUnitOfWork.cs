using HotelAPI.Data;
using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {

        IGenericRepositroy<Country> Countries { get; }
        IGenericRepositroy<Hotel> Hotels { get; }
        Task Save();

    }
}
