using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCovid.Models
{
    public class Covid
    {
        public string Infectados { get; set; }

        public string CasosNuevos { get; set; }

        public string TotalFallecidos { get; set; }

        public string NuevosFallecidos { get; set; }

        public string Recuperados { get; set; }

        public string UCI { get; set; }

        public string PruebasProcesadas { get; set; }
    }
}
