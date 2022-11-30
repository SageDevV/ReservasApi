using System.ComponentModel;

namespace Data.Enum
{
    public enum ReservaStatus : int
    {
        [Description("Aprovado")]
        Aprovado = 0,

        [Description("Reprovado")]
        Reprovado = 1,

        [Description("Aguardando aprovação")]
        AguardandoAprovacao = 4,
    }
}
