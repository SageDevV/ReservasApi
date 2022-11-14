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
            if (_usuarioRepository.BuscarUsuarioPorEmailENome(email, usuarioNome) is not null)
                return "Já existe um usuário para esse email e nome";

            if (_usuarioRepository.InserirUsuario(usuarioNome, email))
                return "Usuario inserido com sucesso";

            throw new ArgumentException("Não foi possivel inserir o usuário.");
        }

        public string Cadastro(string usuarioNome, string email, string senha)
        {
            if (_cadastroRepository.BuscarUsuarioCadastradoPorSenhaENome(email, senha) is not null)
                return "Usuario já cadastrado, realize o login por favor.";

            var usuario = _usuarioRepository.BuscarUsuarioPorEmailENome(usuarioNome, email);

            if (usuario is not null)
            {
                _cadastroRepository.CadastrarUsuario(usuario.Id, senha);
                return "Usuario cadastrado com sucesso";
            }

            _usuarioRepository.InserirUsuario(usuarioNome, email);
            var usuarioCadastrado = _usuarioRepository.BuscarUsuarioPorEmailENome(email, usuarioNome);
            _cadastroRepository.CadastrarUsuario(usuarioCadastrado.Id, senha);
            return "Usuario cadastrado com sucesso";

        }
    }
}