# Copilot Instructions for TheChest.Core

## Overview
- **TheChest.Core** is a C# library for building extensible container and slot-based inventory systems.
- Core abstractions: `Container<T>`, `Slot<T>`, and their interfaces (`IContainer<T>`, `ISlot<T>`, etc.).
- The library is designed for extension: inherit from base classes or implement interfaces for custom logic.
- Main code is in `src/TheChest.Core/`, with tests in `tests/TheChest.Core.Tests/`.

## Architecture & Patterns
- **Containers** hold multiple **Slots**; each Slot stores an item.
- Use `Container<T>`, `StackContainer<T>`, `LazyStackContainer<T>` for different behaviors.
- Slots have variants: `Slot<T>`, `StackSlot<T>`, `LazyStackSlot<T>`, each with their own interface.
- Interfaces are in `Containers/Interfaces/` and `Slots/Interfaces/`.
- Favor composition: containers are constructed with arrays of slots.
  - Example: `new Container<int>(new ISlot<int>[] { ... })`.
- Extend by subclassing or implementing interfaces for custom validation, size, or slot logic.

## Developer Workflows
- **Build:** Use `dotnet build TheChest.Core.sln` from the repo root.
- **Test:** Use `dotnet test TheChest.Core.sln` (tests are in `tests/TheChest.Core.Tests/`).
- **NuGet:** Package is published as `TheChest.Core`.
- **Coverage:** SonarCloud badge in README; coverage is tracked in CI.

## Project Conventions
- All containers and slots are generic (`<T>`), supporting any item type.
- Prefer explicit size validation in custom containers.
- Use `ISlot<T>[]` for slot arrays.
### Tests Conventions
- Tests are organized by container/slot type and feature (see `Containers/`, `Slots/` in tests).
- Custom attributes for test configuration are in `tests/TheChest.Core.Tests/Configurations/Attributes/`.
- Dependency injection helpers for tests are in `tests/TheChest.Core.Tests/Configurations/DependencyInjection/`.

## Integration & Extensibility
- No external runtime dependencies; pure C#/.NET Standard 2.1.
- Extend by subclassing or implementing interfaces (see README for examples).
- For new container/slot types, follow the pattern in `src/TheChest.Core/Containers/` and `src/TheChest.Core/Slots/`.

## Key Files & Directories
- `src/TheChest.Core/Containers/` — Container implementations & interfaces
- `src/TheChest.Core/Slots/` — Slot implementations & interfaces
- `tests/TheChest.Core.Tests/` — Test suite, organized by feature
- `readme.md` — Usage, extension, and architecture examples
- `docs/` — Additional documentation and design notes

---

For more, see the README and test directories for usage and extension patterns.
