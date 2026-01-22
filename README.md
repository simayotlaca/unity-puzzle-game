# Unity Puzzle Game – Gameplay Systems Prototype

A tile-matching puzzle game prototype built in Unity to explore gameplay systems and technical design patterns.

## 🎮 Overview

This project demonstrates core gameplay systems including grid-based board management, match detection logic, scoring mechanics, and finite state machine (FSM) architecture. The focus is on clean, modular code that can scale to more complex game mechanics.

## ✨ Features

### Current Implementation
- **Grid-based Board System** – Dynamic grid creation and tile management
- **Match Detection Logic** – Horizontal and vertical pattern matching
- **Score & Combo System** – Progressive scoring with combo multipliers
- **FSM-based Game States** – Clean state transitions (Menu → Gameplay → GameOver)

### Planned Features
- Tile swap animations
- Special tile types (bombs, wildcards)
- Power-up system
- Level progression
- Sound effects and particle systems

## 🛠️ Technologies

- **Unity 2022.x** (or later)
- **C#** – Gameplay scripting
- **FSM Pattern** – State management
- **Object-Oriented Design** – Clean architecture

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── GameManagement/
│   │   ├── GameManager.cs          // Core game loop and state machine
│   │   ├── GameState.cs             // FSM states enum
│   │   └── ScoreManager.cs          // Score and combo tracking
│   ├── Grid/
│   │   ├── GridManager.cs           // Grid initialization and management
│   │   ├── Tile.cs                  // Individual tile logic
│   │   └── MatchDetector.cs         // Pattern matching logic
│   └── UI/
│       ├── UIManager.cs             // UI updates and menu control
│       └── GameOverUI.cs            // End screen logic
├── Scenes/
│   ├── MainMenu.unity
│   ├── Gameplay.unity
│   └── GameOver.unity
└── Prefabs/
    └── Tile.prefab
```

## 🎯 Core Systems

### Finite State Machine
The game uses a hierarchical FSM to manage game flow:
- **Menu State** – Player can start a new game
- **Gameplay State** – Active puzzle gameplay with input handling
- **GameOver State** – Display final score and retry option

### Grid System
- Configurable grid size (default 8x8)
- Dynamic tile spawning
- Gravity simulation for falling tiles

### Match Detection
- Scans for horizontal and vertical matches (3+ tiles)
- Efficient neighbor checking algorithm
- Combo detection for successive matches

### Scoring System
- Base points per tile matched
- Combo multiplier for chain reactions
- High score persistence

## 🚀 Getting Started

### Prerequisites
- Unity 2022.3 LTS or later
- Git

### Installation

1. Clone the repository:
```bash
git clone https://github.com/simayotlaca/unity-puzzle-game.git
cd unity-puzzle-game
```

2. Open the project in Unity Hub

3. Open the `MainMenu` scene from `Assets/Scenes/`

4. Press Play to start

## 📝 Development Notes

This project follows best practices for technical game design:
- **Modular architecture** – Each system is self-contained and reusable
- **State-driven behavior** – Clean separation of game phases
- **Data-driven design** – Easy to tweak parameters without code changes
- **Performance conscious** – Efficient algorithms for grid operations

## 🎓 Learning Focus

As a technical design exercise, this project emphasizes:
- Gameplay system architecture
- Real-time logic and state management
- Player feedback loops
- Scalable code patterns

## 📧 Contact

**Simay Otlaca**
Computer Science Student @ Sabancı University
Email: simay.otlaca@sabanciuniv.edu
GitHub: [@simayotlaca](https://github.com/simayotlaca)

---

*This project is part of my technical design portfolio. View more at [my portfolio](https://github.com/simayotlaca)*

