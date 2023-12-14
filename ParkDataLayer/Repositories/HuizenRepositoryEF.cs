using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Context;
using ParkDataLayer.Mapper;
using ParkDataLayer.Model;
using System;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        private readonly ParkbeheerContext _context;

        public HuizenRepositoryEF(ParkbeheerContext context)
        {
            _context = context;
        }

        public Huis GeefHuis(int id)
        {
            try
            {
                var huis = _context.Huizen
                           .Where(c => c.Id == id)
                           .Select(huisEF => HuisMapper.ToHuis(huisEF))
                           .FirstOrDefault();

                return huis;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return _context.Huizen.Any(h => h.Straat == straat && h.Nr == nummer && h.Park.Id == park.Id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }           
        }


        public bool HeeftHuis(int id)
        {
            try
            {
                return _context.Huizen.Any(h => h.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateHuis(Huis huis)
        {
            if (huis == null)
            {
                throw new ArgumentNullException(nameof(huis), "Huis cannot be null");
            }

            try
            {
                HuisEF huisEF = HuisMapper.ToHuisEF(huis);

                var existingHuis = _context.Huizen.FirstOrDefault(h => h.Id == huisEF.Id);

                if (existingHuis == null)
                {
                    throw new InvalidOperationException("Huis not found in the database.");
                }

                _context.Entry(existingHuis).CurrentValues.SetValues(huisEF);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void VoegHuisToe(Huis huis)
        {
            if (huis == null)
            {
                throw new ArgumentNullException(nameof(huis), "Huis cannot be null");
            }

            try
            {
                HuisEF huisEF = HuisMapper.ToHuisEF(huis);

                _context.Huizen.Add(huisEF);

                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
