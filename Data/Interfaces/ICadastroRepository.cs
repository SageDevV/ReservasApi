using Data.Entities;

namespace Data.Interfaces
{
    public interface ICadastroRepository
    {
        public Cadastro BuscarCadastroPorSenhaEmail(string senha, string email);
        public Cadastro BuscarUsuarioCadastradoPorSenhaNome(string senha, string nome);
        public bool CadastrarUsuario(int idUsuario, string email, string senha);
    }
}