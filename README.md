# Space Shooter
## Project Description
This is an arcade-style spaceship shooter developed in Unity and written in C#. Players control a spaceship, navigating through space while firing at asteroids and enemies, dodging enemy projectiles, and collecting power-ups. If the game persists for too long, it enters Onslaught Mode, dramatically increasing the challenge.

The game was built using a C# game development tutorial as a foundation, but it was expanded and modified to include new mechanics such as power-ups, increasing difficulty, and different asteroid types.

## Features
- Spaceship Combat: Fire at asteroids and enemy ships while avoiding their attacks.
- Power-Ups: Collect items that enhance your laser.
- Wave Spawning System: Enemies spawn in structured waves controlled by IEnumerator.
- Onslaught Mode: If the game lasts too long, difficulty spikes to test player's skill.

## Repository Structure
---
### Folders
```Assets/``` – Main game content, including:

- C# scripts for game mechanics
- Sprites, models, and animations
- Audio files (music and sound effects)
- Prefabs for enemies, power-ups, and objects
- Unity scenes (game environments and levels)
- Packages/ – Unity package dependencies and external libraries used in the project.

```ProjectSettings/``` – Stores Unity project settings, including:

```Build/``` - contains finished game files with .exe to run them

```Packages/``` - Lists relevant dependencies

### Files
```.gitignore``` – Specifies files to be ignored by Git
```.gitattributes``` – Defines Git settings for handling line endings and file diffs.

### To Play the Game
Clone this repository
Run the game in the Unity Editor or utilize the provided build

### Demo Screenshots
---
#### Fighting
![Demo1](demo_1.png)
#### Game Over
![Demo2](demo_2.png)
#### Maneuvering
![Demo3](demo_3.png)
