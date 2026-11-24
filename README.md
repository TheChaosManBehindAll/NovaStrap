<h1 align="center">ChaosStrap</h1>

<p align="center">
  <strong>Take control of your Roblox experience.</strong>
  <br />
  A Windows-first Roblox companion for launching, configuring and managing your local client.
</p>

<p align="center">
  <img src="./Assets/chaosstrap-mark.png" width="184" alt="ChaosStrap logo" />
</p>

<p align="center">
  <strong>Developed by xphantomcorp</strong>
</p>

<div align="center">

[![Stars](https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=for-the-badge&color=9B2335&logo=github&logoColor=white)](https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers)
![Status](https://img.shields.io/badge/status-early%20development-9B2335?style=for-the-badge)
![Platform](https://img.shields.io/badge/platform-Windows%2010%20%7C%2011-9B2335?style=for-the-badge&logo=windows&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10-9B2335?style=for-the-badge&logo=dotnet&logoColor=white)
![Language](https://img.shields.io/badge/language-C%23-9B2335?style=for-the-badge&logo=csharp&logoColor=white)
![UI](https://img.shields.io/badge/UI-Avalonia-9B2335?style=for-the-badge)

</div>

---

ChaosStrap is an independently developed Roblox bootstrapper project built around one idea: **the tools for managing your Roblox client should live in one clear, dependable place.**

The project is being built for Windows with **C#**, **.NET 10** and **Avalonia UI**. Its current foundation focuses on detecting the local Roblox Player installation, managing a small set of local preferences and editing the client's FastFlag configuration. Broader bootstrapper features are being developed separately and are not presented as finished functionality.

> [!IMPORTANT]
> **ChaosStrap is in early development.** It is not yet a complete replacement for the standard Roblox launcher or an established bootstrapper. Read [Current functionality](#current-functionality) and [Known limitations](#known-limitations) before trying the project.

## Contents

- [Current functionality](#current-functionality)
- [Planned features](#planned-features)
- [Download and installation](#download-and-installation)
- [Building from source](#building-from-source)
- [Configuration and data](#configuration-and-data)
- [Known limitations](#known-limitations)
- [Safety and privacy](#safety-and-privacy)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [Licensing](#licensing)

## Current functionality

The following describes the current foundation, not the long-term feature list.

| Component | Current state | Details |
|---|---|---|
| Roblox installation detection | Available | Detects the local Roblox Player installation on Windows. |
| Roblox handoff | Available | Opens the official Roblox experience hub so Roblox can perform its normal authenticated launch handoff. |
| Installation folder shortcut | Available | Opens the detected Roblox installation directory. |
| Launcher preferences | Available | Stores local preferences under the current Windows user's Local AppData directory. |
| FastFlag editor | Basic | Edits the detected version's `ClientSettings\ClientAppSettings.json` file as JSON. |
| Application navigation | Foundation | Navigation areas exist for Overview, FastFlags, Mod Manager, Appearance and Settings; not every page represents a completed feature. |

## Planned features

These are development goals. They should not be read as features available in the current build.

<details>
<summary><strong>Roblox management</strong></summary>

- A complete installation and bootstrap pipeline.
- Update delivery and installation repair.
- Roblox version and release-channel management.
- Multiple Roblox account management.
- Multi-instance support.

</details>

<details>
<summary><strong>Configuration and customisation</strong></summary>

- A fuller FastFlag editor with clearer validation and profile management.
- Mod installation, removal and organisation.
- Per-game configuration profiles.
- Import and export of settings.
- Customisable application appearance.

</details>

<details>
<summary><strong>Launching and integrations</strong></summary>

- Quickplay shortcuts.
- Server discovery and region selection.
- Discord Rich Presence and playtime integration.
- System-tray controls.

</details>

<details>
<summary><strong>Reliability</strong></summary>

- Configuration backups and restoration.
- Clearer diagnostics and actionable error messages.
- Safer update and recovery workflows.

</details>

The roadmap will change as features are implemented, tested and reviewed. A feature will only move into the current-functionality list once it actually works in a published build.

## Download and installation

**There is currently no published GitHub release.** Do not treat the source repository or an unofficial mirror as a finished installer distribution.

When public builds are ready, they will be published on the official [ChaosStrap Releases](https://github.com/TheChaosManBehindAll/ChaosStrap/releases) page. Use that page as the source of truth for available versions and download files.

> [!CAUTION]
> Only obtain ChaosStrap executables from the official `TheChaosManBehindAll/ChaosStrap` repository or a distribution channel explicitly linked from it. Do not trust third-party download sites claiming to host official builds.

## Building from source

ChaosStrap targets **Windows 10 and Windows 11 x64** and uses the .NET 10 SDK.

### Requirements

- Windows 10 or Windows 11.
- Git.
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- [Inno Setup 6](https://jrsoftware.org/isinfo.php), only if you want to compile the Windows installer.

### 1. Get the source

```powershell
git clone https://github.com/TheChaosManBehindAll/ChaosStrap.git
cd ChaosStrap
```

The source tree should contain `ChaosStrap.csproj` at its root. If the repository currently contains only a source ZIP, extract that archive and commit the project folders and files to the repository before following the commands below.

### 2. Restore dependencies

```powershell
dotnet restore ChaosStrap.csproj
```

### 3. Build

```powershell
dotnet build ChaosStrap.csproj --configuration Release
```

### 4. Run locally

```powershell
dotnet run --project ChaosStrap.csproj
```

### 5. Publish a self-contained Windows build

```powershell
dotnet publish ChaosStrap.csproj `
  --configuration Release `
  --runtime win-x64 `
  --self-contained true `
  --output publish/win-x64
```

The published files will be placed in `publish/win-x64/`.

### 6. Compile the installer (optional)

After publishing, install Inno Setup 6 and run the compiler from the repository root:

```powershell
$compiler = "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"
& $compiler "installer\ChaosStrap.iss"
```

The installer script expects the published application in `publish/win-x64/`. If compilation fails, check that publishing completed successfully and that the Inno Setup script and asset paths are present.

> [!NOTE]
> These instructions describe the current project layout and build approach. They do not imply that every build has been tested on every Windows configuration. If a command fails, include the full command and build output when reporting the problem.

## Configuration and data

ChaosStrap stores its launcher preferences locally for the signed-in Windows user:

```text
%LOCALAPPDATA%\Chaos6Interactive\ChaosStrap
```

The current FastFlag editor targets the `ClientSettings\ClientAppSettings.json` file inside the detected Roblox version directory. It edits local client configuration; it does not guarantee that Roblox will accept or act on every flag entered.

Before manually editing configuration files, close Roblox and keep a backup of any file you intend to change.

## Known limitations

- **The current launch action does not directly start `RobloxPlayerBeta.exe`.** It opens the official Roblox experience hub and lets Roblox complete its normal authenticated handoff. A direct client launch requires a valid Roblox-issued launch ticket; simply starting the executable is not a supported substitute.
- The FastFlag editor is a basic JSON editor, not a guarantee that a flag is supported, permitted or effective.
- The Mod Manager, account management, update delivery, channel switching, server browser, region selection, Discord integrations, system-tray controls and full bootstrap/install pipeline are not implemented in the current foundation.
- Windows is the current development target. macOS and Linux are not supported at this stage.

## Safety and privacy

ChaosStrap is intended to manage local Roblox configuration and the normal Roblox launch flow. It does **not** bypass Roblox security, modify anti-cheat components or inject code into the Roblox process.

The current FastFlag editor writes to the local Roblox client settings JSON file. Roblox may ignore unsupported or unrecognised settings. Changing client configuration can affect how Roblox behaves, so only use settings you understand and keep backups of important files.

ChaosStrap is an independent third-party project and is **not affiliated with, endorsed by or sponsored by Roblox Corporation**.

## Troubleshooting

When reporting a problem, include:

1. Your Windows version (Windows 10 or 11, including the build if known).
2. The ChaosStrap version or commit you are running.
3. The steps that reproduce the issue.
4. The complete error message or relevant build output.

Search [existing issues](https://github.com/TheChaosManBehindAll/ChaosStrap/issues) before [opening a new one](https://github.com/TheChaosManBehindAll/ChaosStrap/issues/new). Do not include passwords, authentication cookies, access tokens or other private account information in an issue.

## Contributing

Bug reports, focused improvements and practical feature suggestions are welcome. Before opening a pull request, please open an issue for larger changes so the intended behaviour can be discussed first.

- [Browse open issues](https://github.com/TheChaosManBehindAll/ChaosStrap/issues)
- [Suggest an improvement](https://github.com/TheChaosManBehindAll/ChaosStrap/issues/new)
- [View the repository](https://github.com/TheChaosManBehindAll/ChaosStrap)

Please keep contributions focused, avoid unrelated formatting changes and describe how the change was tested.

## Licensing

A repository-level `LICENSE` file has not yet been published. Until a licence is added, do not assume that the source code may be redistributed, relicensed or reused. The project licence and any third-party notices should be added before public distribution.

---

<div align="center">

**ChaosStrap** · Developed by **xphantomcorp**

*Built for a better way to manage and play Roblox.*

[Back to top](#chaosstrap)

</div>
