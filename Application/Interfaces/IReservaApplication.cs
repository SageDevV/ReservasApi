using Data.Entities;

namespace Application.Interfaces
{
    public interface ISalaReservaApplication
    {
        string AprovarReserva(int idReserva, int idAprovador);
        IEnumerable<Sala> BuscarTodasSalas(string? bloco);
        IEnumerable<Reserva> BuscarTodasReservaPorBloco(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco);
        IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco);
        string CriarReserva(int idSala, int idSolicitante, string dataReserva);
        string DesfazerReserva(int idSala, int idSolicitante);
        string ReprovarReserva(int idReserva, int idAprovador);
        IEnumerable<Reserva> BuscarTodasReservas();
    }
}