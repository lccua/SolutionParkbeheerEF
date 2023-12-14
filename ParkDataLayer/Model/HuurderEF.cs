using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurderEF
    {
        public int Id { get;  set; }
        public string Naam { get;  set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }

    }
}
