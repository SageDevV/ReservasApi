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
    }
}