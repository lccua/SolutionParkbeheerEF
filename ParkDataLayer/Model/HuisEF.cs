using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuisEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get;  set; }

        public string Straat { get;  set; }
        public int Nr { get;  set; }
        public bool Actief { get; set; }
        public ParkEF Park { get;  set; }
        private Dictionary<HuurderEF, List<HuurcontractEF>> _huurcontracten { get; set; }

    }
}
