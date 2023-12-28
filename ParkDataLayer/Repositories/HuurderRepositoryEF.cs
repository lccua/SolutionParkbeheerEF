using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Context;
using ParkDataLayer.Exceptions;
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
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuurderRepositoryEF: GeefHuurder", ex);

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
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuurderRepositoryEF: GeefHuurders", ex);

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
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuurderRepositoryEF: HeeftHuurder", ex);

            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return _context.Huurders.Any(h => h.Id == id);

            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuurderRepositoryEF: HeeftHuurder", ex);

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
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuurderRepositoryEF: UpdateHuurder", ex);

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

                // If an ID is provided, use it; otherwise, let the database generate it.
                if (huurder.Id <= 0)
                {
                    // ID is not provided or is 0; let the database generate it.
                    _context.Huurders.Add(huurderEF);
                }
                else
                {
                    // ID is provided; add the entity with the given ID.
                    _context.Huurders.Add(huurderEF);
                }


                _context.SaveChanges();

            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuurderRepositoryEF: VoegHuurderToe", ex);

            }
        }
    }
}
