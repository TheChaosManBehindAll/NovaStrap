<h1 align="center">ChaosStrap</h1>

<p align="center">
  <img src="https://raw.githubusercontent.com/TheChaosManBehindAll/ChaosStrap/main/Assets/chaosstrap-mark.png" width="184" alt="ChaosStrap application logo" />
</p>

<p align="center">
  <strong>Roblox client management for Windows.</strong>
  <br />
  A Windows-first bootstrapper project focused on client configuration, local management and a more controlled Roblox experience.
</p>

<p align="center">
  Independently developed and maintained by <a href="https://github.com/TheChaosManBehindAll"><strong>xphantomcorp</strong></a>.
</p>

<p align="center">
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/actions/workflows/build-windows.yml">
    <img src="https://github.com/TheChaosManBehindAll/ChaosStrap/actions/workflows/build-windows.yml/badge.svg?branch=main" alt="Windows build status" />
  </a>
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/actions/workflows/ci.yml">
    <img src="https://github.com/TheChaosManBehindAll/ChaosStrap/actions/workflows/ci.yml/badge.svg?branch=main" alt="Continuous integration status" />
  </a>
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers">
    <img src="https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=for-the-badge&amp;color=9B2335&amp;label=Stars" alt="GitHub stars" />
  </a>
  <img src="https://img.shields.io/badge/platform-Windows%2010%20%7C%2011-9B2335?style=for-the-badge" alt="Windows 10 and Windows 11" />
  <img src="https://img.shields.io/badge/.NET-10-9B2335?style=for-the-badge&amp;logo=dotnet&amp;logoColor=white" alt=".NET 10" />
  <img src="https://img.shields.io/badge/interface-Avalonia-9B2335?style=for-the-badge" alt="Avalonia UI" />
</p>

<p align="center">
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap">Repository</a>
  &nbsp;·&nbsp;
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/actions">Builds</a>
  &nbsp;·&nbsp;
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/issues">Issues</a>
  &nbsp;·&nbsp;
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/releases">Releases</a>
</p>

---

## Overview

**ChaosStrap** is an independently developed Windows application for managing Roblox client-related tasks from a desktop interface. The project is built with **C#**, **.NET 10** and **Avalonia UI**.

The long-term objective is to provide a reliable place to launch Roblox, manage client configuration, organise supported customisations and access useful player tools. Development is being approached incrementally: functionality is documented as it exists in the codebase, while unfinished systems remain identified as planned work.

ChaosStrap is currently in **early development**. The application has an initial interface, Roblox installation detection, a hand-off to Roblox's official experience website, local preference storage and a basic editor for the Roblox FastFlag JSON file. It is not yet a complete replacement for the standard Roblox installation or launch process.

> [!IMPORTANT]
> **Development build:** ChaosStrap is not currently distributed as a stable, public installer. Some parts of the interface are placeholders, and planned features should not be considered available until they are implemented and documented here.

## Contents

