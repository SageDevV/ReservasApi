using System.ComponentModel;

namespace Data.Enum
{
    public enum SalaStatus : short
    {
        [Description("Não reservado")]
        NaoReservado = 0,
        Reservado = 1
    }
}
