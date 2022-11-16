using Data.Entities;
using Data.Enum;
using Data.Interfaces;

namespace Data.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private readonly IDapperConfig<Sala> _dapperConfig;
        public SalaRepository(IDapperConfig<Sala> dapperConfig)
        {
            _dapperConfig = dapperConfig;
        }

        public IEnumerable<Sala> BuscarTodasSalas(string? bloco)
        {
            string query;

            if (bloco is null)
            {
                query = "SELECT * FROM Sala";
                return _dapperConfig.Query(query);
            }

            query = @"SELECT * FROM Sala s 
                      INNER JOIN Bloco b ON b.Id = s.IdBloco 
                      WHERE b.Nome = @Nome";

            object param = new
            {
                Nome = bloco
            };

            return _dapperConfig.Query(query, param);
        }

        public IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco)
        {
            string query; 
            if (bloco is null)
            {
                query = $@"SELECT * FROM Sala s
                           WHERE s.Status = {(short)SalaStatus.AguardandoAprovacao}";
            }

            query = $@"SELECT * FROM Sala s
                       INNER JOIN Bloco b ON b.Id = s.IdBloco
                       WHERE s.Status = {(short)SalaStatus.AguardandoAprovacao}
                       AND b.Nome = @Nome";

            object param = new
            {
                Nome = bloco
            };

            return _dapperConfig.Query(query, param);
        }

        public IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco)
        {
            string query;
            if (bloco is null)
            {
                query = $@"SELECT * FROM Sala s
                           WHERE s.Status = {(short)SalaStatus.NaoReservado}";
            }

            query = $@"SELECT * FROM Sala s
                       INNER JOIN Bloco b ON b.Id = s.IdBloco
                       WHERE s.Status = {(short)SalaStatus.NaoReservado}
                       AND b.Nome = @Nome";

            object param = new
            {
                Nome = bloco
            };

            return _dapperConfig.Query(query, param);
        }

        public IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco)
        {
            string query;

            if (bloco is null)
            {
                query = $@"SELECT * FROM Sala s
                           WHERE s.Status = {(short)SalaStatus.Reservado}";
            }

            query = $@"SELECT * FROM Sala s
                       INNER JOIN Bloco b ON b.Id = s.IdBloco
                       WHERE s.Status = {(short)SalaStatus.Reservado}
                       AND b.Nome = @Nome";

            object param = new
            {
                Nome = bloco
            };


            return _dapperConfig.Query(query, param);
        }
    }
}