- [Project status](#project-status)
- [Current functionality](#current-functionality)
- [Interface overview](#interface-overview)
- [Development roadmap](#development-roadmap)
- [Downloads and build artifacts](#downloads-and-build-artifacts)
- [Build from source](#build-from-source)
- [Automated builds](#automated-builds)
- [Project structure](#project-structure)
- [Local data and configuration](#local-data-and-configuration)
- [FastFlag configuration](#fastflag-configuration)
- [Troubleshooting](#troubleshooting)
- [Security and privacy](#security-and-privacy)
- [Compatibility and Roblox disclaimer](#compatibility-and-roblox-disclaimer)
- [Reporting an issue](#reporting-an-issue)
- [Maintainer and contributions](#maintainer-and-contributions)
- [License](#license)

## Project status

| Item | Current status |
|---|---|
| Project stage | Early development |
| Project version in source | `0.2.0` |
| Maintainer | [xphantomcorp](https://github.com/TheChaosManBehindAll) |
| Primary platform | Windows 10 and Windows 11, x64 |
| Language | C# |
| Framework | .NET 10 |
| Desktop UI | Avalonia UI 12.1.3 |
| Windows packaging | Inno Setup 6 |
| Automated validation | GitHub Actions |
| Public installer release | Not published yet |
| Project license | Not specified in a repository `LICENSE` file yet |

The version shown above is the version recorded in the project source. It should not be interpreted as a published or supported release. Release availability is determined by the [GitHub Releases page](https://github.com/TheChaosManBehindAll/ChaosStrap/releases).

## Current functionality

The following table describes functionality present in the current application. It intentionally does not include roadmap items or interface placeholders as completed features.

| Area | Current behaviour | Status |
|---|---|---|
| Roblox installation detection | Searches common Windows Roblox version directories for `RobloxPlayerBeta.exe`. | Available |
| Launch hand-off | Opens the official Roblox experience hub in the default browser. Roblox handles the authenticated transition to the client. | Available |
| Installation access | Opens the detected Roblox installation directory in Windows Explorer. | Available |
| Installation status | Refreshes the detected installation state in the Overview page. | Available |
| Local preferences | Saves launcher preferences for the current Windows user. | Available |
| FastFlag file editor | Reads, reloads and saves the local `ClientAppSettings.json` file as formatted JSON. | Basic implementation |
| Mod management | The Mod Manager page is present in the interface, but mod installation and deployment are not implemented. | Planned |
| Discord Rich Presence | A disabled setting is visible in the interface; the integration is not implemented. | Planned |

### Roblox detection and launch behaviour

ChaosStrap looks for `RobloxPlayerBeta.exe` in common Roblox version directories. When an installation is detected, the Overview page displays its location and provides access to the installation folder.

The current **Launch Roblox** action opens the official Roblox experience hub (`https://www.roblox.com/home`). The user then starts an experience through Roblox's normal website and registered client hand-off.

This is not yet a custom bootstrap or direct client-launch implementation. ChaosStrap does not currently install Roblox, generate launch tickets, bypass Roblox authentication or replace the official sign-in flow.

### FastFlag editor behaviour

The FastFlag page provides a basic editor for the local `ClientAppSettings.json` file. It can load the current file, reload it and save valid JSON.

The editor currently validates JSON syntax. It does **not** provide a maintained FastFlag catalogue, Roblox allowlist validation, compatibility checking or a guarantee that Roblox will apply a particular value.

See [FastFlag configuration](#fastflag-configuration) for important usage notes.

## Interface overview

The current application includes the following navigation areas:

| Page | Current purpose |
|---|---|
| Overview | Displays Roblox detection status and provides the current launch and installation-folder actions. |
| FastFlags | Provides access to the local FastFlag JSON editor. |
| Mod Manager | Reserved for a future local modification-management system. No mod deployment is available yet. |
| Appearance | Shows the initial ChaosStrap appearance direction. A complete theme editor is not implemented. |
| Settings | Stores local launcher preferences. Some displayed options are not connected to completed features. |

The interface may change as the application develops. A page appearing in the navigation does not by itself mean the associated feature is fully implemented.

## Development roadmap

The roadmap records the intended direction of the project. It is not a release commitment, and priorities may change as Roblox updates its client, configuration behaviour or distribution process.

### Core application

- [x] Initial Avalonia desktop application.
- [x] Windows Roblox installation detection.
- [x] Basic Overview page and installation status refresh.
- [x] Hand-off to the official Roblox experience website.
- [x] Local launcher preference storage.
- [ ] Complete Roblox installation and bootstrap workflow.
- [ ] Direct launch pipeline using Roblox's supported launch mechanism.
- [ ] Installation repair and update management.
- [ ] More complete diagnostics and error handling.

### Client configuration

- [x] Basic `ClientAppSettings.json` editor.
- [ ] FastFlag search and structured editing.
- [ ] FastFlag profile management.
- [ ] Import and export of configuration profiles.
- [ ] Validation against current, documented Roblox configuration restrictions.
- [ ] Safer editing with automatic backups and restore options.

### Player tools

- [ ] Multiple account management.
- [ ] Multi-instance support, subject to Roblox client behaviour and applicable restrictions.
- [ ] Supported modification management with reversible installation and removal.
- [ ] Roblox version and channel management.
- [ ] Quickplay shortcuts and server discovery.
- [ ] Region-aware server selection where reliable data is available.
- [ ] Discord Rich Presence integration.
- [ ] Session and total playtime tracking.

### Reliability and distribution

- [x] Windows build workflow.
- [x] Continuous integration workflow.
- [x] Windows installer packaging configuration.
- [ ] Public, versioned installer releases.
- [ ] Documented release and upgrade procedure.
- [ ] Additional automated testing and recovery coverage.
- [ ] Published project license and third-party notices.

## Downloads and build artifacts

### Public releases

There is currently no published stable installer release. When a public release is available, the official download will be published here:

**[ChaosStrap releases](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)**

Do not treat an executable found on an unrelated download site as an official ChaosStrap release. The repository and its linked GitHub Releases page are the project’s official distribution locations.

### GitHub Actions artifacts

The Windows build workflow creates a Windows installer and a portable ZIP package. On ordinary workflow runs, these are uploaded as GitHub Actions artifacts for a limited retention period. They are development artifacts, not a substitute for a signed and documented public release.

To find a build artifact:

1. Open [GitHub Actions](https://github.com/TheChaosManBehindAll/ChaosStrap/actions).
2. Select a successful **ChaosStrap | Windows Build & Release** run.
3. Find the **Artifacts** section near the bottom of that run's summary.
4. Download the installer or portable package from that run.

Artifacts are only available while GitHub retains them. The current workflow configures a 30-day retention period.

## Build from source

The instructions below build the current Windows x64 application from the repository source.

### Requirements

| Requirement | Purpose |
|---|---|
| Windows 10 or Windows 11, x64 | Development and target operating system |
| [Git](https://git-scm.com/downloads) | Clone the source repository |
| [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) | Restore, build and publish the application |
| [Inno Setup 6](https://jrsoftware.org/isinfo.php) | Compile the Windows installer (optional) |

The .NET SDK is required to build the source. The publishing workflow creates a self-contained application output, so the end user's machine does not need a separately installed .NET runtime for that published build.

### 1. Clone the repository

Open PowerShell and run:

```powershell
git clone https://github.com/TheChaosManBehindAll/ChaosStrap.git
Set-Location .\ChaosStrap
```

If you have already cloned the repository, update it before building:

```powershell
git pull origin main
```

### 2. Restore NuGet dependencies

```powershell
dotnet restore .\ChaosStrap.csproj
```

### 3. Build the application

```powershell
dotnet build .\ChaosStrap.csproj --configuration Release
```

### 4. Run from source

```powershell
dotnet run --project .\ChaosStrap.csproj
```

### 5. Publish a self-contained Windows x64 build

```powershell
dotnet publish .\ChaosStrap.csproj `
  --configuration Release `
  --runtime win-x64 `
  --self-contained true `
  --output .\publish\win-x64 `
  -p:PublishSingleFile=false
```

The published application files are written to:

```text
publish\win-x64\
```

The application executable is:

```text
publish\win-x64\ChaosStrap.exe
```

### 6. Compile the Windows installer (optional)

Install Inno Setup 6, then run the following from the repository root after publishing:

```powershell
$compiler = "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"

if (!(Test-Path $compiler)) {
    throw "Inno Setup 6 compiler was not found."
}

& $compiler ".\installer\ChaosStrap.iss"

if ($LASTEXITCODE -ne 0) {
    throw "ChaosStrap installer compilation failed."
}
```

The installer script reads application files from `publish\win-x64\` and writes its output to the repository's `installer-output\` directory. The current installer script defines version `0.2.0`; update the project and installer version metadata together before preparing a new versioned release.

### Clean build

To remove previous build outputs before building again, run:

```powershell
dotnet clean .\ChaosStrap.csproj --configuration Release
Remove-Item .\bin, .\obj, .\publish -Recurse -Force -ErrorAction SilentlyContinue
```

Then repeat the restore, build and publish steps.

## Automated builds

ChaosStrap uses GitHub Actions for build validation and Windows packaging.

| Workflow | Purpose | Trigger |
|---|---|---|
| [ChaosStrap CI](.github/workflows/ci.yml) | Restores dependencies and builds the application. | Pushes and pull requests targeting `main`, plus manual runs. |
| [Windows Build & Release](.github/workflows/build-windows.yml) | Publishes the Windows x64 app, compiles the installer, creates a portable ZIP and uploads artifacts. A GitHub Release is created for version tags matching `v*`. | Pushes to `main`/`master`, pull requests, manual runs and `v*` tags. |
| [WinGet workflow](.github/workflows/winget.yml) | Reusable workflow for submitting an update to an existing WinGet package. | Called by another workflow with a package identifier and `WINGET_TOKEN` secret. |

Workflow results and logs are available from the [Actions page](https://github.com/TheChaosManBehindAll/ChaosStrap/actions).

### Release preparation

The Windows release workflow creates a GitHub Release when a tag beginning with `v` is pushed. Before creating a release, the maintainer must:

1. Confirm that the CI and Windows build workflows complete successfully.
2. Update the version metadata in `ChaosStrap.csproj` and `installer/ChaosStrap.iss`.
3. Verify that the generated installer filename matches the intended release version.
4. Review the installer and portable package on a clean Windows x64 environment.
5. Create and push the corresponding version tag.
6. Review the resulting GitHub Release and attached files.

A successful workflow run confirms that the configured build steps completed. It does not replace manual testing of the installer and application on a Windows device.

## Project structure

The repository is organised around the Avalonia application, local services, Windows assets, installer configuration and GitHub Actions workflows.

```text
ChaosStrap/
├── .github/
│   └── workflows/
│       ├── build-windows.yml
│       ├── ci.yml
│       └── winget.yml
├── Assets/
│   ├── chaosstrap-mark.png
│   └── chaosstrap-mark.ico
├── installer/
│   └── ChaosStrap.iss
├── Services/
│   ├── FastFlagStore.cs
│   ├── RobloxInstallService.cs
│   └── SettingsStore.cs
├── App.axaml
├── App.axaml.cs
├── ChaosStrap.csproj
├── MainWindow.axaml
├── MainWindow.axaml.cs
├── Program.cs
├── app.manifest
└── README.md
```

The exact contents may change as the project is refactored. The repository itself remains the source of truth for the current file layout.

## Technology

| Component | Technology |
|---|---|
| Primary language | C# |
| Runtime and SDK | .NET 10 |
| Desktop application framework | Avalonia UI 12.1.3 |
| UI theme | Avalonia Fluent theme |
| Typography | Inter via Avalonia Fonts |
| Windows installer | Inno Setup 6 |
| Continuous integration | GitHub Actions |

The project uses Avalonia to provide its desktop interface and .NET for application logic and local file operations. The current distribution target is Windows x64.

## Local data and configuration

### ChaosStrap preferences

The current settings store writes preferences for the signed-in Windows user to:

```text
%LOCALAPPDATA%\Chaos6Interactive\ChaosStrap\settings.json
```

The directory is created when settings are saved. The current settings model includes launcher preferences such as whether ChaosStrap should close after the launch hand-off, along with stored preferences for features that are still under development.

### Roblox installation detection

The installation detector checks common Windows Roblox version locations, including:

```text
%LOCALAPPDATA%\Roblox\Versions
%ProgramFiles%\Roblox\Versions
%ProgramFiles(x86)%\Roblox\Versions
```

It searches those locations for `RobloxPlayerBeta.exe`. If Roblox is installed in a non-standard location, the current detector may not find it.

### Roblox FastFlag file

The FastFlag editor targets:

```text
<ClientVersionDirectory>\ClientSettings\ClientAppSettings.json
```

`<ClientVersionDirectory>` represents the detected Roblox version directory containing `RobloxPlayerBeta.exe`.

## FastFlag configuration

FastFlags are client configuration values used by Roblox. Their availability and behaviour can change, and Roblox may ignore values that are unsupported, restricted or no longer recognised.

ChaosStrap currently provides a **basic JSON file editor**. It does not guarantee that a flag is valid for the current Roblox client or that changing a flag will improve performance.

### Recommended precautions

1. Close Roblox Player and Roblox Studio before editing the configuration file.
2. Make a backup of the existing `ClientAppSettings.json` before changing it.
3. Keep the file valid JSON. The current editor checks JSON syntax when saving.
4. Change only values whose purpose and limitations you understand.
5. Re-test after Roblox updates; client behaviour and supported settings may change.
6. Restore your backup if Roblox behaves unexpectedly after a configuration change.

### Performance expectations

A FastFlag is not automatically a performance improvement. Effects depend on the specific setting, Roblox client version, hardware, drivers and experience. Some values may be ignored or may cause instability. ChaosStrap does not promise a particular FPS increase from configuration changes.

## Troubleshooting

### ChaosStrap does not detect Roblox

- Confirm that Roblox Player is installed and can be opened normally.
- Check that `RobloxPlayerBeta.exe` exists in one of the detection directories listed above.
- Use the Overview page's status refresh after Roblox has been installed or updated.
- If Roblox is installed in a custom location, the current detection implementation may not locate it.

### The Launch button opens a website

This is expected in the current development version. The button opens Roblox's official experience hub. Select an experience and use Roblox's normal Play flow to start the client. A custom direct-launch pipeline has not yet been implemented.

### FastFlags cannot be saved

- Confirm Roblox Player is installed and detected.
- Close Roblox Player and Studio before editing.
- Make sure the text in the editor is valid JSON.
- Check that the Windows user account has permission to write to the detected Roblox version directory.
- Review the error shown by the application.

### The installer fails to compile

- Confirm that the application has been published to `publish\win-x64\`.
- Confirm that `publish\win-x64\ChaosStrap.exe` exists.
- Confirm that Inno Setup 6 is installed.
- Check that `Assets\chaosstrap-mark.ico` exists, as referenced by the installer script.
- Review the full Inno Setup compiler output for the first reported error.

### The application fails to build

- Confirm that the .NET 10 SDK is installed: `dotnet --list-sdks`.
- Run `dotnet restore .\ChaosStrap.csproj` again.
- Build with `dotnet build .\ChaosStrap.csproj --configuration Release`.
- Include the complete error output when reporting the issue. The first error is often more useful than the final summary line.

## Security and privacy

ChaosStrap is an independent desktop project. The current launch flow delegates Roblox authentication and experience launching to the official Roblox website and registered Roblox client flow; ChaosStrap does not currently provide its own Roblox sign-in or account-cookie management system.

Application preferences are stored locally under the current Windows user's local application data directory. The FastFlag editor reads and writes the local Roblox configuration file described above.

When requesting support, do not publish passwords, authentication cookies, access tokens, session identifiers or other private account information. Remove sensitive information from screenshots, logs and diagnostic output before sharing them.

If you believe you have found a security issue, avoid posting exploitable details or private data in a public issue. Contact the maintainer through the [GitHub profile](https://github.com/TheChaosManBehindAll) to discuss a responsible disclosure route.

## Compatibility and Roblox disclaimer

- **Operating system:** Windows 10 and Windows 11, 64-bit.
- **Application target:** Windows x64.
- **macOS:** Not currently supported.
- **Linux:** Not currently supported.
- **Roblox authentication:** The current launch action uses Roblox's official website and normal client hand-off.
- **Roblox relationship:** ChaosStrap is an independent third-party project. It is not affiliated with, endorsed by or sponsored by Roblox Corporation. Roblox is a trademark of Roblox Corporation.

Compatibility may change as Windows and Roblox are updated. Report reproducible compatibility problems through the issue tracker.

## Reporting an issue

Before opening a new issue, search the [existing issues](https://github.com/TheChaosManBehindAll/ChaosStrap/issues) to check whether the problem has already been reported.

A useful bug report should include:

1. **Environment:** Windows edition, version and system architecture.
2. **Build:** ChaosStrap version, release asset name or source commit.
3. **Context:** What you were doing immediately before the problem occurred.
4. **Reproduction:** The steps required to reproduce the issue.
5. **Expected result:** What you thought should happen.
6. **Actual result:** What happened instead, including the complete error message if available.

Attach relevant screenshots or build output when they help explain the issue. Remove personal information and authentication data before submitting logs.

[Open a new issue](https://github.com/TheChaosManBehindAll/ChaosStrap/issues/new)

## Maintainer and contributions

ChaosStrap is an independently maintained project led by **[xphantomcorp](https://github.com/TheChaosManBehindAll)**. Development, issue triage, build configuration, documentation and release preparation are currently handled by the project maintainer.

The project is developed in public. Bug reports, clear reproduction steps and constructive feature proposals are useful. For substantial changes, open an issue before starting implementation so the proposed change can be discussed against the project's direction and maintenance requirements.

There is no published response-time or release schedule. Project priorities and release timing depend on development progress and testing.

- [Source repository](https://github.com/TheChaosManBehindAll/ChaosStrap)
- [Issue tracker](https://github.com/TheChaosManBehindAll/ChaosStrap/issues)
- [Pull requests](https://github.com/TheChaosManBehindAll/ChaosStrap/pulls)
- [GitHub Actions](https://github.com/TheChaosManBehindAll/ChaosStrap/actions)

## License

A project-level `LICENSE` file has not yet been published in this repository. Until the maintainer adds a license, the project should **not** be assumed to be open source or available for reuse, modification or redistribution. All rights not expressly granted remain reserved by the rights holder.

Third-party libraries and tools used to build the application remain subject to their respective licenses and terms. Their licenses do not grant permission to reuse the ChaosStrap project itself.

---

<p align="center">
  <strong>ChaosStrap</strong>
  <br />
  <sub>Independently developed by xphantomcorp.</sub>
  <br />
  <sub>Windows Roblox client management.</sub>
</p>
