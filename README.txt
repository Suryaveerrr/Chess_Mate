CHESS ASSIGNMENT

OOP Inheritance: All pieces are children of one main BasePiece class.

OOP Polymorphism: The game calls GetPossibleMoves() and the right piece logic just works.

Strategy Pattern: Each piece has its own move "strategy" – no giant if/else mess!

Singleton Pattern: A single PieceManager controls the whole board state.

Clean Code (SRP): Each script has exactly one job to do.

Enemy Captures: Uses a separate "circle" prefab to highlight enemy pieces.

Provided Helpers: All highlighting is done through the ChessBoardPlacementHandler.

Landscape Mode: Project is set up for landscape orientation on mobile.