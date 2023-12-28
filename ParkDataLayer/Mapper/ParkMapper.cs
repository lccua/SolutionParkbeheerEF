using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.Linq;

namespace ParkDataLayer.Mapper
{
    public class ParkMapper
    {
        static public Park ToPark(ParkEF parkEF)
        {
            try
            {
                return new Park(
                    parkEF.Id,
                    parkEF.Naam,
                    parkEF.Locatie
                );
            }
            catch (MapperException ex) 
            {
                throw new MapperException("Error mapping ParkEF to Park.", ex);
            }
        }

        static public ParkEF ToParkEF(Park park)
        {
            try
            {
                return new ParkEF()
                {
                    Id = park.Id,
                    Naam = park.Naam,
                    Locatie = park.Locatie,
                    _huis = park.huis.Select(h => HuisMapper.ToHuisEF(h)).ToList()
                };
            }
            catch (MapperException ex) 
            {
                throw new MapperException("Error mapping Park to ParkEF.", ex);
            }
        }
    }
}
