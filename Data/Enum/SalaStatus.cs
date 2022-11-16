using System.ComponentModel;

namespace Data.Enum
{
    public enum SalaStatus : int
    {
        [Description("Não reservado")]
        NaoReservado = 0,

        [Description("Reservado")]
        Reservado = 1,

        [Description("Aguardando aprovação")]
        AguardandoAprovacao = 2
    }
}
