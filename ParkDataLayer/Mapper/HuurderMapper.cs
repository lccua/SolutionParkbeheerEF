using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Exceptions;
using System;

namespace ParkDataLayer.Mapper
{
    public class HuurderMapper
    {
        public static Huurder ToHuurder(HuurderEF huurderEF)
        {
            try
            {
                return new Huurder(
                    huurderEF.Id,
                    huurderEF.Naam,
                    new Contactgegevens(huurderEF.Email, huurderEF.Tel, huurderEF.Adres)
                );
            }
            catch (Exception ex) 
            {
                throw new MapperException("Error mapping HuurderEF to Huurder.", ex);
            }
        }

        public static HuurderEF ToHuurderEF(Huurder huurder)
        {
            try
            {
                return new HuurderEF()
                {
                    Id = huurder.Id,
                    Naam = huurder.Naam,
                    Email = huurder.Contactgegevens.Email,
                    Tel = huurder.Contactgegevens.Tel,
                    Adres = huurder.Contactgegevens.Adres
                };
            }
            catch (Exception ex) 
            {
                throw new MapperException("Error mapping Huurder to HuurderEF.", ex);
            }
        }
    }
}
