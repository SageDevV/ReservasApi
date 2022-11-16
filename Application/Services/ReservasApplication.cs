using Application.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Application.Services
{
    public class ReservaApplication : IReservaApplication
    {
        private readonly ISalaRepository _salaRepository;
        public ReservaApplication(ISalaRepository salaRepository)
        {
            _salaRepository = salaRepository;
        }

        public IEnumerable<Sala> BuscarTodasSalas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalas(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasAguardandoAprovacao(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasNaoReservadas(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasReservadas(bloco);
        }
    }
}
