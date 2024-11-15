# Unity Platformer Game
This project is a 2D platformer game built with Unity. The game includes various features such as player movement, item collection, level progression, and platform interactions. This README provides an overview of the scripts and their functionalities.

## Features
Player Movement: Smooth 2D movement with jumping mechanics.
Item Collection: Collect items scattered across the level.
Level Completion: Complete levels by reaching specific goals.
Interactive Platforms: Platforms with dynamic behaviors.
Start Menu: A user-friendly interface to start and navigate the game.
Game Over Handling: Restart the level upon player life depletion.
Info Button: Displays helpful information to the player.

## Scripts Overview
1. FallingPlatform.cs
Handles platforms that fall after the player steps on them. It introduces a delay before the platform falls, providing dynamic and challenging gameplay.

Features:

Trigger-based platform fall mechanics.
Adjustable fall delay.
2. GameResult.cs
Manages the display of the game result (win/lose). It handles end-of-game events and ensures the player is directed to appropriate menus.

Features:

Displays game results.
Handles end-game transitions.
3. InfoBtn.cs
Implements functionality for an information button in the UI. Useful for guiding new players.

Features:

Displays help/information.
Easy integration with UI systems.
4. ItemCollector.cs
Tracks and manages collectible items in the game. Keeps count of collected items and updates the game state accordingly.

Features:

Tracks collected items.
Interacts with level progression.
5. LevelComplete.cs
Handles level completion logic. Once the player reaches the end of a level, this script takes over to manage the transition to the next level or the game end.

Features:

Level transition management.
End-of-level events.
6. ObjectMovement.cs
Controls the movement of objects, such as moving platforms or hazards, providing dynamic level interactions.

Features:

Configurable object movement patterns.
Adds challenge and interactivity.
7. Player_Movement.cs
Handles player movement and input. Implements physics-based movement and animations.

Features:

Smooth movement with jump functionality.
Animation handling.
8. PlayerLife.cs
Tracks the player's life status. Handles logic for player death and level restarts.

Features:

Detects hazards.
Restarts levels upon death.
9. StartMenu.cs
Implements functionality for the start menu. Allows the player to navigate game options before starting.

Features:

Start game button.
Quit functionality.
10. StayOnPlatform.cs
Ensures the player stays on moving platforms by parenting the player to the platform during contact.

Features:

Dynamic parenting for smooth platform movement.
How to Play
Launch the game.
Navigate the start menu to begin.
Use the arrow keys or WASD to move and jump.
Collect items and avoid hazards.
Complete levels by reaching the designated goal.
Enjoy the dynamic platforming challenges!
