using ApiCovid.AppsettingModels;
using ApiCovid.Models;
using ApiCovid.Models.Enums;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCovid.Handles
{
    public static class Handle
    {
        public static Covid GetInfoCovidGeneral(this HtmlNodeCollection htmlNodes, XPathExpression _xPathExpression)
        {

            return htmlNodes.Select(c => new Covid
            {
                Confirmados = c.SelectSingleNode(_xPathExpression.XPATHCovidConfirmados).InnerText,
                Recuperados = c.SelectSingleNode(_xPathExpression.XPATHCovidRecuperados).InnerText,
                Fallecidos = c.SelectSingleNode(_xPathExpression.XPATHCovidFallecidos).InnerText,
                UltimaActualizacion = c.SelectSingleNode(_xPathExpression.XPATHCovidUltimaActualizacion).InnerText.Replace("Última actualización:&nbsp;", "")
            }).FirstOrDefault();         
        }
        public static List<CovidProvincia> GetInfoCovidPorProvincia(this HtmlNodeCollection htmlNodes, XPathExpression xPath)
        {
            return  htmlNodes.Select(p => new CovidProvincia
            {
                Nombre = p.SelectSingleNode("path") != null ? p.SelectSingleNode("path").Attributes["title"].Value :
                            p.SelectSingleNode("g/path").Attributes["title"].Value,
                Confirmados = p.SelectNodes(xPath.XPATHCovidPorProvinciaInfo)[(int)EstadisticaEnum.Confirmados].InnerText,
                Fallecidos = p.SelectNodes(xPath.XPATHCovidPorProvinciaInfo)[(int)EstadisticaEnum.Fallecidos].InnerText,
                Recuperados = p.SelectNodes(xPath.XPATHCovidPorProvinciaInfo)[(int)EstadisticaEnum.Recuperados].InnerText,
            }).ToList();
        }


    }
}
