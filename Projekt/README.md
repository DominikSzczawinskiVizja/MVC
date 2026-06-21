# 📚 System zarządzania zadaniami domowymi

Aplikacja webowa zbudowana w **ASP.NET Core 10 MVC** (Zadanie 4).

## Spis treści
1. [Funkcjonalności](#funkcjonalności)
2. [Struktura MVC](#struktura-mvc)
3. [Uruchomienie](#uruchomienie)

---

## Funkcjonalności

- ✅ **Wyświetlanie listy zadań** posortowanych po terminie
- ✅ **Dodawanie nowego zadania** (opis, termin, status)
- ✅ **Edycja zadania**
- ✅ **Usuwanie zadania** (z potwierdzeniem)
- ✅ **Szczegóły zadania** (widok pojedynczego obiektu)
- ✅ **Filtrowanie** po statusie (Do zrobienia / W trakcie / Zrobione)
- ✅ **Walidacja** po stronie serwera (wymagane pola, długość opisu)
- ✅ Wykrywanie **przeterminowanych** zadań
- ✅ Komunikaty potwierdzające akcje

## Struktura MVC

```
HomeworkManager/
├── Models/
│   ├── HomeworkTask.cs       ← Model z walidacją (DataAnnotations)
│   └── TaskRepository.cs     ← Warstwa danych (in-memory)
├── Controllers/
│   └── TasksController.cs    ← CRUD: Index, Create, Edit, Details, Delete
├── Views/
│   ├── Tasks/
│   │   ├── Index.cshtml      ← Lista z filtrowaniem
│   │   ├── Create.cshtml     ← Formularz dodawania
│   │   ├── Edit.cshtml       ← Formularz edycji
│   │   └── Details.cshtml    ← Widok szczegółów
│   └── Shared/
│       └── _Layout.cshtml    ← Wspólny layout
└── wwwroot/css/site.css      ← Style
```

## Uruchomienie

### Wymagania
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Kroki

```bash
# 1. Sklonuj repozytorium
git clone <URL>
cd HomeworkManager

# 2. Uruchom aplikację
dotnet run

# 3. Otwórz przeglądarkę
# http://localhost:5000
```

> Dane są przechowywane w cache
