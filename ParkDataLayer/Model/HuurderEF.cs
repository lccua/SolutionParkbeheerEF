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
    public class HuurderEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-generate IDs
        public int Id { get;  set; }

        public string Naam { get;  set; }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }

    }
}
