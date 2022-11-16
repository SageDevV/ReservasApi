using System.ComponentModel;

namespace Data.Enum
{
    public enum ReservaStatus : short
    {
        [Description("Aprovado")]
        Aprovado = 0,

        [Description("Reprovado")]
        Reprovado = 1
    }
}
