# Contributing Guide

Thank you for your interest in contributing to this small project.  
I'm welcome to bug reports, feature suggestions, documentation improvements, and some code contributions.

Please read this guide before opening an issue or pull request.

## How to Contribute

### Reporting Bugs
Please use the existing **[Bug Report Issue Template](https://github.com/The-Chest/TheChest.Core/issues/new?template=bug_report.md)** available in the **Issues** tab.  

### Requesting Features
For new features, open an issue using the **[Feature Request Issue Template](https://github.com/The-Chest/TheChest.Core/issues/new?template=feature_request.md)**.  

### Requesting Refactors / Improvements
For internal improvements (performance, maintainability, simplification, code cleanup, etc.), use the **[Refactor Request Issue Template](https://github.com/The-Chest/TheChest.Core/issues/new?template=refactor-request.md)**.

## Submitting Pull Requests

1. **Fork** the repository.
2. Create a feature branch:  
3. Add or update tests (using NUnit).
4. Submit a Pull Request. It'll run the test coverage

### About the CI Pipeline 

All Pull Requests must pass the automated pipeline before being merged into `master`.

The pipeline includes:

| Check                | Description                                                                                             |
| -------------------- | ------------------------------------------------------------------------------------------------------- |
| **Unit Tests**       | All NUnit tests must pass. No failing tests are allowed.                                                |
| **Code Coverage**    | Coverage is using Sonar. PRs that reduce coverage significantly may require justification.              |
| **CodeQL Analysis**  | Security and vulnerability scanning must pass with no new alerts.                                       |

Pull Requests failing any of these checks cannot be merged until fixed.

## Development Setup

### Requirements
* .NET Standard 2.1 / .NET 8 SDK (the SDK is )
* IDE: Visual Studio(recommended), JetBrains Rider, or VS Code

If your repo includes an `.editorconfig`, the IDE will apply these automatically.

### Code Style

The project follows these C# conventions:

* Using `var` for local variables when the type is obvious.
* Using `PascalCase` for public members and `camelCase` for private fields.
* Avoiding reflection unless needed for extensibility.

## Branching model

| Type    | Prefix     | Example                   | Purpose                        |
| ------- | ---------- | ------------------------- | ------------------------------ |
| Feature | `feat/`    | `feat/add-new-parser`     | New features or enhancements   |
| Feature | no prefix  | `add-new-parser`          | New features or enhancements   |
| Bugfix  | `fix/`     | `fix/null-ref-on-startup` | Bug fixes                      |

## Pull Request Checklist

Before submitting a PR, ensure:
- [ ] Code builds successfully
- [ ] All tests pass (dotnet test)
- [ ] New tests added (if applicable)
- [ ] Public APIs include XML documentation
- [ ] No breaking changes without discussion
- [ ] Follows coding style

## Documentation

When updating or adding APIs:
- [ ] Add or update XML documentation in the code.
- [ ] Update the README.md if needed.

## Versioning
This project follows Semantic Versioning (SemVer).

* MAJOR – breaking changes
* MINOR – new features, non-breaking
* PATCH – fixes only
