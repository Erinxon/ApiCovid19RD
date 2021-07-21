using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.Services;
using ApiCovid.Models;
using ApiCovid.Response;

namespace ApiCovid.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CovidController : ControllerBase
    {
        private readonly ICovidServices _covidServices;

        public CovidController(ICovidServices services)
        {
            this._covidServices = services;
        }

        [HttpGet] //GET
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 5)]
        public async Task<ApiResponse<Covid>> Get()
        {
            var response = new ApiResponse<Covid>();
            try
            {
                response.Data = await _covidServices.getCovid();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.message = ex.Message;
            }
            return response;
        }
    }
}
