﻿using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        public string Id { get;  set; }
        public string Naam { get;  set; }
        public string Locatie { get;  set; }
        public List<HuisEF> _huis { get; set; }
}
}