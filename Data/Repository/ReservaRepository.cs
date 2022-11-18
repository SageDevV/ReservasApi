using Data.Entities;
using Data.Enum;
using Data.Interfaces;

namespace Data.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private IDapperConfig<Reserva> _dapperConfig;
        public ReservaRepository(IDapperConfig<Reserva> dapperConfig)
        {
            _dapperConfig = dapperConfig;
        }

        public Reserva BuscarReservaPorId(int idReserva)
        {
            string query = @"SELECT * FROM Reservas
                             WHERE Id = @IdReserva";

            object param = new
            {
                IdReserva = idReserva
            };

            return _dapperConfig.Query(query, param).FirstOrDefault();
        }

        public void DeleteReservaIdSala(int idSala)
        {
            string query = @"DELETE FROM Reservas
                             WHERE IdSala = @IdSala";

            object param = new
            {
                IdSala = idSala
            };

            _dapperConfig.Execute(query, param);
        }

        public void AprovarReserva(int idReserva, int idAprovador)
        {
            string query = $@"UPDATE Reservas
                             SET Status = {((int)ReservaStatus.Aprovado)},
                             IdAprovador = @IdAprovador
                             WHERE Id = @IdReserva";

            object param = new
            {
                IdReserva = idReserva,
                IdAprovador = idAprovador
            };

            _dapperConfig.Execute(query, param);
        }

        public void CriarReserva(int idSala, int idSolicitante, string dataReserva)
        {
            string query = @"INSERT INTO Reservas (IdSala, IdSolicitante, PeriodoReserva)
                             VALUES (@IdSala, @IdSolicitante, @PeriodoReserva)";

            object param = new
            {
                IdSala = idSala,
                IdSolicitante = idSolicitante,
                PeriodoReserva = dataReserva
            };

            _dapperConfig.Execute(query, param);
        }

        public void ReprovarReserva(int idReserva, int idAprovador)
        {
            string query = $@"UPDATE Reservas
                             SET Status = {((int)ReservaStatus.Reprovado)},
                             IdAprovador = @IdAprovador
                             WHERE Id = @IdReserva";

            object param = new
            {
                IdReserva = idReserva,
                IdAprovador = idAprovador
            };

            _dapperConfig.Execute(query, param);
        }
    }
}
