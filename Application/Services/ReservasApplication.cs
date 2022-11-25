using Application.Interfaces;
using Data.Entities;
using Data.Enum;
using Data.Interfaces;

namespace Application.Services
{
    public class SalaReservaApplication : ISalaReservaApplication
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IReservaRepository _reservaRepository;
        public SalaReservaApplication(ISalaRepository salaRepository, IUsuarioRepository usuarioRepository, IReservaRepository reservaRepository)
        {
            _salaRepository = salaRepository;
            _usuarioRepository = usuarioRepository;
            _reservaRepository = reservaRepository;
        }

        public string AprovarReserva(int idReserva, int idAprovador)
        {
            var usuario = _usuarioRepository.VerificaPrivilegioUsuario(idAprovador);

            if (usuario.Privilegio != 1)
                return "Usuário com privilégios errados.";

            var reserva = _reservaRepository.BuscarReservaPorId(idReserva);

            if (reserva is null)
                return "A reserva não foi encontrada na base de dados.";

            if (reserva.IdSolicitante is default(int))
                return "A reserva foi solicitada de maneira incorreta. Solicitante não encontrado.";

            _reservaRepository.AprovarReserva(reserva.Id, idAprovador);

            return "Reserva aprovada com sucesso";
        }

        public IEnumerable<Sala> BuscarTodasSalas(string? bloco)
        {
            var result = _salaRepository.BuscarTodasSalas(bloco);
            return result;
        }

        public IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasAguardandoAprovacao(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasNaoReservadas(bloco);
        }

        public IEnumerable<Reserva> BuscarTodasReservaPorBloco(string? bloco)
        {
            var reservas = _reservaRepository.BuscarTodasReservaPorBloco(bloco);
            foreach(var reserva in reservas)
            {
                string[] periodoReserva = reserva.PeriodoReserva.Split('=');
                reserva.Data = periodoReserva[0];
                reserva.RangeHora = periodoReserva[1];
            }

            return reservas;
        }

        public string CriarReserva(int idSala, int idSolicitante, string dataReserva)
        {
            var usuario = _usuarioRepository.VerificaPrivilegioUsuario(idSolicitante);

            if (usuario.Privilegio == (int)Privilegio.Aprovador)
                throw new ArgumentException("Usuario com privilegios incorretos.");

            var sala = _salaRepository.BuscarSalaPorId(idSala);

            if (sala == null )
                return "A sala informada não existe.";

            if (sala.Status == (int)SalaStatus.Reservado || sala.Status == (int)SalaStatus.AguardandoAprovacao)
                return "O status da sala não pode ser diferente de não reservado";

            _reservaRepository.CriarReserva(sala.Id, usuario.Id, dataReserva);

            _salaRepository.AlterarStatusSalaAguardandoAprovacao(sala.Id);
                
            return "Reserva criada com sucesso.";
        }

        public string DesfazerReserva(int idSala, int idSolicitante)
        {
            var usuario = _usuarioRepository.VerificaPrivilegioUsuario(idSolicitante);

            if (usuario.Privilegio == (int)Privilegio.Aprovador)
                return "Usuario com privilegios errados.";

            var sala = _salaRepository.BuscarSalaPorId(idSala);

            if (sala is null)
                return "A sala informada não consta na base de dados.";

            if (sala.Status != ((int)SalaStatus.AguardandoAprovacao) && sala.Status != ((int)SalaStatus.Reservado))
                return "O status da sala informada não está reservada ou aguardando aprovação.";

            _salaRepository.AlterarStatusSalaNaoReservado(sala.Id);

            _reservaRepository.DeleteReservaIdSala(sala.Id);

            return "Reserva deletada com sucesso";
        }

        public string ReprovarReserva(int idReserva, int idAprovador)
        {
            var usuario = _usuarioRepository.VerificaPrivilegioUsuario(idAprovador);

            if (usuario.Privilegio != 1)
                return "Usuário com privilégios errados.";

            var reserva = _reservaRepository.BuscarReservaPorId(idReserva);

            if (reserva is null)
                return "A reserva não foi encontrada na base de dados.";

            if (reserva.IdSolicitante is default(int))
                return "A reserva foi solicitada de maneira incorreta. Solicitante não encontrado.";

            _reservaRepository.ReprovarReserva(reserva.Id, idAprovador);

            return "Reserva reprovada com sucesso";
        }

        public IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco)
        {
            throw new NotImplementedException();
        }
    }
}
