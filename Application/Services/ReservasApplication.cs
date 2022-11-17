﻿using Application.Interfaces;
using Data.Entities;
using Data.Enum;
using Data.Interfaces;
using System.Data;

namespace Application.Services
{
    public class ReservaApplication : IReservaApplication
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public ReservaApplication(ISalaRepository salaRepository, IUsuarioRepository usuarioRepository)
        {
            _salaRepository = salaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public IEnumerable<Sala> BuscarTodasSalas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalas(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasAguardandoAprovacao(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasAguardandoAprovacao(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasNaoReservadas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasNaoReservadas(bloco);
        }

        public IEnumerable<Sala> BuscarTodasSalasReservadas(string? bloco)
        {
            return _salaRepository.BuscarTodasSalasReservadas(bloco);
        }

        public string CriarReserva(int idSala, int idSolicitante, string dataReserva)
        {
            var usuario = _usuarioRepository.VerificaPrivilegioUsuario(idSolicitante);

            if (usuario.Privilegio == (int)Privilegio.Aprovador)
                return "Usuario com privilegios errados.";

            var sala = _salaRepository.BuscarSalaPorId(idSala);

            if (sala == null )
                return "A sala informada não existe.";

            if (sala.Status == (int)SalaStatus.Reservado || sala.Status == (int)SalaStatus.AguardandoAprovacao)
                return "O status da sala não pode ser diferente de não reservado";

            _salaRepository.CriarReserva(sala.Id, usuario.Id, dataReserva);

            _salaRepository.AlterarStatusSalaAguardandoAprovacao(sala.Id);
                
            return "Sala criada com sucesso.";
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

            _salaRepository.DeleteReservaIdSala(sala.Id);

            return "Reserva deletada com sucesso";
        }
    }
}
