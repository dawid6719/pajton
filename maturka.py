"""
Temat: Parser i Analizator Danych pod kątem zadań maturalnych.
"""
import os

def czy_liczba_pierwsza(n):
    """Sprawdza czy liczba jest pierwsza"""
    if n < 2:
        return False
    for i in range(2, int(n**0.5) + 1):
        if n % i == 0:
            return False
    return True

def czy_palindrom(tekst):
    """Sprawdza czy podany ciąg znaków czyta się tak samo od tyłu"""
    tekst = tekst.strip().lower()
    return tekst == tekst[::-1]

def generuj_plik_testowy():
    """Generuje przykładowe dane wejściowe, jeśli plik nie istnieje"""
    dane = ["kajak", "17", "potop", "24", "matura", "13", "programowanie", "121", "anna"]
    with open("dane.txt", "w", encoding="utf-8") as f:
        for element in dane:
            f.write(f"{element}\n")
    print("[INFO] Wygenerowano testowy plik 'dane.txt'.")

def analizuj_dane(sciezka_pliku):
    """Główna funkcja przetwarzająca plik tekstowy wiersz po wierszu"""
    if not os.path.exists(sciezka_pliku):
        print(f"[BLAD] Plik {sciezka_pliku} nie istnieje!")
        return

    licznik_palindromow = 0
    liczby_pierwsze = []
    najdluzszy_napis = ""

    print(f"\n--- ROZPOCZĘCIE ANALIZY PLIKU: {sciezka_pliku} ---")
    
    with open(sciezka_pliku, "r", encoding="utf-8") as plik:
        for linia in plik:
            wartosc = linia.strip()
            if not wartosc:
                continue

            # 1. Analiza tekstowa - Palindromy
            if czy_palindrom(wartosc):
                licznik_palindromow += 1

            # 2. Analiza długości napisów
            if len(wartosc) > len(najdluzszy_napis):
                najdluzszy_napis = wartosc

            # 3. Analiza liczbowa - Liczby pierwsze
            if wartosc.isdigit():
                liczba = int(wartosc)
                if czy_liczba_pierwsza(liczba):
                    liczby_pierwsze.append(liczba)

    # Prezentacja wyników analizy
    print("\n[WYNIKI ANALIZY]:")
    print(f"-> Liczba znalezionych palindromów: {licznik_palindromow}")
    print(f"-> Najdłuższy wyraz w pliku: '{najdluzszy_napis}' (Długość: {len(najdluzszy_napis)})")
    print(f"-> Znalezione liczby pierwsze: {liczby_pierwsze}")
    print("-" * 40)

if __name__ == "__main__":
    # Automatyczne przygotowanie środowiska do uruchomienia
    if not os.path.exists("dane.txt"):
        generuj_plik_testowy()
        
    analizuj_dane("dane.txt")
