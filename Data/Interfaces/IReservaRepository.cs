using Data.Entities;

namespace Data.Interfaces
{
    public interface IReservaRepository
    {
        Reserva BuscarReservaPorId(int idReserva);
        void DeleteReservaIdSala(int idSala);
        void AprovarReserva(int idReserva, int idAprovador);
        void CriarReserva(int idSala, int idSolicitante, string dataReserva);
        void ReprovarReserva(int idReserva, int idAprovador);
        IEnumerable<Reserva> BuscarTodasReservaPorBloco(string bloco);
        IEnumerable<Reserva> BuscarTodasReservas();
        IEnumerable<Reserva> BuscarTodasReservasAprovadasPorBloco(string? bloco, int idSolicitante);
        IEnumerable<Reserva> BuscarTodasReservasReprovadasPorBloco(string? bloco, int idSolicitante);
        IEnumerable<Reserva> BuscarTodasReservasCriadasPeloSolicitante(int idSolicitante, string? bloco);
        IEnumerable<Reserva> BuscarTodasReservasPendenteDeAprovacao();
    }
}