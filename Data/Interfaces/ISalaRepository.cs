using Data.Entities;

namespace Data.Interfaces
{
    public interface ISalaRepository
    {
        IEnumerable<Sala> BuscarTodasSalas(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco);
    }
}