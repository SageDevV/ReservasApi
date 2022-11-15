using Application.Interfaces;
using Data.Entities;
using Data.Interfaces;

namespace Application.Services
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ICadastroRepository _cadastroRepository;
        public UsuarioApplication(IUsuarioRepository usuarioRepository, ICadastroRepository cadastroRepository)
        {
            _usuarioRepository = usuarioRepository;
            _cadastroRepository = cadastroRepository;
        }

        public IEnumerable<Usuario> BuscarTodosUsuarios()
        {
            return _usuarioRepository.BuscarTodosUsuarios();
        }

        public string InserirUsuario(string usuarioNome, string email)
        {
            if (_usuarioRepository.BuscarUsuarioPorEmailNome(email, usuarioNome) is not null)
                return "Já existe um usuário para esse email e nome.";

            if (_usuarioRepository.InserirUsuario(usuarioNome))
                return "Usuario inserido com sucesso.";

            throw new ArgumentException("Não foi possivel inserir o usuário.");
        }

        public string Cadastro(string usuarioNome, string email, string senha)
        {
            if (_cadastroRepository.BuscarUsuarioCadastradoPorSenhaNome(email, senha) is not null)
                return "Usuario já cadastrado, realize o login por favor.";

            var usuario = _usuarioRepository.BuscarUsuarioPorNome(usuarioNome);

            if (usuario is not null)
            {
                _cadastroRepository.CadastrarUsuario(usuario.Id, email, senha);
                return "Usuario cadastrado com sucesso.";
            }

            _usuarioRepository.InserirUsuario(usuarioNome);
            var usuarioCriado = _usuarioRepository.BuscarUsuarioPorNome(usuarioNome);
            _cadastroRepository.CadastrarUsuario(usuarioCriado.Id, email, senha);
            return "Usuario cadastrado com sucesso.";
        }

        public string Login(string email, string senha)
        {
            if (_cadastroRepository.BuscarCadastroPorSenhaEmail(senha, email) is null)
                return "Usuário não cadastrado.";

            return "Usuário encontrado.";
        }
    }
}