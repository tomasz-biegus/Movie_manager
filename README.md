# 🎬 Movie Library App

A WPF desktop application for managing your personal movie collection, built with C# and MVVM pattern.

## Features

- 📋 **Two views** — "To Watch" and "Watched" lists filtered by status
- ➕ **Add movies** — title, genre, year, rating and status
- ✏️ **Edit movies** — update any movie details
- 🗑️ **Delete movies** — remove movies from the list
- 🎨 **Light/Dark theme** — switch between warm light and dark mode
- 💾 **SQLite database** — data persists between sessions

## Tech Stack

- C# / WPF (.NET 8)
- MVVM Architecture
- Entity Framework Core 8 + SQLite
- Repository Pattern

## Project Structure
```
Projekt_prog/
  WMW/
    ModeleWidokow/    # ViewModels
    Widoki/           # Views
  Modele/             # Data models
  Repozytoria/        # Repository pattern
  Dane/               # DbContext
  Motywy/             # Light/Dark theme dictionaries
```
