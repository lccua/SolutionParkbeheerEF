using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurcontractEF
    {
        public string Id { get;  set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int Aantaldagen { get; set; }
        public HuurderEF Huurder { get;  set; }
        public HuisEF Huis { get;  set; }
    }
}
