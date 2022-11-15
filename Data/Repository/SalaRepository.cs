using Data.Entities;
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

        public IEnumerable<Sala> BuscarTodasSalas()
        {
            string query = "SELECT * FROM Sala";

            return _dapperConfig.Query(query);
        }
    }
}
