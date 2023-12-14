using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mapper
{
    public class HuurderMapper
    {
        public static Huurder ToHuurder(HuurderEF huurderEF)
        {
            return new Huurder(huurderEF.Id, huurderEF.Naam, new Contactgegevens(huurderEF.Email, huurderEF.Tel, huurderEF.Adres));
        }

        public static HuurderEF ToHuurderEF(Huurder huurder)
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
    }
}
