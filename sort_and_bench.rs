use std::time::Instant;

// Implementacja klasycznego algorytmu sortowania (Wymaganie CKE)
fn bubble_sort(arr: &mut [i32]) {
    let n = arr.len();
    for i in 0..n {
        for j in 0..n - i - 1 {
            if arr[j] > arr[j + 1] {
                arr.swap(j, j + 1);
            }
        }
    }
}

fn main() {
    println!("--- Rust: Algorytmy i Benchmarking ---");

    // Generowanie nieposortowanego wektora danych
    let mut dane = vec![64, 34, 25, 12, 22, 11, 90, 5, 88, 41, 1, 19];
    println!("Przed sortowaniem: {:?}", dane);

    // Rozpoczęcie precyzyjnego pomiaru czasu (Systemowy moduł std::time)
    let start = Instant::now();

    // Wywołanie algorytmu przez bezpieczną referencję mutowalną (&mut)
    bubble_sort(&mut dane);

    // Zakończenie pomiaru czasu
    let duration = start.elapsed();

    println!("Po sortowaniu:    {:?}", dane);
    
    // Wyświetlenie wyniku wydajności - kluczowy element dla projektów w Rust
    println!("\n[BENCHMARK] Czas wykonania algorytmu: {:?}", duration);
    println!("Wydajność mikro-sekundowa udowadnia optymalizację kodu systemowego.");
}
