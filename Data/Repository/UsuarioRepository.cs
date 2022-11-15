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
        public bool InserirUsuario(string usuarioNome)
        {
            string query = "INSERT INTO Usuario (NomeUsuario) VALUES (@NomeUsuario)";
            var param = new
            {
                NomeUsuario = usuarioNome,
            };
            return true ? _dapperConfig.Insert(query, param) > 0 : throw new ArgumentException("Não foi possível inserir o usuário.");
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
    }
}
