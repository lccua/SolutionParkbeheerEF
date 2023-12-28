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
        public string Id { get; private set; }

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

        private List<HuisEF> _huis;
        public List<HuisEF> Huis
        {
            get { return _huis; }
            set
            {
                if (value == null || !value.Any())
                    throw new ModelException("Huis list cannot be null or empty.");
                _huis = value;
            }
        }
    }
}
