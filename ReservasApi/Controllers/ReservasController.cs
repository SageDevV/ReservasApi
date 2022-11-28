using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReservasApi.ViewModels;

namespace ReservasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaReservasController : ControllerBase
    {
        private readonly ISalaReservaApplication _reservaApplication;
        public SalaReservasController(ISalaReservaApplication reservaApplication)
        {
            _reservaApplication = reservaApplication;
        }

        [HttpGet("salas")]
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

        [HttpGet("reservas")]
        public IActionResult BuscarTodasReservas()
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasReservas());
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpGet("salas-reservadas")]
        public IActionResult BuscarTodasReservaPorBloco([FromQuery] string? bloco)
        {
            try
            {
                return Ok(_reservaApplication.BuscarTodasReservaPorBloco(bloco));
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

        [HttpPost("reserva")]
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

        [HttpDelete("reserva")]
        public IActionResult DesfazerReserva([FromQuery] int idSala, int idSolicitante)
        {
            try
            {
                return Ok(_reservaApplication.DesfazerReserva(idSala, idSolicitante));
            }
            catch (Exception e)
            {

                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpPut("reserva/aprovacao")]
        public IActionResult AprovarReserva([FromQuery] int idReserva, int idAprovador)
        {
            try
            {
                return Ok(_reservaApplication.AprovarReserva(idReserva, idAprovador));
            }
            catch (Exception e)
            {

                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpPut("reserva/reprovacao")]
        public IActionResult ReprovarReserva([FromQuery] int idReserva, int idAprovador)
        {
            try
            {
                return Ok(_reservaApplication.ReprovarReserva(idReserva, idAprovador));
            }
            catch (Exception e)
            {

                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }
    }
}
