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

        public IEnumerable<Sala> BuscarTodasSalas()
        {
            return _salaRepository.BuscarTodasSalas();
        }
    }
}
