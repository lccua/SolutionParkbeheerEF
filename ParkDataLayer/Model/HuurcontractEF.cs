using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkDataLayer.Model
{
    public class HuurcontractEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; private set; }

        private DateTime startDatum;
        public DateTime StartDatum
        {
            get { return startDatum; }
            set
            {
                if (value == default)
                    throw new ModelException("StartDatum cannot be the default date.");
                startDatum = value;
            }
        }

        private DateTime eindDatum;
        public DateTime EindDatum
        {
            get { return eindDatum; }
            set
            {
                if (value == default || value <= StartDatum)
                    throw new ModelException("EindDatum must be greater than StartDatum and cannot be the default date.");
                eindDatum = value;
            }
        }

        private int aantaldagen;
        public int Aantaldagen
        {
            get { return aantaldagen; }
            set
            {
                if (value < 0)
                    throw new ModelException("Aantaldagen cannot be negative.");
                aantaldagen = value;
            }
        }


        private HuurderEF huurder;
        public HuurderEF Huurder
        {
            get { return huurder; }
            set
            {
                if (value == null)
                    throw new ModelException("Huurder cannot be null.");
                huurder = value;
            }
        }

        private HuisEF huis;
        public HuisEF Huis
        {
            get { return huis; }
            set
            {
                if (value == null)
                    throw new ModelException("Huis cannot be null.");
                huis = value;
            }
        }
    }
}
