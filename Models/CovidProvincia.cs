using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCovid.Models
{
    public class CovidProvincia 
    {
        public string Nombre { get; set; }
        public string Confirmados { get; set; }
        public string Recuperados { get; set; }
        public string Fallecidos { get; set; }
    }
}
