<div align="center">
  <h1>ChaosStrap</h1>
  <p><strong>A Windows Roblox bootstrapper in development.</strong></p>
  <p>Manage local Roblox settings and client tools from one desktop application.</p>
  <p>
    <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers">
      <img src="https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=flat-square&color=8D2638&label=GitHub%20stars" alt="GitHub stars" />
    </a>
    <img src="https://img.shields.io/badge/platform-Windows%2010%20%7C%2011-8D2638?style=flat-square" alt="Windows 10 and Windows 11" />
    <img src="https://img.shields.io/badge/.NET-10-8D2638?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 10" />
    <img src="https://img.shields.io/badge/UI-Avalonia-8D2638?style=flat-square" alt="Avalonia UI" />
  </p>
</div>

---

## Overview

ChaosStrap is an independent, Windows-first application for managing Roblox client settings and related tasks. It is built with **C#**, **.NET 10** and **Avalonia UI**.

The project is in early development. The current application provides a foundation for local Roblox detection, basic configuration editing and application preferences. It is not yet a complete replacement for Roblox's standard installer or launcher.

## Current functionality

The following functionality is present in the current codebase:

- **Roblox detection** — locates an existing Roblox Player installation.
- **Roblox access** — opens the official Roblox experience hub.
- **Installation shortcut** — opens the detected Roblox installation directory.
- **Local preferences** — stores application settings for the current Windows user.
- **FastFlag file editing** — edits the local `ClientSettings\ClientAppSettings.json` file as JSON.

The FastFlag editor is a basic file editor. It does not currently provide an authoritative FastFlag catalogue or allowlist validation. Roblox may ignore unsupported or restricted values, and changing a value does not guarantee a performance improvement.

## Development roadmap

The following areas are planned or under consideration. They should not be understood as features available in the current build.

- Roblox installation, updating and repair.
- A complete and reliable Roblox launch workflow.
- FastFlag search, validation, profiles and import/export.
- Supported modification management.
- Account and session management.
- Roblox version and release-channel controls.
- Quickplay and server discovery.
- Discord Rich Presence and playtime tracking.
- Diagnostics, configuration backups and recovery.

Priorities may change as development progresses and Roblox updates its client or distribution systems.

## Downloads

There is no public installer release yet. When a release is ready, official packaged downloads will be published on the repository's Releases page.

[**View ChaosStrap releases**](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)

Until then, the repository should be treated as a development project rather than a ready-to-install replacement for the Roblox launcher.

## Build from source

### Requirements

- Windows 10 or Windows 11 (x64).
- [Git](https://git-scm.com/downloads).
- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
- [Inno Setup 6](https://jrsoftware.org/isinfo.php), if you want to compile the Windows installer.

### Get the source

Download the `ChaosStrap-0.2.0-Installer-Signing.zip` source archive from the [repository](https://github.com/TheChaosManBehindAll/ChaosStrap), extract it, and open a terminal in the directory containing `ChaosStrap.csproj`.

### Restore and build

```powershell
dotnet restore .\ChaosStrap.csproj
dotnet build .\ChaosStrap.csproj --configuration Release
```

### Run

```powershell
dotnet run --project .\ChaosStrap.csproj
```

### Publish for Windows x64

```powershell
dotnet publish .\ChaosStrap.csproj `
  --configuration Release `
  --runtime win-x64 `
  --self-contained true `
  --output .\publish\win-x64
```

The published application files are written to `publish\win-x64\`.

### Compile the installer

After publishing, install Inno Setup 6 and run its compiler from the project directory:

```powershell
$compiler = "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe"
& $compiler ".\installer\ChaosStrap.iss"

if ($LASTEXITCODE -ne 0) {
    throw "Installer compilation failed."
}
```

The installer script expects the published files in `publish\win-x64\`. If compilation fails, check that the publish step completed and that the paths in `installer\ChaosStrap.iss` match the extracted project structure.

## Configuration

The FastFlag editor works with the `ClientSettings\ClientAppSettings.json` file in the detected Roblox version directory.

Before editing this file, close Roblox Player and Roblox Studio and keep a backup of the original. Roblox may ignore settings that are unsupported, restricted or obsolete. FastFlags are not guaranteed performance optimisations.

## Compatibility

- **Operating system:** Windows 10 and Windows 11 (x64).
- **Framework:** .NET 10.
- **Interface:** Avalonia UI.
- **Other platforms:** macOS and Linux are not currently supported.

ChaosStrap is an independent third-party project. It is not affiliated with, endorsed by or sponsored by Roblox Corporation. Roblox is a trademark of Roblox Corporation.

## Support and issue reports

Report bugs and request features through the [GitHub issue tracker](https://github.com/TheChaosManBehindAll/ChaosStrap/issues). Before opening an issue, check whether it has already been reported. Include the steps to reproduce the problem and any relevant error output.

Do not include passwords, authentication cookies, access tokens or other private account information in an issue or log attachment.

## Maintainer

ChaosStrap is maintained by **[xphantomcorp](https://github.com/TheChaosManBehindAll)**.

## License

A project licence has not yet been published. Until a licence is added to the repository, no permission to reuse, modify or redistribute this project's code is granted. Third-party dependencies remain subject to their respective licences.

---

<div align="center">
  <sub>ChaosStrap · Independently developed by xphantomcorp.</sub>
</div>
