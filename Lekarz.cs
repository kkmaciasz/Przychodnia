using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Przychodnia
{
    public enum EnumSpecjalizacja
    {
        lekarzRodzinny,
        kardiologia,
        neurologia,
        pediatria,
        geriatria,
        chirurgia,
        ortopedia,
        psychiatria,
        ginekologia,
        urologia,
        dermatologia,
        laryngologia,
        gastrologia,
        anestezjologia,
        fizjoterapia
    }
    public class Lekarz
    {
        string imie;
        string nazwisko;
        List<EnumSpecjalizacja> specjalizacje;
        HarmonogramLekarza harmonogram;

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public List<EnumSpecjalizacja> Specjalizacje { get => specjalizacje; set => specjalizacje = value; }
        public HarmonogramLekarza Harmonogram { get => harmonogram; set => harmonogram = value; }

        public Lekarz(string imie, string nazwisko, List<EnumSpecjalizacja> specjalizacje)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Specjalizacje = specjalizacje;
            Harmonogram = new HarmonogramLekarza();
        }
    }
}
