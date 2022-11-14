using Data.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioApplication
    {
        public IEnumerable<Usuario> BuscarTodosUsuarios();
        public string InserirUsuario(string usuarioNome, string email);
        public string Cadastro(string usuarioNome, string email, string senha);
    }
}