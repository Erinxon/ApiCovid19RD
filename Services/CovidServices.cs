using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.AppsettingModels;
using ApiCovid.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Options;
using ScrapySharp.Extensions;
using ApiCovid.Handles;
using ApiCovid.Response;

namespace ApiCovid.Services
{
    public class CovidServices : ICovidServices
    {
        private readonly SectionUrlPage _sectionUrlPage;
        private readonly XPathExpression _xPathExpression;
        public CovidServices(IOptions<SectionUrlPage> urlPage, IOptions<XPathExpression> XPathExpression)
        {
            this._sectionUrlPage = urlPage.Value;
            this._xPathExpression = XPathExpression.Value;
        }

        public async Task<ApiResponse<Covid>> GetCovidAsync()
        {
            var response = new ApiResponse<Covid>();
            try
            {
                var htmlDoc = await GetHtmlDocumentAsync(_sectionUrlPage.Url);
                var htmlNodeCovidGeneral = htmlDoc.DocumentNode.SelectNodes(_xPathExpression.XPATHCovidGeneral);
                var htmlNodeCovidPorProvincia = htmlDoc.DocumentNode.SelectNodes(_xPathExpression.XPATHCovidPorProvincia);
                response.Data = htmlNodeCovidGeneral.GetInfoCovidGeneral(_xPathExpression);
                response.Data.CovidPorProvincia = htmlNodeCovidPorProvincia.GetInfoCovidPorProvincia(_xPathExpression);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.message = ex.Message;
            }
            return response;
        }

        private static async Task<HtmlDocument> GetHtmlDocumentAsync(string url)
        {
            HtmlWeb htmlWeb = new();
            return await htmlWeb.LoadFromWebAsync(url);
        }
    }
}
