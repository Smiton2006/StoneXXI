using Microsoft.AspNetCore.Mvc;
using StoneXXI.DB.Models;
using StoneXXI.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoneXXI.Controllers
{
    [ApiController]
    [Route("/api/v1/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyFacade _facade;

        
        public CurrencyController(CurrencyFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        [Route("upload")]
        public async Task UploadCurrency()
        {
            await _facade.UploadCurrency();
        }

        [HttpGet]
        public async Task<List<Currency>> GetAllAsync()
        {
            return await _facade.GetAllAsync();
        }
    }
}
