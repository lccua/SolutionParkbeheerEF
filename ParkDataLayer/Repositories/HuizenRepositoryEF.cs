using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Context;
using ParkDataLayer.Exceptions;
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
                                       .Include(h => h.Park)  // Include the related Park
                                       .Where(c => c.Id == id)
                                       .Select(huisEF => HuisMapper.ToHuis(huisEF))
                                       .FirstOrDefault();

                return huis;
            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuizenRepositoryEF: GeefHuis", ex);

            }

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return _context.Huizen.Any(     h => h.Straat == straat 
                                             && h.Nr == nummer 
                                             && h.Park.Id == park.Id);

            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuizenRepositoryEF: HeeftHuis", ex);

            }
        }


        public bool HeeftHuis(int id)
        {
            try
            {
                return _context.Huizen.Any(h => h.Id == id);

            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuizenRepositoryEF: HeeftHuis", ex);

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
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuizenRepositoryEF: UpdateHuis", ex);

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

                // If an ID is provided, use it; otherwise, let the database generate it.
                if (huis.Id <= 0)
                {
                    // ID is not provided or is 0; let the database generate it.
                    _context.Huizen.Add(huisEF);
                }
                else
                {
                    // ID is provided; add the entity with the given ID.
                    _context.Huizen.Add(huisEF);
                    _context.Entry(huisEF).State = EntityState.Added; // Explicitly mark as added.
                }

                _context.SaveChanges();
                _context.Entry(huisEF).State = EntityState.Detached;


            }
            catch (RepositoryException ex)
            {
                throw new RepositoryException("HuizenRepositoryEF: VoegHuisToe", ex);

            }
        }
    }
}
