using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.Services;
using ApiCovid.Models;

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
        public async Task<Covid> Get()
        {
            return await _covidServices.getCovid();
        }
    }
}
