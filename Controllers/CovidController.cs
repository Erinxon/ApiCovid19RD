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
    [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 5)]
    public class CovidController : ControllerBase
    {
        private readonly ICovidServices _covidServices;

        public CovidController(ICovidServices services)
        {
            _covidServices = services;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<Covid>>> Get()
        {
            var response = await _covidServices.GetCovidAsync();
            return response.Data == null || 
                response.Success ? BadRequest(response) : 
                Ok(response);
        }
    }
}
