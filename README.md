# Nol3

## Overview

Nol3 is a Visual Studio solution for working with NOL3 communication flows. It groups reusable class libraries for core communication, FIXML handling, shared models, and supporting utilities, together with a console sample application and automated tests.

## Solution Contents

| Project | Purpose |
| --- | --- |
| `Nol3.Communication` | Main communication library and connector layer. |
| `Nol3.Communication.Models` | Shared request, response, and configuration models. |
| `Nol3.Communication.FIXML` | FIXML-focused helpers used by the communication layer. |
| `Nol3.Communication.Tools` | Supporting utilities and configuration helpers. |
| `Nol3.Communication.ConsoleTestApp` | Console application for manual testing and local experimentation. |
| `Nol3.Communication.Unit.Tests` | NUnit-based unit tests. |
| `Nol3.Communication.IntegrationTests` | NUnit-based integration tests. |

## Requirements

- Visual Studio 2019 or newer recommended
- .NET Framework 4.8 for most projects
- .NET Framework 4.5.2 for `Nol3.Communication.Tools`
- NuGet package restore enabled

## Getting Started

1. Clone the repository.
2. Open `Nol3.sln` in Visual Studio.
3. Restore NuGet packages if prompted.
4. Build the solution.

For manual verification, use `Nol3.Communication.ConsoleTestApp` and its `Nol3.Communication.config` file.

## Build and Test

- Build the full solution from `Nol3.sln`.
- Run `Nol3.Communication.Unit.Tests` for unit coverage.
- Run `Nol3.Communication.IntegrationTests` when the required integration environment is available.

## Repository Layout

```text
.
├── Nol3.sln
├── Nol3.Communication
├── Nol3.Communication.ConsoleTestApp
├── Nol3.Communication.FIXML
├── Nol3.Communication.IntegrationTests
├── Nol3.Communication.Models
├── Nol3.Communication.Tools
└── Nol3.Communication.Unit.Tests
```

## Contributing

Keep documentation and project references aligned when adding or renaming solution projects. If you introduce new setup steps, document them here so the solution remains easy to build and test.
