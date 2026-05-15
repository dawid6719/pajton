using System;
using System.Collections.Generic;
using System.Linq;

namespace PortfolioMaturalne
{
    // Klasa reprezentująca encję w bazie danych (Hermetyzacja)
    public class Produkt
    {
        public int Id { get; set; }
        public string Nazwa { get; set; } = string.Empty;
        public double Cena { get; set; }

        public void PokazInformacje()
        {
            Console.WriteLine($"[ID: {Id}] {Nazwa} - Cene: {Cena:F2} zł");
        }
    }

    class Program
    {
        // Atrybut statyczny symulujący tabelę w bazie danych
        private static List<Produkt> _bazaDanych = new List<Produkt>();
        private static int _nextId = 1;

        static void Main(string[] args)
        {
            Console.WriteLine("--- C# Baza Danych (CRUD) uruchomiona ---");
            
            // 1. CREATE (Dodawanie obiektów do bazy)
            DodajProdukt("Podręcznik do Informatyki", 49.99);
            DodajProdukt("Myszka Bezprzewodowa", 89.00);
            DodajProdukt("Klawiatura Mechaniczna", 249.50);

            // 2. READ (Odczyt wszystkich danych)
            WyswietlWszystkie();

            // 3. UPDATE (Aktualizacja ceny podmiotu o ID: 2)
            AktualizujCene(2, 79.99);

            // 4. DELETE (Usunięcie obiektu o ID: 1)
            UsunProdukt(1);

            // Ponowny odczyt po modyfikacjach
            Console.WriteLine("\n--- Stan bazy po operacjach UPDATE i DELETE ---");
            WyswietlWszystkie();
        }

        static void DodajProdukt(string nazwa, double cena)
        {
            if (string.IsNullOrWhiteSpace(nazwa) || cena < 0) return;
            
            _bazaDanych.Add(new Produkt { Id = _nextId++, Nazwa = nazwa, Cena = cena });
            Console.WriteLine($"[SQL] Dodano produkt: {nazwa}");
        }

        static void WyswietlWszystkie()
        {
            Console.WriteLine("\n[SQL SELECT * FROM Produkty]:");
            if (!_bazaDanych.Any()) Console.WriteLine("Baza jest pusta.");
            foreach (var p in _bazaDanych) p.PokazInformacje();
        }

        static void AktualizujCene(int id, double nowaCena)
        {
            var produkt = _bazaDanych.FirstOrDefault(p => p.Id == id);
            if (produkt != null)
            {
                produkt.Cena = nowaCena;
                Console.WriteLine($"\n[SQL UPDATE] Zmieniono cenę produktu o ID {id} na {nowaCena} zł");
            }
        }

        static void UsunProdukt(int id)
        {
            var produkt = _bazaDanych.FirstOrDefault(p => p.Id == id);
            if (produkt != null)
            {
                _bazaDanych.Remove(produkt);
                Console.WriteLine($"\n[SQL DELETE] Usunięto produkt o ID {id}");
            }
        }
    }
}
