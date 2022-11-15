using System.Text.Json.Serialization;

namespace ReservasApi.ViewModels
{
    public class UsuarioViewModel
    {
        public string NomeUsuario { get; set; }

        [JsonIgnore]
        public string Email { get; set; }
    }
}