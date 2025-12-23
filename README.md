# 📚 Library Management System


---

## 📜 Problem Statement

An organization needs to manage:
- Book
- Member
- Search (Title, Author, Genre)
- Book borrowing and returns
- All Books

---

## 🌿 Branch Structure

| Branch | Purpose |
|--------|---------|
| `main` | Production-ready code |
| `dev` | Active development |
| `features/Library` | Library features |
| `features/ObjectCreation` | Classes |
| `features/main` | Main Method |

---

## 📁 Project Structure

```
LibraryManagementSystem/
├── .gitignore
└── LibraryManagementSystem/
    ├── LibraryManagementSystem.slnx
    └── LibraryManagementSystem/
        ├── LibraryManagementSystem.csproj
        ├── Library.cs
        └── File.txt(not used)
```

**Key Files:**
- `Library.cs` - Core logic and classes
- `LibraryManagementSystem.csproj` - Project
---

## 📊 Example Output

```
Search by Title: C#
Id: 3, Title: C# Basics, Author: Microsoft, Genre: Programming, Available: True

Search by Author: Rowling
Id: 2, Title: Harry Potter, Author: J.K. Rowling, Genre: Fantasy, Available: True

Search by Genre: Programming
Id: 1, Title: C++, Author: Raghav Raghuvanshi, Genre: Programming, Available: True
Id: 3, Title: C# Basics, Author: Microsoft, Genre: Programming, Available: True

Borrowing Book Id 1 by Member Id 1

Is Book 1 Available?
False

Returning Book Id 1

Is Book 1 Available?
True

All Books:
Id: 1, Title: C++, Author: Raghav Raghuvanshi, Genre: Programming, Available: True
Id: 2, Title: Harry Potter, Author: J.K. Rowling, Genre: Fantasy, Available: True
Id: 3, Title: C# Basics, Author: Microsoft, Genre: Programming, Available: True
```
---
