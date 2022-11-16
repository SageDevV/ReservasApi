using System.ComponentModel;

namespace Data.Enum
{
    public enum Privilegio : int
    {
        [Description("Solicitante")]
        Solicitante = 0,

        [Description("Aprovador")]
        Aprovador = 1
    }
}
