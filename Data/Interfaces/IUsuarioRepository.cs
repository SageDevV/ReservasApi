using Data.Entities;

namespace Data.Interfaces
{
    public interface IUsuarioRepository
    {
        public IEnumerable<Usuario> BuscarTodosUsuarios();
        bool InserirUsuario(string usuarioNome);
        public Usuario BuscarUsuarioPorEmailNome(string email, string usuarioNome);
        public Usuario BuscarUsuarioPorNome(string usuarioNome);
        Usuario VerificaPrivilegioUsuario(int idUsuario);
    }
}