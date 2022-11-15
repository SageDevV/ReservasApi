using Data.Entities;

namespace Application.Interfaces
{
    public interface IReservaApplication
    {
        public IEnumerable<Sala> BuscarTodasSalas();
    }
}