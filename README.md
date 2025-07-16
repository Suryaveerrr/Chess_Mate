# Chess_Mate

A chess move visualizer built using **Unity 2020.3 LTS**. This project highlights all legal moves for any clicked chess piece based on standard chess rules. It focuses purely on rule-based logic and visual feedback, with no actual movement or game mechanics like turns or check/checkmate.

---

## Features

**Object-Oriented Design**  
Each chess piece (Pawn, Knight, Bishop, etc.) inherits from a base `ChessPiece` class. Movement logic is modular and overridden in derived classes for clarity and maintainability.

**Accurate Rule Logic**  
Highlights valid moves based on standard chess rules. Capturable enemy pieces and valid empty tiles are distinguished visually.

**Visual Feedback System**  
- Green dots: Valid move positions  
- Red squares: Capturable enemy pieces  
- Red circle: Current selected piece  

**Board State Tracking**  
A singleton `BoardManager` maintains a 2D array of the chessboard, enabling fast lookup and rule checks without relying on GameObject hierarchy.

**Centralized Visuals**  
Highlight visuals are handled by a single script (`ChessBoardPlacementHandler`), decoupling logic from visuals and making upgrades easier.

**Runtime Tile Mapping**  
The board is composed of GameObjects grouped as `Row (0)` through `Row (7)` and tiles are indexed dynamically into a 2D grid at runtime.

**Inspector-Based Setup**  
Each piece uses serialized `row` and `column` values for positioning. This allows easy configuration directly from the Unity Editor.

---

## Improvements Over a Basic Visualizer

| Feature                   | Basic Visualizer          | This Project                         |
|---------------------------|---------------------------|--------------------------------------|
| Code Structure            | Monolithic or flat        | Clean OOP with inheritance           |
| Piece Movement Logic      | Static or hardcoded       | Modular per-piece logic              |
| Visuals                   | Minimal or none           | Green/Red highlighting system        |
| Board Handling            | Manual/hardcoded          | 2D grid with dynamic runtime linking |
| Gameplay                  | Often included            | Intentionally excluded               |
| UI/UX Separation          | Mixed with logic          | Fully separated                      |

---

## Tech Stack

**Engine:** Unity 2020.3 LTS  
**Language:** C#  
**Tools:** Unity Editor, Visual Studio

---

## Controls

- Click any piece to see its legal moves
- Game is static – no movement or turn system is implemented
