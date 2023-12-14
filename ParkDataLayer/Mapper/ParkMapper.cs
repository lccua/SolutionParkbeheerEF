using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mapper
{
    public class ParkMapper
    {
        static public Park ToPark(ParkEF parkEF)
        {
            return new Park(parkEF.Id, parkEF.Naam, parkEF.Locatie, parkEF._huis.Select(h => HuisMapper.ToHuis(h)).ToList());
        }

        static public ParkEF ToParkEF(Park park)
        {
            return new ParkEF()
            {
                Id = park.Id,
                Naam = park.Naam,
                Locatie = park.Locatie,
                _huis = park.huis.Select(h => HuisMapper.ToHuisEF(h)).ToList()
            };
        }
    }
}
