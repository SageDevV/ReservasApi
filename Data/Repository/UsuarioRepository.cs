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
        public bool InserirUsuario(string usuarioNome, string email)
        {
            string query = "INSERT INTO Usuario (NomeUsuario, Email) VALUES (@NomeUsuario, @Email)";
            var param = new
            {
                NomeUsuario = usuarioNome,
                Email = email
            };
            return true ? _dapperConfig.Insert(query, param) > 0 : throw new ArgumentException("Não foi possível inserir o usuário.");
        }

        public Usuario BuscarUsuarioPorEmailENome(string email, string usuarioNome)
        {
            string query = "SELECT Id FROM Usuario WHERE Email = @Email AND NomeUsuario = @UsuarioNome";
            object param = new
            {
                Email = email,
                UsuarioNome = usuarioNome
            };
            return _dapperConfig.Query(query, param).FirstOrDefault();
        }
    }
}
