# Copilot Instructions for MoveIO_PhamTheTai

## Project Overview
This is a Unity-based game project. The codebase is organized by gameplay domains (Player, Enemy, Manager, Pooling, Weapon, etc.) under `Assets/Scripts/`. The project uses state machines for both player and enemy behaviors, pooling for performance, and a manager-driven architecture for game flow.

## Key Architectural Patterns
- **State Machines:**
  - Player and Enemy logic are separated into state machines (`Assets/Scripts/Player/StateMachine/`, `Assets/Scripts/Enemy/StateMachine/`).
  - Each state (e.g., `AttackState`, `RunState`, `DeathState`) implements a common interface (`IState` for Player, `EIState` for Enemy).
  - Example: To add a new player state, implement `IState` and register it in the player's state machine.
- **Pooling:**
  - Object pooling is handled in `Assets/Scripts/Pooling/` (e.g., `PoolControler.cs`, `HBPool.cs`).
  - Use pools for frequently spawned objects (enemies, projectiles, effects) to optimize performance.
- **Manager Pattern:**
  - Centralized managers (e.g., `GameManager.cs`, `LevelManager.cs`) coordinate game flow, level transitions, and UI.
  - Utilities and helpers are in `Assets/Scripts/Manager/Utilities.cs`.
- **Singletons:**
  - Some managers and utilities use the `Singleton` base class (`Assets/Scripts/Singleton.cs`).

## Developer Workflows
- **Building:**
  - Use Unity Editor's build menu. No custom build scripts are present.
- **Testing:**
  - No automated test scripts detected. Manual playtesting in the Unity Editor is standard.
- **Debugging:**
  - Use Unity's Inspector and Debug.Log for runtime debugging.

## Project-Specific Conventions
- **Naming:**
  - Prefix `E` for enemy-related scripts (e.g., `EGameUnit`, `EAttackState`).
  - State scripts are suffixed with `State` and grouped by domain.
  - Manager scripts are suffixed with `Manager`.
- **Directory Structure:**
  - Scripts are grouped by gameplay domain, not by type (e.g., all player scripts under `Player/`).
- **Meta Files:**
  - Unity meta files are present and should be preserved.

## Integration Points
- **External Dependencies:**
  - Uses Unity packages (Cinemachine, TextMeshPro, InputSystem, etc.) via `Packages/` and `.csproj` files.
  - No custom external service integrations detected.
- **Cross-Component Communication:**
  - Managers and state machines communicate via public methods and events.
  - Pooling system is accessed by gameplay scripts for object reuse.

## Examples
- To add a new enemy state: create a class in `Assets/Scripts/Enemy/StateMachine/` implementing `EIState`.
- To add a new pooled object: register it in `PoolControler.cs` and create a prefab in `Assets/Prefabs/`.

---

For more details, see the `Assets/Scripts/` directory and the relevant subfolders for each gameplay domain.
