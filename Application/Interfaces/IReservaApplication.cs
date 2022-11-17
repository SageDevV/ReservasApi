using Data.Entities;

namespace Application.Interfaces
{
    public interface IReservaApplication
    {
        IEnumerable<Sala> BuscarTodasSalas(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco);
        string CriarReserva(int idSala, int idSolicitante, string dataReserva);
        string DesfazerReserva(int idSala, int idSolicitante);
    }
}