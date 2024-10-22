using System.Composition;

namespace SprawdzianSzymonLesnik.Models
{
    public class Kurs
    {
        public int KursId { get; set; }

        public string NazwaKursu {  get; set; }

        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }

        public ICollection<ZapisaniNaKurs> ZapisaniNaKurs { get; set; }
    }
}
