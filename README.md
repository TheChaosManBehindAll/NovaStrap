<div align="center">
  <img src="./Assets/chaosstrap-mark.png" alt="ChaosStrap" width="144" />
  <h1>ChaosStrap</h1>
  <p><strong>Roblox client management for Windows.</strong></p>
  <p>A focused desktop application for managing Roblox-related settings and launch tasks.</p>
  <p><sub>Official project repository · Developed by xphantomcorp</sub></p>
  <br />
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/actions/workflows/build-windows.yml">
    <img src="https://img.shields.io/github/actions/workflow/status/TheChaosManBehindAll/ChaosStrap/build-windows.yml?branch=main&style=for-the-badge&label=WINDOWS%20BUILD&logo=githubactions&logoColor=white" alt="Windows build status" />
  </a>
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers">
    <img src="https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=for-the-badge&color=8D2638&label=STARS" alt="GitHub stars" />
  </a>
  <img src="https://img.shields.io/badge/PLATFORM-WINDOWS%2010%20%7C%2011-8D2638?style=for-the-badge" alt="Windows 10 and Windows 11" />
  <img src="https://img.shields.io/badge/BUILT%20WITH-.NET%2010-8D2638?style=for-the-badge&logo=dotnet&logoColor=white" alt="Built with .NET 10" />
</div>

---

## Overview

ChaosStrap is an independently developed Windows application for managing selected Roblox client settings and launch-related tasks. It is built with **C#**, **.NET 10** and **Avalonia UI**.

The project is being developed as a practical, configurable alternative to the standard Roblox launching experience. Its current foundation focuses on local Roblox installation detection, local preferences and FastFlag file editing. The broader bootstrapper, installation and account-management workflows are still in development.

This repository is the official source for the ChaosStrap project. The application is **not affiliated with, endorsed by or sponsored by Roblox Corporation**.

## Project status

| Property | Details |
|---|---|
| Development stage | Pre-release |
| Supported platform | Windows 10 and Windows 11 (x64) |
| Framework | .NET 10 |
| Language | C# |
| UI framework | Avalonia UI |
| Maintainer | xphantomcorp |
| Public GitHub release | Not published yet |

ChaosStrap is still under active development. The capabilities below describe the current foundation; planned work is listed separately and should not be interpreted as already available.

## Current capabilities

The current application foundation includes:

| Capability | Current behaviour |
|---|---|
| Roblox installation detection | Detects a local Roblox Player installation on Windows. |
| Roblox launch hand-off | Opens the official Roblox experience hub. Roblox handles authentication and the normal client-launch hand-off. |
| Installation access | Opens the detected Roblox installation directory. |
| Local preferences | Stores application preferences for the current Windows user. |
| FastFlag file editing | Provides a basic JSON editor for the detected version's `ClientSettings\ClientAppSettings.json` file. |

### Launch behaviour

The current launch action opens the official Roblox experience hub. It does not yet replace Roblox's complete installation or bootstrap process, and it does not directly launch the client using an unsupported launch method.

### FastFlag editor

The FastFlag editor provides access to the local `ClientAppSettings.json` file. It is a general JSON editor, not a verified FastFlag catalogue or allowlist validator. Roblox may ignore unsupported, restricted or obsolete values. Saving a setting does not guarantee that Roblox will apply it or that it will improve performance.

## Development roadmap

The following areas represent the project's development direction. They are not part of the current feature set unless explicitly listed in [Current capabilities](#current-capabilities).

- **Bootstrap and installation:** a complete installation, update and repair workflow.
- **Launch management:** improved launch options and reliable client launch orchestration.
- **Configuration:** FastFlag validation, profiles, and import/export.
- **Customisation:** supported modification management and compatibility checks.
- **Accounts and sessions:** local account management and multi-instance support.
- **Integrations:** Discord Rich Presence, playtime tracking and server discovery.
- **Diagnostics:** clearer error reporting, configuration backups and recovery tools.

The roadmap may change as development progresses and Roblox's client behaviour evolves.

## Downloads

There is currently **no published public release**. Official installer and portable downloads will be listed on the repository's Releases page when a release is ready.

