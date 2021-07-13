using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCovid.Models;

namespace ApiCovid.Services
{
    public interface ICovidServices
    {
        Task<Covid> getCovid();
    }
}
