using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCovid.AppsettingModels
{
    public class XPathExpression
    {
        public string XPATHCovidGeneral { get; set; }
        public string XPATHCovidPorProvincia { get; set; }
        public string XPATHCovidConfirmados { get; set; }
        public string XPATHCovidRecuperados { get; set; }
        public string XPATHCovidFallecidos { get; set; }
        public string XPATHCovidUltimaActualizacion { get; set; }
        public string XPATHCovidPorProvinciaInfo { get; set; }
    }
}

