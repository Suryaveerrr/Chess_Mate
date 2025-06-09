Chess_Mate
by Suryaveer Bhandari

This project is a chess move visualizer built using Unity 2020.3 LTS. The application highlights all legal moves for any chess piece when clicked, strictly focusing on rule-based movement logic and visual feedback, without implementing actual piece movement or turn-based gameplay.



-> Project Goal

The primary objective of this project is to showcase clear object-oriented design, clean separation of responsibilities, and rule-driven logic in a Unity-based 2D environment. The focus is on correctness, maintainability, and structure—not on UI polish or gameplay mechanics.


- Click any piece to view its valid legal moves based on standard chess rules.
- Green dots represent valid move positions.
- Red squares represent enemy pieces that can be captured.
- A red circle appears under the selected piece.
- No piece movement or game rules like turns are implemented intentionally.


Project Structure and Design Decisions

1. Modular Piece Architecture
Each chess piece (Pawn, Knight, Bishop, etc.) is a separate class inheriting from a base `ChessPiece` class. This structure allows:

- Centralized click and highlight logic
- Piece-specific movement logic through overridden methods
- Easy future extension for new behavior (movement, animations, AI)

 2. Board State Tracking
A singleton `BoardManager` maintains a 2D array (`boardState[row, col]`) that holds real-time positions of all pieces. This enables:

- Fast collision and capture checking
- Rule enforcement like blocking or capturing
- No reliance on GameObject hierarchy for logic

 3. UI Highlight Handler
All visual feedback (green dot, red square, red circle) is handled by a centralized `ChessBoardPlacementHandler` script. This ensures:

- Clean separation of visual and logic concerns
- Reusability of prefabs
- Easy future upgrade to animations or effects

 4. Runtime Tile Initialization
The chessboard is composed of GameObjects grouped by rows (`Row (0)` through `Row (7)`). Tiles are detected dynamically at runtime and stored in a 2D array for consistent spatial mapping and visual placement.

 5. Inspector-Driven Setup
Each piece's position is defined by serialized `row` and `column` fields, making it easy to reposition pieces in the Unity Editor. This also aligns with the tile matrix for automatic snapping.


 How It Works

1. When a piece is clicked:
   - It clears previous highlights
   - Highlights itself with a red circle
   - Calculates its legal moves using its own movement logic
   - Highlights each valid move as:
     - Green dot (if tile is empty)
     - Red square (if tile contains an enemy piece)

2. Tiles are initialized from the scene based on row naming and tile order, enabling automatic indexing without hardcoding.

3. The piece does not move. All logic stops at highlighting to focus entirely on rule-based path visualization.


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
