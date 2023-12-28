using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkDataLayer.Exceptions;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
      


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        private string straat;
        public string Straat
        {
            get { return straat; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ModelException("Straat cannot be null or whitespace.");
                straat = value;
            }
        }

        private int nr;
        public int Nr
        {
            get { return nr; }
            set
            {
                if (value <= 0)
                    throw new ModelException("Nr must be greater than 0.");
                nr = value;
            }
        }

        public bool Actief { get; set; }

        private ParkEF park;
        public ParkEF Park
        {
            get { return park; }
            set
            {
                if (value == null)
                    throw new ModelException("Park cannot be null.");
                park = value;
            }
        }

        private Dictionary<HuurderEF, List<HuurcontractEF>> _huurcontracten { get; set; }

    }
}
