using Data.Entities;

namespace Application.Interfaces
{
    public interface IUsuarioApplication
    {
        public IEnumerable<Usuario> BuscarTodosUsuarios();
        string Cadastro(string usuarioNome, string email, string senha, int privilegios);
        public string Login(string email, string senha);
    }
}