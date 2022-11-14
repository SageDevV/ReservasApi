using Data.Entities;

namespace Data.Interfaces
{
    public interface IUsuarioRepository
    {
        public IEnumerable<Usuario> BuscarTodosUsuarios();
        bool InserirUsuario(string usuarioNome, string email);
        public Usuario BuscarUsuarioPorEmailENome(string email, string usuarioNome);
    }
}