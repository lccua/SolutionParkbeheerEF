using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Context;
using ParkDataLayer.Mapper;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private readonly ParkbeheerContext _context;

        public ContractenRepositoryEF(ParkbeheerContext context)
        {
            _context = context;
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                HuurcontractEF huurcontractEF = HuurcontractMapper.ToHuurcontractEF(contract);
                _context.Huurcontracten.Remove(huurcontractEF);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                var huurcontract = _context.Huurcontracten
                                           .Where(c => c.Id == id)
                                           .Select(contractEF => HuurcontractMapper.ToHuurcontract(contractEF))
                                           .FirstOrDefault(); 

                return huurcontract;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            try
            {
                var huurcontracten = _context.Huurcontracten
                                     .Where(c => c.StartDatum >= dtBegin && c.StartDatum <= dtEinde.Value)
                                     .Select(contractEF => HuurcontractMapper.ToHuurcontract(contractEF))
                                     .ToList();

                return huurcontracten;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return _context.Huurcontracten.Any(contract =>
                   contract.StartDatum == startDatum &&
                   contract.Huurder.Id == huurderid &&
                   contract.Huis.Id == huisid);
            }
            catch (Exception  ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return _context.Huurcontracten.Any(contract => contract.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract), "Contract cannot be null");
            }

            try
            {
                HuurcontractEF huurcontractEF = HuurcontractMapper.ToHuurcontractEF(contract);

                var existingContract = _context.Huurcontracten.FirstOrDefault(c => c.Id == huurcontractEF.Id);

                if (existingContract == null)
                {
                    throw new InvalidOperationException("Contract not found in the database.");
                }

                _context.Entry(existingContract).CurrentValues.SetValues(huurcontractEF);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public void VoegContractToe(Huurcontract contract)
        {
            if (contract == null)
            {
                throw new ArgumentNullException(nameof(contract), "Contract cannot be null");
            }

            try
            {
                HuurcontractEF huurcontractEF = HuurcontractMapper.ToHuurcontractEF(contract);

                _context.Huurcontracten.Add(huurcontractEF);

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
