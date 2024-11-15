# Unity Platformer Game

This project is a 2D platformer game created in Unity. It features dynamic player movement, item collection, level transitions, and interactive platform mechanics. This README provides an overview of the project's scripts and gameplay mechanics.

## Features
- **Smooth Player Movement**: Intuitive and responsive movement system.
- **Interactive Platforms**: Falling and moving platforms for dynamic gameplay.
- **Item Collection**: Gather collectibles to progress or unlock achievements.
- **Level Completion**: Transition through levels upon completion.
- **Start Menu**: User-friendly interface for starting and navigating the game.
- **Game Over Handling**: Restart levels or view results upon losing.
- **Informational UI**: Info buttons to provide guidance to players.

---

## Scripts Overview

### 1. **FallingPlatform.cs**
Handles platforms that fall when stepped on, adding a time delay for challenge and variety.

**Key Features**:
- Trigger-based mechanics for detecting player presence.
- Adjustable delay before platforms fall.

---

### 2. **GameResult.cs**
Manages the display and handling of game results, such as victory or defeat screens.

**Key Features**:
- Displays win/lose messages.
- Directs the player to menus or restarts the game.

---

### 3. **InfoBtn.cs**
Implements a button to display helpful information to guide new players.

**Key Features**:
- Integrates with the Unity UI system.
- Configurable to display dynamic help messages.

---

### 4. **ItemCollector.cs**
Tracks collectible items and updates the player's progress accordingly.

**Key Features**:
- Keeps count of items collected during gameplay.
- Interacts with other scripts for level progression.

---

### 5. **LevelComplete.cs**
Handles the logic for completing a level and transitioning to the next.

**Key Features**:
- Detects level completion triggers.
- Manages level transition and event handling.

---

### 6. **ObjectMovement.cs**
Controls the movement of in-game objects, such as platforms and hazards.

**Key Features**:
- Configurable movement patterns (e.g., linear, oscillating).
- Enhances level dynamics with moving elements.

---

### 7. **Player_Movement.cs**
Manages player movement and physics. Includes jump mechanics and animations.

**Key Features**:
- Smooth horizontal movement.
- Jump functionality with physics-based calculations.
- Animation control for player actions.

---

### 8. **PlayerLife.cs**
Tracks player health and manages level restarts upon death.

**Key Features**:
- Detects collisions with hazards or deadly areas.
- Restarts levels or triggers game over screens.

---

### 9. **StartMenu.cs**
Implements the functionality of the start menu for the game.

**Key Features**:
- Start game and quit buttons.
- Handles navigation between game states.

---

### 10. **StayOnPlatform.cs**
Ensures the player remains on moving platforms during contact.

**Key Features**:
- Parents the player to the platform for smooth motion.
- Enhances gameplay on dynamic platforms.

---

## How to Play

1. Launch the game.
2. Use the start menu to begin.
3. Control the player using:
   - Arrow keys or **WASD** for movement.
   - **Space** to jump.
4. Collect items and avoid hazards.
5. Complete levels by reaching the goal.
6. Enjoy challenging platformer gameplay!

---

## Setup Instructions

1. Clone the repository or download the project files.
2. Open the project in Unity (compatible with Unity version XX.YY or later).
3. Add scenes to the build settings:
   - Start menu
   - Game levels
   - Result screens
4. Press the **Play** button in the Unity editor to test or build the game for your preferred platform.

---


