using Data.Entities;

namespace Data.Interfaces
{
    public interface ISalaRepository
    {
        IEnumerable<Sala> BuscarTodasSalasDisponiveisPorBloco(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco);
        Sala BuscarSalaPorId(int idSala);
        void AlterarStatusSalaAguardandoAprovacao(int idSala);
        void AlterarStatusSalaNaoReservado(int idSala);
    }
}