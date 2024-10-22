namespace SprawdzianSzymonLesnik.Models
{
    public class ZapisaniNaKurs
    {
        public int ZapisaniNaKursId { get; set; }
        public Kurs? KursId { get; set; } = null!;
        public Uczen? UczenId { get; set; } = null!;
    }
}
