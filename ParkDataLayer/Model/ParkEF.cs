using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        private string naam;
        public string Naam
        {
            get { return naam; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ModelException("Naam cannot be null or whitespace.");
                naam = value;
            }
        }

        private string locatie;
        public string Locatie
        {
            get { return locatie; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ModelException("Locatie cannot be null or whitespace.");
                locatie = value;
            }
        }

        public List<HuisEF> _huis { get; set; }
        
    }
}
