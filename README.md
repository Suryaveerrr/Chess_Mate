#  Chessmate Move Visualizer  

A Unity-based chess visualization project that demonstrates clean **Object-Oriented Programming (OOP)** and **design patterns** while providing an interactive way to visualize chess piece movements.  

---

##  Features  

- **OOP Inheritance** – All chess pieces inherit from a single `BasePiece` class.  
- **Polymorphism** – Movement logic is automatically resolved via `GetPossibleMoves()`.  
- **Strategy Pattern** – Each piece has its own movement strategy (no massive if/else chains).  
- **Singleton Pattern** – A single `PieceManager` oversees and manages the entire board.  
- **Clean Code (SRP)** – Each script does exactly one job, following the **Single Responsibility Principle**.  
- **Enemy Capture Highlighting** – A dedicated **circle prefab** highlights enemy pieces available for capture.  
- **Helper Utilities** – `ChessBoardPlacementHandler` manages move highlighting.  
- **Mobile Friendly** – Optimized for **landscape orientation** on mobile.  

---
