namespace SprawdzianSzymonLesnik.Models
{
    public class Uczen
    {
        public int UczenId { get; set; }
        public string Imie {  get; set; }

        public string Nazwisko { get; set; }
        public string Adres { get; set; }
        public ICollection<ZapisaniNaKurs> ZapisaniNaKurs { get; set; }

    }
}
