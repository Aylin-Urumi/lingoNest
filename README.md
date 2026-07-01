# 🌐 LingoNest

A multilingual dictionary and translation desktop application built with C#, .NET, and Avalonia UI. Developed as a weekly project for an Object-Oriented Programming course.

---

## Features

- Translate text between 11 languages
- Instant translation powered by Google Translate API
- Translation history during the session
- Clean and simple cross-platform desktop UI
- Swap between source and target languages

## Supported Languages

| Language | Code |
|----------|------|
| English  | en   |
| Turkish  | tr   |
| Persian  | fa   |
| French   | fr   |
| German   | de   |
| Spanish  | es   |
| Italian  | it   |
| Arabic   | ar   |
| Russian  | ru   |
| Chinese  | zh   |
| Japanese | ja   |

---

## OOP Concepts Demonstrated

| Concept | Where Used |
|--------|------------|
| **Abstraction** | `ITranslationService` interface defines a contract for all translation services |
| **Encapsulation** | `WordEntry` and `Language` models encapsulate data with properties |
| **Inheritance** | `MyMemoryService` inherits from `BaseTranslationService` |
| **Polymorphism** | `MainWindowViewModel` depends on `ITranslationService`, not a concrete class |
| **Abstract Class** | `BaseTranslationService` provides shared logic and forces method overrides |
| **MVVM Pattern** | `MainWindowViewModel` separates UI logic from the view |

---

## Project Structure

```
LingoNest/
├── Models/
│   ├── Language.cs               # Language code and name
│   └── WordEntry.cs              # Translation result model
├── Interfaces/
│   └── ITranslationService.cs    # Contract for all translation services
├── Services/
│   ├── BaseTranslationService.cs # Abstract base class with shared logic
│   ├── MyMemoryService.cs        # Google Translate API implementation
│   └── MockTranslationService.cs # Offline mock for testing
├── ViewModels/
│   ├── MainWindowViewModel.cs    # Main MVVM ViewModel
│   └── ViewModelBase.cs          # Base ViewModel
├── Views/
│   └── MainWindow.axaml          # Main UI layout
├── App.axaml                     # Application entry point
└── Program.cs                    # Main program
```

---

## Technologies Used

- **C# / .NET 8** — primary language
- **Avalonia UI** — cross-platform desktop UI framework
- **ReactiveUI & Fody** — MVVM data binding
- **Newtonsoft.Json** — JSON parsing for API responses
- **Google Translate API** — free translation endpoint

---

## Getting Started

### Prerequisites

- .NET 8 SDK or later
- VS Code with the Avalonia extension

### Installation

1. Clone the repository:
```bash
git clone https://github.com/Aylin-Urumi/lingoNest.git
cd lingoNest/LingoNest
```

2. Install dependencies:
```bash
dotnet restore
```

3. Run the app:
```bash
dotnet run
```

---

## How to Use

1. Select the **source language** (language you are translating from)
2. Select the **target language** (language you want to translate to)
3. Type your text in the input box
4. Click the **→** button to translate
5. The translation appears in the right box
6. Your translation history is shown below during the session

---

## Author

**Aylin Urumi**  
Second Year Software Engineering Student  
OOP Weekly Project — 2026
