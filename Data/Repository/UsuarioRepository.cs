using Data.Entities;
using Data.Interfaces;

namespace Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDapperConfig<Usuario> _dapperConfig;
        public UsuarioRepository(IDapperConfig<Usuario> dapperConfig )
        {
            _dapperConfig = dapperConfig;
        }

        public IEnumerable<Usuario> BuscarTodosUsuarios()
        {
            string query = "SELECT * FROM Usuario";
            return _dapperConfig.Query(query);
        }
        public bool InserirUsuario(string usuarioNome, int privilegios)
        {
            string query = "INSERT INTO Usuario (NomeUsuario, Privilegio) VALUES (@NomeUsuario, @Privilegio)";
            var param = new
            {
                NomeUsuario = usuarioNome,
                Privilegio = privilegios
            };
            return true ? _dapperConfig.Execute(query, param) > 0 : throw new ArgumentException("Não foi possível inserir o usuário.");
        }

        public int RetornarUltimoIdCriadoUsuario()
        {
            string query = "SELECT TOP 1 ID FROM Usuario ORDER BY Id DESC";

            return _dapperConfig.Query(query).FirstOrDefault().Id;
        }

        public Usuario BuscarUsuarioPorEmailNome(string usuarioNome, string email)
        {
            string query = @"SELECT u.Id FROM Usuario u
                            INNER JOIN Cadastro c ON c.IdUsuario = u.Id
                            WHERE NomeUsuario = @UsuarioNome
                            AND c.Email = @Email";

            object param = new
            {
                UsuarioNome = usuarioNome,
                Email = email
            };
            return _dapperConfig.Query(query, param).FirstOrDefault();
        }

        public Usuario BuscarUsuarioPorNome(string usuarioNome)
        {
            string query = @"SELECT * FROM Usuario u
                             WHERE u.NomeUsuario = @UsuarioNome";

            object param = new
            {
                UsuarioNome = usuarioNome,
            };
            return _dapperConfig.Query(query, param).FirstOrDefault();
        }

        public Usuario BuscarUsuarioPorId(int idUsuario)
        {
            string query = @"SELECT * FROM Usuario u
                             WHERE u.Id = @IdUsuario";

            object param = new
            {
                IdUsuario = idUsuario,
            };
            return _dapperConfig.Query(query, param).FirstOrDefault();
        }

        public Usuario VerificaPrivilegioUsuario(int idUsuario)
        {
            string query = "SELECT * FROM Usuario u WHERE u.Id = @IdUsuario";

            object param = new
            {
                idUsuario = idUsuario,
            };

            return _dapperConfig.Query(query, param).FirstOrDefault();
        }
    }
}
