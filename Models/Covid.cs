﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCovid.Models
{
    public class Covid 
    {
        public string Confirmados { get; set; }
        public string Recuperados { get; set; }
        public string Fallecidos { get; set; }
        public List<CovidProvincia>  CovidPorProvincia { get; set; }
        public string UltimaActualizacion { get; set; }
    }
}
