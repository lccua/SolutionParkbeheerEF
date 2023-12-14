using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mapper
{
    public class HuisMapper
    {
        public static Huis ToHuis(HuisEF huisEF)
        {
            return new Huis(huisEF.Id, huisEF.Straat, huisEF.Nr, huisEF.Actief, ParkMapper.ToPark(huisEF.Park));
        }

        public static HuisEF ToHuisEF(Huis huis)
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
    }
}
