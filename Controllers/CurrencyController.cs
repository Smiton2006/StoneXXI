using Microsoft.AspNetCore.Mvc;
using StoneXXI.Facades;
using System.Threading.Tasks;

namespace StoneXXI.Controllers
{
    /// <summary>
    /// Контроллер для работы в валютой
    /// </summary>
    [ApiController]
    [Route("/api/v1/currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyFacade _facade;

        public CurrencyController(CurrencyFacade facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Загрузить валюьы
        /// </summary>        
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadCurrency()
        {
            var res = await _facade.UploadCurrency();
            if (res.Failure)
                return BadRequest(res.Error);
            return new OkResult();
        }

        /// <summary>
        /// Получить валюты
        /// </summary>        
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _facade.GetAllAsync();
            if (res.Failure)
                return BadRequest(res.Error);
            return new OkObjectResult(res.Value);
        }
    }
}
