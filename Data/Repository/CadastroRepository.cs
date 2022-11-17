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

        public Cadastro BuscarUsuarioCadastradoPorSenhaNome(string email, string senha)
        {
            string query = @"SELECT * FROM Cadastro c 
                            INNER JOIN Usuario u ON u.Id = c.IdUsuario
                            WHERE c.Email = @Email AND c.Senha = @Senha";

            object param = new
            {
                Senha = senha,
                Email = email
            };

            return _dapperConfig.Query(query, param).FirstOrDefault();
        }

        public bool CadastrarUsuario(int idUsuario, string email, string senha)
        {
            string query = @"INSERT INTO Cadastro (IdUsuario, Email, Senha, DataCadastro) 
                             VALUES (@IdUsuario, @Email , @Senha, GETDATE())";
            object param = new
            {
                IdUsuario = idUsuario,
                Email = email,
                Senha = senha
            };
            return true ? _dapperConfig.Execute(query, param) > 0 : throw new ArgumentException("Não foi possível inserir o cadastro do usuário.");
        }

        public Cadastro BuscarCadastroPorSenhaEmail(string senha, string email)
        {
            string query = @"SELECT * FROM Cadastro c 
                             WHERE c.Senha = @Senha AND C.Email = @Email";

            object param = new
            {
                Senha = senha,
                Email = email
            };

            return _dapperConfig.Query(query, param).FirstOrDefault();
        }
    }
}
