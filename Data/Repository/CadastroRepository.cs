using Data.Entities;
using Data.Interfaces;

namespace Data.Repository
{
    public class CadastroRepository : ICadastroRepository
    {
        private readonly IDapperConfig<Cadastro> _dapperConfig;
        public CadastroRepository(IDapperConfig<Cadastro> dapperConfig)
        {
            _dapperConfig = dapperConfig;
        }

        public Cadastro BuscarUsuarioCadastradoPorSenhaENome(string email, string senha)
        {
            string query = @"SELECT c.Matricula FROM Cadastro c 
                            INNER JOIN Usuario u ON u.Id = c.IdUsuario
                            WHERE u.Email = @Email AND c.Senha = @Senha";

            object param = new
            {
                Senha = senha,
                Email = email
            };

            return _dapperConfig.Query(query, param).FirstOrDefault();
        }

        public bool CadastrarUsuario(int idUsuario, string senha)
        {
            string query = @"INSERT INTO Cadastro (IdUsuario, Senha) 
                             VALUES (@IdUsuario, @Senha)";
            object param = new
            {
                IdUsuario = idUsuario,
                Senha = senha
            };
            return true ? _dapperConfig.Insert(query, param) > 0 : throw new ArgumentException("Não foi possível inserir o cadastro do usuário.");
        }
    }
}
