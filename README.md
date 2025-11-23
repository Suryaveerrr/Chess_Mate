# ♟️ Unity Chess Architecture Prototype

![Unity](https://img.shields.io/badge/Unity-2020.3.40f1%20(LTS)-black?style=flat&logo=unity)
![Pattern](https://img.shields.io/badge/Pattern-OOP%20%2F%20Inheritance-blueviolet)
![Platform](https://img.shields.io/badge/Platform-Android%20%7C%20PC-3DDC84?style=flat&logo=android)

> **A technical prototype focusing on clean architecture, scalable code quality, and optimization.**

This project is not just a game; it is a demonstration of **Object-Oriented Design** principles applied to game development. It implements a modular chess engine where every piece adheres to a strict abstract contract, allowing for easy expansion and maintenance.

<img width="626" height="498" alt="image" src="https://github.com/user-attachments/assets/7abf6ad6-1c54-49dd-b5b2-cac6752a5abc" />
<img width="1096" height="515" alt="image" src="https://github.com/user-attachments/assets/00822d20-c428-4c59-a022-989feae8bc9a" />
<img width="1093" height="514" alt="image" src="https://github.com/user-attachments/assets/30fb836a-29b4-420a-9116-a204c9091727" />
![Uploading image.png…]()


---

## 📐 System Architecture

The core of this project relies on **Polymorphism** and **Inheritance** to handle move logic efficiently without giant `switch` statements.

### The Contract (`BasePiece.cs`)
The abstract base class that defines the core identity of any chess piece. It handles:
* Visual instantiation.
* Team assignment (White/Black).
* **Abstract Methods:** Defines the `GetAvailableMoves()` contract that all children must fulfill.

### Concrete Implementations
Each piece overrides the base logic to define its unique movement rules:
* `Rook.cs` (Sliding movement logic)
* `Knight.cs` (L-shape 'jump' logic)
* `Bishop.cs` / `Queen.cs` / `Pawn.cs`

---

## ⚙️ Development Environment

* **Engine:** Unity 2020.3.40f1 (LTS)
* **Platform Target:** Android & PC Standalone
* **Orientation:** Landscape (Optimized for 1920x1080)

---

## 🎮 How to Run

1.  **Open Project:** Launch Unity Hub and add the project (Unity 2020.3.X required).
2.  **Load Scene:** Navigate to `Assets/Scenes` and open **GameScene**.
3.  **View Setup:**
    * Ensure your Game View is set to **1920x1080 Landscape**.
    * *Note: Other resolutions may affect UI scaling in this prototype stage.*
4.  **Play:**
    * Press Play.
    * Click on any **White** (bottom) or **Black** (top) piece.
    * The engine will calculate and highlight all valid legal moves for that specific piece type.

---

## 🔍 Focus Areas

This prototype was built to demonstrate:
* ✅ **Scalable Architecture:** Adding a new custom piece (e.g., a "Wizard") only requires inheriting from `BasePiece` and writing one move function.
* ✅ **Code Quality:** Strong separation of concerns between the Input system, the Board Manager, and the Pieces.
* ✅ **Optimization:** Efficient move calculation algorithms.

---
