using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.Models;
using ApiCovid.Response;

namespace ApiCovid.Services
{
    public interface ICovidServices
    {
        Task<ApiResponse<Covid>> GetCovidAsync();
    }
}
