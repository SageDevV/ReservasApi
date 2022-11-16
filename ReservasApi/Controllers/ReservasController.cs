using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReservasApi.ViewModels;

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
        public IActionResult BuscarTodasSalas([FromQuery] string? bloco)
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasSalas(bloco));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpGet("salas-reservadas")]
        public IActionResult BuscarTodasSalasReservadas([FromQuery] string? bloco)
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasSalasReservadas(bloco));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpGet("salas-nao-reservadas")]
        public IActionResult BuscarTodasSalasNaoReservadas([FromQuery] string? bloco)
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasSalasNaoReservadas(bloco));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpGet("salas-aguardando-reserva")]
        public IActionResult BuscarTodasSalasAguardandoAprovacao([FromQuery] string? bloco)
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasSalasAguardandoAprovacao(bloco));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpPost]
        public IActionResult CriarReserva([FromBody] ReservaViewModel reservaViewModel)
        {
            try
            {
                return Ok(_reservaApplication.CriarReserva(reservaViewModel.IdSala, reservaViewModel.IdSolicitante, reservaViewModel.DataReserva));
            }
            catch (Exception e)
            {

                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

            

    }
}
