using Microsoft.AspNetCore.Mvc;
using StoneXXI.DB.Models;
using StoneXXI.Facades;
using System.Threading.Tasks;

namespace StoneXXI.Controllers
{
    [ApiController]
    [Route("/api/v1/exchangeRate/cb")]
    public class ExchangeRateCBController : ControllerBase
    {
        private readonly ExchangeRateFacade _facade;        

        public ExchangeRateCBController(ExchangeRateFacade facade)
        {
            _facade = facade;            
        }

        [HttpPost]
        public async Task UploadAsync()
        {
            await _facade.UploadCurrentExchangeRate();
        }

        [HttpGet]
        public async Task<ExchangeRate> GetDefaultAsync()
        {
            return await _facade.GetDefaultExchangeRate();
        }
    }
}
