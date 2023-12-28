using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Exceptions;
using System;

namespace ParkDataLayer.Mapper
{
    public class HuurcontractMapper
    {
        public static Huurcontract ToHuurcontract(HuurcontractEF huurcontractEF)
        {
            try
            {
                return new Huurcontract(
                    huurcontractEF.Id,
                    new Huurperiode(huurcontractEF.StartDatum, huurcontractEF.Aantaldagen),
                    HuurderMapper.ToHuurder(huurcontractEF.Huurder),
                    HuisMapper.ToHuis(huurcontractEF.Huis)
                );
            }
            catch (MapperException ex) 
            {
                throw new MapperException("Error mapping HuurcontractEF to Huurcontract.", ex);
            }
        }

        public static HuurcontractEF ToHuurcontractEF(Huurcontract huurcontract)
        {
            try
            {
                return new HuurcontractEF()
                {
                    Id = huurcontract.Id,
                    StartDatum = huurcontract.Huurperiode.StartDatum,
                    EindDatum = huurcontract.Huurperiode.EindDatum,
                    Aantaldagen = huurcontract.Huurperiode.Aantaldagen,
                    Huurder = HuurderMapper.ToHuurderEF(huurcontract.Huurder),
                    Huis = HuisMapper.ToHuisEF(huurcontract.Huis),
                };
            }
            catch (MapperException ex) 
            {
                throw new MapperException("Error mapping Huurcontract to HuurcontractEF.", ex);
            }
        }
    }
}
