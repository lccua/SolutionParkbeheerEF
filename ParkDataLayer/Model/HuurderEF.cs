using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuurderEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate IDs
        public int Id { get; private set; }

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

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ModelException("Email cannot be null or whitespace.");
                email = value;
            }
        }

        private string tel;
        public string Tel
        {
            get { return tel; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ModelException("Tel cannot be null or whitespace.");
                tel = value;
            }
        }

        private string adres;
        public string Adres
        {
            get { return adres; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ModelException("Adres cannot be null or whitespace.");
                adres = value;
            }
        }
    }
}
