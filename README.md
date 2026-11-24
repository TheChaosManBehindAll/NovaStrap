<div align="center">
  <img src="./Assets/chaosstrap-mark.png" width="156" alt="ChaosStrap logo" />
  <h1>ChaosStrap</h1>
  <p><strong>Roblox client management for Windows.</strong></p>
  <p>Configure your client, manage local settings and launch Roblox through a focused desktop application.</p>
  <p><sub>Independently developed by <strong>xphantomcorp</strong></sub></p>
  <br />
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers">
    <img src="https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=flat-square&color=9B2335&label=stars" alt="GitHub stars" />
  </a>
  <img src="https://img.shields.io/badge/platform-Windows%2010%20%7C%2011-9B2335?style=flat-square" alt="Windows 10 and 11" />
  <img src="https://img.shields.io/badge/.NET-10-9B2335?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/UI-Avalonia-9B2335?style=flat-square" alt="Avalonia UI" />
</div>

---

ChaosStrap is an independent, Windows-first Roblox bootstrapper project. It is being developed to make common client-management tasks easier to understand and control from one desktop application.

The project is built with **C#**, **.NET 10** and **Avalonia UI**. Its current codebase is an early foundation: it can detect a local Roblox Player installation, open the official Roblox experience hub, store local preferences and edit the local FastFlag JSON file. A complete replacement for the standard Roblox installer and launcher is not available yet.

> [!NOTE]
> **Development status: early development.** There is no public installer release at this time. The sections below distinguish working functionality from planned work so you can see exactly what is and is not available.

## Contents