- [GitHub Releases](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)
- [Windows build workflow](https://github.com/TheChaosManBehindAll/ChaosStrap/actions/workflows/build-windows.yml)

For development testing, successful workflow runs provide temporary build artifacts. Open a completed run and download the files from its **Artifacts** section. These artifacts are intended for testing, are not stable releases, and are retained for a limited period by GitHub Actions.

Only use downloads published through this repository's Releases page or its GitHub Actions workflow. Third-party downloads are not official ChaosStrap distributions.

## Build from source

### Requirements

- Windows 10 or Windows 11 (x64)
- [Git](https://git-scm.com/downloads)
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Inno Setup 6](https://jrsoftware.org/isinfo.php), only when compiling the Windows installer

### Clone the repository

```powershell
git clone https://github.com/TheChaosManBehindAll/ChaosStrap.git
Set-Location .\ChaosStrap
```

### Restore dependencies

```powershell
dotnet restore .\ChaosStrap.csproj
```

### Build

```powershell
dotnet build .\ChaosStrap.csproj --configuration Release
```

### Run the application

```powershell
dotnet run --project .\ChaosStrap.csproj
```

### Publish a self-contained Windows build

```powershell
dotnet publish .\ChaosStrap.csproj `
  --configuration Release `
  --runtime win-x64 `
  --self-contained true `
  --output .\publish\win-x64 `
  -p:PublishSingleFile=false
```

The published application is written to `publish\win-x64\`.

### Compile the Windows installer

Publish the application first, then install Inno Setup 6 and run its compiler from the repository root:

```powershell
$compiler = "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"
& $compiler ".\installer\ChaosStrap.iss"

if ($LASTEXITCODE -ne 0) {
    throw "Installer compilation failed."
}
```

The installer script reads the published files from `publish\win-x64\` and writes the installer to the configured output directory.

## Automated builds

The repository includes a Windows build and release workflow at `.github/workflows/build-windows.yml`.

| Event | Workflow behaviour |
|---|---|
| Push to `main` or `master` | Publishes the Windows x64 application and creates build artifacts. |
| Pull request | Runs the Windows build workflow. |
| Manual dispatch | Allows a build to be started from the GitHub Actions page. |
| Version tag beginning with `v` | Builds the Windows packages and creates a GitHub Release. |

A successful workflow run uploads the Windows installer and portable package as workflow artifacts. The workflow artifact is separate from a published GitHub Release.

See [Actions](https://github.com/TheChaosManBehindAll/ChaosStrap/actions) for the latest workflow status and build history.

## Local data and FastFlags

Application preferences are stored for the current Windows user under:

```text
%LOCALAPPDATA%\Chaos6Interactive\ChaosStrap
```

The FastFlag editor targets the `ClientSettings\ClientAppSettings.json` file in the detected Roblox version directory.

Before changing client settings:

1. Close Roblox Player and Roblox Studio.
2. Keep a backup of the existing settings file.
3. Change only values you understand.
4. Remember that Roblox may ignore settings that are unsupported or no longer permitted.

FastFlags are configuration values, not guaranteed performance optimisations. Their behaviour can vary between Roblox client versions and devices.

## Security and compatibility

- **Windows only:** Windows 10 and Windows 11 x64 are the current supported development targets.
- **Roblox authentication:** the current launch hand-off uses the official Roblox experience hub; ChaosStrap does not handle Roblox account passwords.
- **Local configuration:** the current FastFlag editor modifies the local Roblox client settings JSON file.
- **No exploit functionality:** ChaosStrap is not designed to inject code into the Roblox process, bypass Roblox security or modify anti-cheat components.
- **No performance guarantees:** configuration changes may have no effect, may be ignored by Roblox, or may behave differently after client updates.

ChaosStrap is an independent third-party project and is not affiliated with Roblox Corporation. Roblox is a trademark of Roblox Corporation.

## Reporting issues

Use the [GitHub issue tracker](https://github.com/TheChaosManBehindAll/ChaosStrap/issues) to report reproducible bugs or request changes.

When submitting a bug report, include:

- Windows edition and version.
- The ChaosStrap version or commit being used.
- Steps to reproduce the issue.
- Expected and actual behaviour.
- Relevant error messages or build output.

Remove passwords, authentication cookies, access tokens and other private information before sharing logs or screenshots.

## Contributing

Focused bug fixes, documentation improvements and feature contributions are welcome. For substantial changes, open an issue first to discuss the proposed behaviour and implementation approach.

All contributions should be relevant to the project, documented where appropriate and tested before a pull request is submitted.

## Project information

| Resource | Link |
|---|---|
| Official repository | [TheChaosManBehindAll/ChaosStrap](https://github.com/TheChaosManBehindAll/ChaosStrap) |
| Releases | [GitHub Releases](https://github.com/TheChaosManBehindAll/ChaosStrap/releases) |
| Build status and artifacts | [GitHub Actions](https://github.com/TheChaosManBehindAll/ChaosStrap/actions) |
| Bug reports and requests | [GitHub Issues](https://github.com/TheChaosManBehindAll/ChaosStrap/issues) |

**Maintainer:** [xphantomcorp](https://github.com/TheChaosManBehindAll)

## License

A repository-level license has not yet been published. Until a license is added, the availability of the source code does not grant permission to reuse, modify or redistribute it. Third-party dependencies remain subject to their respective licenses.

---

<div align="center">
  <strong>ChaosStrap</strong><br />
  <sub>Developed independently by xphantomcorp.</sub>
</div>
