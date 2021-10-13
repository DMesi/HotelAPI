using HotelAPI.Data;
using HotelAPI.IRepository;
using HotelAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBase _context;

        private IGenericRepositroy<Country> _countries;
        private IGenericRepositroy<Hotel> _hotels;
        public UnitOfWork(DataBase context)
        {
            _context = context;
        }
        public IGenericRepositroy<Country> Countries => _countries ??= new GenericRepositroy<Country>(_context);

        public IGenericRepositroy<Hotel> Hotels => _hotels ??= new GenericRepositroy<Hotel>(_context);

       

        public void Dispose()
        {
         
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
