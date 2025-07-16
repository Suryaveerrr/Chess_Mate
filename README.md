Chess_Mate is a chess move visualizer built using Unity 2020.3 LTS. The application highlights all legal moves for any selected chess piece based on standard rules. It is designed as a logic and architecture showcase, without piece movement or turn-based mechanics.

Project Goal
The goal of this project is to demonstrate:

Clear object-oriented architecture

Separation of concerns between logic and visuals

Strong foundation for rule-based logic in a 2D Unity environment

This is not a full chess game. The focus is purely on:

Correctness of movement rules

Visualizing legal moves

Clean modular design

How It Works
Click any piece on the board to see its valid moves

Visual feedback:

Green dots = legal move tiles

Red squares = capturable enemy pieces

Red circle = currently selected piece

No piece actually moves and no game rules like turns, check, or checkmate are implemented intentionally.

Key Architecture & Design Highlights
Modular Piece System
Each piece (Pawn, Knight, Bishop, etc.) inherits from a base ChessPiece class.

Movement rules are overridden in each derived class.

Allows centralized click handling with modular movement logic.

Board State Handling
A singleton BoardManager maintains a 2D array of piece positions.

Enables fast capture/block detection and rule checking.

Logic does not rely on Unity's GameObject hierarchy.

Visual Highlight System
All visual indicators (dots, squares, circle) are managed by ChessBoardPlacementHandler.

Keeps logic and visuals decoupled for easier maintenance and upgradeability.

Runtime Tile Initialization
The board consists of GameObjects grouped as rows: Row (0) to Row (7).

Each tile is dynamically indexed into a 2D matrix during runtime.

Inspector-Driven Setup
Each chess piece has exposed row and column fields.

Simplifies testing by allowing easy repositioning in the Unity Editor.
