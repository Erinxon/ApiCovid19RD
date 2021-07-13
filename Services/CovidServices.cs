using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using ScrapySharp.Extensions;

namespace ApiCovid.Services
{
    public class CovidServices : ICovidServices
    {
        private readonly SectionUrlPage _sectionUrlPage;

        public CovidServices(IOptions<SectionUrlPage> sectionUrlPage)
        {
            this._sectionUrlPage = sectionUrlPage.Value;
        }

        public async Task<Covid> getCovid()
        {
            Covid covid = new();
            try
            {
                var listaInfoCasos = await RequestPage();

                covid.Infectados = listaInfoCasos[(int)Item.Infectados];
                covid.CasosNuevos = listaInfoCasos[(int)Item.CasosNuevos];
                covid.TotalFallecidos = listaInfoCasos[(int)Item.TotalFallecidos];
                covid.NuevosFallecidos = listaInfoCasos[(int)Item.NuevosFallecidos];
                covid.Recuperados = listaInfoCasos[(int)Item.Recuperados];
                covid.UCI = listaInfoCasos[(int)Item.UCI];
                covid.PruebasProcesadas = listaInfoCasos[(int)Item.PruebasProcesadas];
         

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            return covid;
        }


        private async Task<string[]> RequestPage()
        {
            HtmlWeb htmlWeb = new();
            HtmlDocument htmlDoc = await htmlWeb.LoadFromWebAsync(this._sectionUrlPage.Url);
            var regs = htmlDoc.DocumentNode.SelectSingleNode(@"//div[@class='coronavirus-holder']");

            var listaInfoCasos = regs.InnerText
                    .Replace("Coronavirus", "")
                    .Replace("en República Dominicana", "")
                    .Replace("Coronavirus", "")
                    .Replace("Infectados", "")
                    .Replace("Nuevos casos", ";")
                    .Replace("Fallecidos total", ";")
                    .Replace("Nuevos fallecidos", ";")
                    .Replace("Recuperados", ";")
                    .Replace("UCI", ";")
                    .Replace("Pruebas", ";").Split(";");

            return listaInfoCasos;
        }
    }

    public enum Item
    {
        Infectados,
        CasosNuevos,
        TotalFallecidos,
        NuevosFallecidos,
        Recuperados,
        UCI,
        PruebasProcesadas   
    }
}
