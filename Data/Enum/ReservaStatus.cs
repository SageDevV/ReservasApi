using System.ComponentModel;

namespace Data.Enum
{
    public enum ReservaStatus : short
    {
        [Description("Aprovado")]
        Aprovado = 0,
        Reprovado = 1
    }
}
