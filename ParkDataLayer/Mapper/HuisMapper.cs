using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Exceptions;
using System;

namespace ParkDataLayer.Mapper
{
    public class HuisMapper
    {
        public static Huis ToHuis(HuisEF huisEF)
        {
            try
            {
                return new Huis(huisEF.Id, huisEF.Straat, huisEF.Nr, huisEF.Actief, ParkMapper.ToPark(huisEF.Park));
            }
            catch (MapperException ex) 
            {
                throw new MapperException("Error mapping HuisEF to Huis.", ex);
            }
        }

        public static HuisEF ToHuisEF(Huis huis)
        {
            try
            {
                return new HuisEF()
                {
                    Id = huis.Id,
                    Straat = huis.Straat,
                    Nr = huis.Nr,
                    Actief = huis.Actief,
                    Park = ParkMapper.ToParkEF(huis.Park),
                };
            }
            catch (MapperException ex) 
            {
                throw new MapperException("Error mapping Huis to HuisEF.", ex);
            }
        }
    }
}