- [Project status](#project-status)
- [What works today](#what-works-today)
- [Development roadmap](#development-roadmap)
- [Downloads](#downloads)
- [Build from source](#build-from-source)
- [Local data and FastFlags](#local-data-and-fastflags)
- [Compatibility and safety](#compatibility-and-safety)
- [Reporting a problem](#reporting-a-problem)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
- [License](#license)

## Project status

| | Current position |
|---|---|
| Project stage | Early development / prototype |
| Maintainer | xphantomcorp |
| Target platform | Windows 10 and Windows 11 (x64) |
| Application stack | C#, .NET 10, Avalonia UI |
| Public installer | Not released |
| Distribution | Source archive only; no installer release |

ChaosStrap is being developed as a **maintainer-led independent project**. Features are added to the available-feature list only after they have been implemented. A planned feature is not a promise that it is already present in a build.

## What works today

The current foundation includes the following functionality:

| Area | Available behaviour |
|---|---|
| Roblox detection | Detects the local Roblox Player installation on Windows. |
| Roblox launch handoff | Opens the official Roblox experience hub and leaves the authenticated launch flow to Roblox. |
| Installation shortcut | Opens the detected Roblox installation directory. |
| Local preferences | Saves application preferences for the current Windows user. |
| FastFlag editing | Provides a basic JSON editor for `ClientAppSettings.json` in the detected Roblox version directory. |
| Application navigation | Includes the initial Overview, FastFlags, Mod Manager, Appearance and Settings navigation structure. Some destinations are still placeholders. |

### Current launch behaviour

The launch action currently opens the official Roblox experience hub. Roblox then handles its normal authenticated handoff to the client. ChaosStrap does **not** currently perform a complete bootstrap, install or direct client-launch sequence.

### Current FastFlag behaviour

The FastFlag page edits the local `ClientAppSettings.json` file as JSON. It is a basic configuration editor, not a catalogue of verified settings. Saving a flag does not guarantee that Roblox recognises, allows or applies it.

## Development roadmap

These are the main areas being considered or developed. They are not available features unless listed in [What works today](#what-works-today).

| Area | Intended work |
|---|---|
| Bootstrap and installation | Install, update and repair workflows; safer handling of Roblox version changes. |
| Launch management | A complete launch pipeline, launch options and multi-instance support. |
| Accounts | Convenient local account management and switching. |
| FastFlags | Validation, search, profiles, import and export. |
| Mod management | Install, organise and remove supported client customisations. |
| Roblox versions | Version and release-channel management. |
| Server tools | Quickplay, server discovery and region selection. |
| Integrations | Discord Rich Presence and playtime tracking. |
| Diagnostics | Clear error reporting, configuration backups and recovery tools. |

The roadmap is intentionally flexible. Priorities may change as Roblox updates its client, APIs or distribution behaviour.

## Downloads

**No public installer is available yet.** The GitHub Releases page is the official place where packaged builds will be published when they are ready:

**[View ChaosStrap releases](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)**

Until a release is published, the repository should be treated as a development project, not as a ready-to-install Roblox replacement. Be cautious of third-party websites claiming to distribute official ChaosStrap installers.

## Build from source

ChaosStrap can be built from its source project on Windows.

### Requirements

- Windows 10 or Windows 11, x64.
- [Git](https://git-scm.com/downloads).
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- [Inno Setup 6](https://jrsoftware.org/isinfo.php), only if you want to compile the installer.

### 1. Obtain the source

The current GitHub repository contains a source archive rather than an extracted project tree. Download the archive from the repository's **Code** page, extract it, and open PowerShell in the directory that contains `ChaosStrap.csproj`.

When the source files are committed directly to the repository, this step can be replaced with a normal `git clone` workflow.

### 2. Restore dependencies

```powershell
dotnet restore .\ChaosStrap.csproj
```

### 3. Build

```powershell
dotnet build .\ChaosStrap.csproj --configuration Release
```

### 4. Run the application

```powershell
dotnet run --project .\ChaosStrap.csproj
```

### 5. Publish a self-contained Windows build

```powershell
dotnet publish .\ChaosStrap.csproj `
  --configuration Release `
  --runtime win-x64 `
  --self-contained true `
  --output .\publish\win-x64
```

The published application files will be written to `publish\win-x64\`.

### 6. Compile the installer (optional)

After publishing, install Inno Setup 6 and run its compiler from the project root:

```powershell
$compiler = "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"
& $compiler ".\installer\ChaosStrap.iss"

if ($LASTEXITCODE -ne 0) {
    throw "Inno Setup compilation failed."
}
```

The installer script expects the published files in `publish\win-x64\`. If compilation fails, confirm that publishing completed and that the paths referenced by `installer\ChaosStrap.iss` exist.

> [!TIP]
> For a useful bug report, include the command you ran and the complete build output. A screenshot of the final error line alone often omits the cause.

## Local data and FastFlags

ChaosStrap stores its application preferences locally for the signed-in Windows user. The current application data directory is:

```text
%LOCALAPPDATA%\Chaos6Interactive\ChaosStrap
```

The FastFlag editor targets `ClientSettings\ClientAppSettings.json` inside the detected Roblox version directory.

Before editing Roblox configuration manually:

1. Close Roblox Player and Studio.
2. Keep a copy of the existing settings file.
3. Change only settings you understand.
4. Remember that Roblox may ignore settings that are unsupported or no longer permitted.

FastFlags are client configuration values. They are not guaranteed performance optimisations, and entering a value does not mean Roblox will use it.

## Compatibility and safety

- **Windows only:** Windows 10 and Windows 11 x64 are the current development targets. macOS and Linux are not supported at this stage.
- **Independent project:** ChaosStrap is not affiliated with, endorsed by or sponsored by Roblox Corporation.
- **Normal Roblox launch flow:** The current launcher action hands off to Roblox's official experience hub. It does not bypass Roblox authentication.
- **Local configuration:** The current FastFlag editor writes to a local Roblox settings file. Unsupported values may be ignored and may change client behaviour.
- **No performance guarantees:** Configuration changes can have different results across devices and Roblox updates. ChaosStrap does not promise an FPS increase from FastFlags.

## Reporting a problem

Before opening an issue, check whether someone has already reported the same problem. If it is new, use the [GitHub issue tracker](https://github.com/TheChaosManBehindAll/ChaosStrap/issues) and include:

1. Your Windows edition and version (Windows 10 or 11).
2. The ChaosStrap version or source commit you are using.
3. The steps needed to reproduce the problem.
4. What you expected to happen and what happened instead.
5. The complete error message or relevant build output.

Remove passwords, authentication cookies, access tokens and other private information from logs before posting them. Do not include Roblox account credentials in an issue.

## Maintainer

ChaosStrap is a **solo-maintained project** by **xphantomcorp**. The maintainer handles implementation, issue triage, reviews, releases and documentation. As with any one-person project, response times and release dates depend on availability; there is no promised release schedule.

The project is developed in public, and this README is intended to reflect the current code rather than advertise unfinished features. Clear bug reports and reproducible test cases are especially helpful.

## Contributing

Focused bug reports, improvements and pull requests are welcome. For a larger change, open an issue first so the proposed behaviour can be discussed before work begins.

- [Open an issue](https://github.com/TheChaosManBehindAll/ChaosStrap/issues)
- [Browse the source repository](https://github.com/TheChaosManBehindAll/ChaosStrap)

## License

A repository-level `LICENSE` file has not been published yet. Until a license is added, no open-source reuse or redistribution rights are granted by this README. The project license and any applicable third-party notices need to be established before public distribution.

---

<div align="center">
  <strong>ChaosStrap</strong><br />
  <sub>Independently developed by xphantomcorp.</sub>
</div>
