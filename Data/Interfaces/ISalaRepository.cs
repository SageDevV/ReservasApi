using Data.Entities;

namespace Data.Interfaces
{
    public interface ISalaRepository
    {
        public IEnumerable<Sala> BuscarTodasSalas();
    }
}