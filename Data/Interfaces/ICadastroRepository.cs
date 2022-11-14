using Data.Entities;

namespace Data.Interfaces
{
    public interface ICadastroRepository
    {
        public Cadastro BuscarUsuarioCadastradoPorSenhaENome(string email, string senha);
        public bool CadastrarUsuario(int idUsuario, string senha);
    }
}