using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using ReservasApi.ViewModels;

namespace ReservasApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioApplication _usuarioApplication;
        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        //Endpoint de validação.
        [HttpGet("")]
        public IActionResult BuscarTodosUsuarios()
        {
            try
            {
                return Ok(_usuarioApplication.BuscarTodosUsuarios());
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }


       
        // Endpoint de validação.
        [HttpPost("")]
        public IActionResult InserirUsuario([FromBody] UsuarioViewModel usuarioViewModel)
        {
            try
            {
                return Ok(_usuarioApplication.InserirUsuario(usuarioViewModel.NomeUsuario, usuarioViewModel.Email));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }
        [HttpPost("cadastro")]
        public IActionResult Cadastro([FromBody] CadastroViewModel cadastroViewModel)
        {
            try
            {
                return Ok(_usuarioApplication.Cadastro(cadastroViewModel.UsuarioNome, cadastroViewModel.Email, cadastroViewModel.Senha));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery] LoginViewModel loginViewModel)
        {
            try
            {
                return Ok(_usuarioApplication.Login(loginViewModel.Email, loginViewModel.Senha));
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Houve um erro na realização da requisição. Detalhes: {e.Message}");
            }
        }
    }
}