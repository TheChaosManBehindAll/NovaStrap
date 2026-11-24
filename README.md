 <div align="center">

<img src="Assets/chaosstrap-mark.png" width="190" alt="ChaosStrap"/>

# ChaosStrap

### TAKE CONTROL OF YOUR ROBLOX EXPERIENCE.

A Windows Roblox bootstrapper focused on performance, customisation and a better way to manage your Roblox client.

[**Explore the project**](https://github.com/TheChaosManBehindAll/ChaosStrap) · [**Report an issue**](https://github.com/TheChaosManBehindAll/ChaosStrap/issues) · [**View releases**](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)

<br/>

![Windows](https://img.shields.io/badge/Windows-10%20%7C%2011-9B2335?style=for-the-badge&logo=windows&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10-9B2335?style=for-the-badge&logo=dotnet&logoColor=white)
![Avalonia](https://img.shields.io/badge/UI-Avalonia-9B2335?style=for-the-badge)
![Language](https://img.shields.io/badge/Language-C%23-9B2335?style=for-the-badge&logo=csharp&logoColor=white)

</div>

---

## About ChaosStrap

ChaosStrap is an independent Roblox bootstrapper developed by **xphantomcorp**.

Its purpose is to give players more control over their Roblox experience, bringing launching, configuration, customisation and useful management tools together in one application.

We believe a bootstrapper should do more than simply open Roblox. It should make managing the client easier, provide meaningful options and stay out of the way when you're playing.

ChaosStrap is being developed with **C#**, **.NET 10** and **Avalonia UI**, targeting Windows 10 and Windows 11.

## The idea

<details>
<summary><strong>01 · Performance & control</strong></summary>

Useful configuration tools, FastFlag management and sensible performance options, without pretending that every setting magically increases FPS.

</details>

<details>
<summary><strong>02 · Customisation</strong></summary>

Manage supported modifications, organise configurations and make your Roblox setup your own.

</details>

<details>
<summary><strong>03 · Smarter launching</strong></summary>

Make launching Roblox, managing accounts and returning to your favourite experiences easier.

</details>

<details>
<summary><strong>04 · Reliability</strong></summary>

Clear diagnostics, safer updates, backups and recovery tools to help when something goes wrong.

</details>

## Features & development

ChaosStrap's development is organised around the following areas.

| Area | Planned capabilities |
|---|---|
| Roblox management | Installation, updates, repair and version management |
| Accounts | Account profiles and convenient switching |
| Launching | Quickplay, launch options and multi-instance support |
| FastFlags | Editing, validation, searching and profiles |
| Modifications | Mod installation, management and compatibility |
| Performance | Configuration tools and useful performance information |
| Discord | Rich Presence and playtime integration |
| Recovery | Diagnostics, configuration backups and restoration |

> [!IMPORTANT]
> ChaosStrap is in active development. The capabilities above describe the project's development direction, not a guarantee that every feature is currently available.

## Screenshots

Application screenshots will be added here as the interface becomes ready for public release.

## Installation

**Public release downloads are not yet available.**

When official builds are published, they will be distributed through the repository's Releases page.

[**View ChaosStrap Releases**](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)

> [!CAUTION]
> Only download executable files from the official ChaosStrap repository or other explicitly verified project distribution channels.

## Platform support

| Platform | Status |
|---|---|
| Windows 10 x64 | Development target |
| Windows 11 x64 | Development target |
| macOS | Not currently supported |
| Linux | Not currently supported |

ChaosStrap is currently focused on Windows. Other platforms may be considered in the future.

## Building from source

Interested in compiling ChaosStrap yourself?

### Requirements

- Windows 10 or Windows 11.
- Git.
- .NET 10 SDK.
- Inno Setup 6, if you intend to compile the installer.

### 1. Clone the repository

```bash
git clone https://github.com/TheChaosManBehindAll/ChaosStrap.git
cd ChaosStrap
```

### 2. Restore dependencies

```bash
dotnet restore ChaosStrap.csproj
```

### 3. Build

```bash
dotnet build ChaosStrap.csproj -c Release
```

### 4. Publish

```bash
dotnet publish ChaosStrap.csproj -c Release -r win-x64 --self-contained true -o publish/win-x64
```

The published application will be located in:

```text
publish/win-x64/
```

### Project technology

| Component | Technology |
|---|---|
| Language | C# |
| Framework | .NET 10 |
| Interface | Avalonia UI |
| Installer | Inno Setup |
| CI/CD | GitHub Actions |

## Contributing

Contributions, suggestions and bug reports are welcome.

Before opening an issue or pull request:

1. Check whether the issue has already been reported.
2. Explain the problem or proposed improvement.
3. Include useful reproduction steps for bugs.
4. Keep contributions focused and easy to review.

[**Open an issue**](https://github.com/TheChaosManBehindAll/ChaosStrap/issues)

## Security

Please report security vulnerabilities privately rather than publishing sensitive details in a public issue.

Security reporting instructions will be provided as the project establishes its disclosure process.

## Licensing

The project's licence and third-party notices will be documented in the repository before public distribution.

## Support ChaosStrap

If you like the direction of the project, consider starring the repository. It helps people discover ChaosStrap and follow its development.

<div align="center">

[![Star on GitHub](https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=for-the-badge&color=9B2335&logo=github)](https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers)

<br/>

**CHAOSSTRAP**

*Built for a better way to play Roblox.*

<sub>Developed by xphantomcorp.</sub>

</div>
