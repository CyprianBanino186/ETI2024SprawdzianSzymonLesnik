using System.Security.Permissions;

namespace SprawdzianSzymonLesnik.Models
{
    public class Nauczyciel
    {
        public int NauczycielId { get; set; }
        public string Imie {  get; set; }
        public string Nazwisko { get; set; }

        public string AdresZamieszkania { get; set; }

        public ICollection<Kurs> Kurs { get; set; }
    }
}
