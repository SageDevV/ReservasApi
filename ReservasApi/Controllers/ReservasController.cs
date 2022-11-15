using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ReservasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaApplication _reservaApplication;
        public ReservasController(IReservaApplication reservaApplication) 
        {
            _reservaApplication = reservaApplication;
        }

        [HttpGet("")]
        public IActionResult BuscarTodasSalas()
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasSalas());
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }
    }
}
