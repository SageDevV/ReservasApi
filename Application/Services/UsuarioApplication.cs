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

        public string Cadastro(string usuarioNome, string email, string senha, int privilegios)
        {
            var usuarioCadastrado = _cadastroRepository.BuscarUsuarioCadastradoPorSenhaNome(email, senha);

            if (usuarioCadastrado is not null)
                return "Usuario já cadastrado, realize o login por favor.";

            var usuario = _usuarioRepository.BuscarUsuarioPorEmailNome(usuarioNome, email);

            if (usuario is not null)
            {
                _cadastroRepository.CadastrarUsuario(usuario.Id, email, senha);
                return "Usuario cadastrado com sucesso.";
            }

            var usuarioId = CriarUsuario(usuarioNome, privilegios);
            _cadastroRepository.CadastrarUsuario(usuarioId, email, senha);
            return "Usuario cadastrado com sucesso.";
        }

        public Usuario Login(string email, string senha)
        {
            var usuarioCadastrado = _cadastroRepository.BuscarCadastroPorSenhaEmail(senha, email);

            if (usuarioCadastrado is null)
                throw new ArgumentException("Usuário não cadastrado.");

            return _usuarioRepository.BuscarUsuarioPorId(usuarioCadastrado.IdUsuario);
        }

        private int CriarUsuario(string nome, int privilegios)
        {
           _usuarioRepository.InserirUsuario(nome, privilegios);
            return _usuarioRepository.RetornarUltimoIdCriadoUsuario();
        }
    }
}