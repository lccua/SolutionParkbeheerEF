using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Context;
using ParkDataLayer.Mapper;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private readonly ParkbeheerContext _context;

        public HuurderRepositoryEF(ParkbeheerContext context)
        {
            _context = context;
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
                var huurder = _context.Huurders
                           .Where(c => c.Id == id)
                           .Select(huurderEF => HuurderMapper.ToHuurder(huurderEF))
                           .FirstOrDefault();

                return huurder;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                var huurders = _context.Huurders
                               .Where(h => h.Naam == naam)
                               .Select(huurderEF => HuurderMapper.ToHuurder(huurderEF))
                               .ToList();

                return huurders;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return _context.Huurders.Any(   h => h.Naam == naam
                                             && h.Adres == contact.Adres
                                             && h.Email == contact.Email);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return _context.Huurders.Any(h => h.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            if (huurder == null)
            {
                throw new ArgumentNullException(nameof(huurder), "huurder cannot be null");
            }

            try
            {
                HuurderEF huurderEF = HuurderMapper.ToHuurderEF(huurder);

                var existingHuurder = _context.Huurders.FirstOrDefault(h => h.Id == huurderEF.Id);

                if (existingHuurder == null)
                {
                    throw new InvalidOperationException("Huurder not found in the database.");
                }

                _context.Entry(existingHuurder).CurrentValues.SetValues(huurderEF);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void VoegHuurderToe(Huurder huurder)
        {
            if (huurder == null)
            {
                throw new ArgumentNullException(nameof(huurder), "Huurder cannot be null");
            }

            try
            {
                HuurderEF huurderEF = HuurderMapper.ToHuurderEF(huurder);

                _context.Huurders.Add(huurderEF);

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
