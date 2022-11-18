namespace Data.Entities
{
    public class Reserva
    {
        public int Id { get; set; }
        public int IdSala { get; set; }
        public int IdSolicitante { get; set; }
        public int IdAprovador { get; set; }
        public int Status { get; set; }
        public string PeriodoReserva { get; set; }
    }
}
