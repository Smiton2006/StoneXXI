using Microsoft.AspNetCore.Mvc;
using StoneXXI.Facades;
using System.Threading.Tasks;

namespace StoneXXI.Controllers
{
    /// <summary>
    /// Контроллер для работы с курсом обмена центробанка
    /// </summary>
    [ApiController]
    [Route("/api/v1/exchangeRate/cb")]
    public class ExchangeRateCBController : ControllerBase
    {
        private readonly ExchangeRateFacade _facade;

        public ExchangeRateCBController(ExchangeRateFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Загрузить текущий курс обмена в базу
        /// </summary>        
        [HttpPost]
        public async Task<IActionResult> UploadCurrentExchangeRateAsync()
        {
            var res = await _facade.UploadCurrentExchangeRateAsync();
            if (res.Failure)
                return BadRequest(res.Error);
            return new OkResult();
        }

        /// <summary>
        /// Получить сегодняшний курс обмена который используется в системе каждый день
        /// </summary>        
        [HttpGet]
        public async Task<IActionResult> GetDefaultExchangeRate()
        {
            var res = await _facade.GetDefaultExchangeRate();
            if (res.Failure)
                return BadRequest(res.Error);
            return new OkObjectResult(res.Value);
        }
    }
}
