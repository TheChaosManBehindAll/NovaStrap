# ChaosStrap

**ChaosStrap** is an independently implemented Roblox launcher project created and maintained by **xphantomcorp**.

This repository is a clean-room implementation. The Froststrap 2.0.8 archive was reviewed as a feature reference only. No Froststrap source files, code, UI markup, assets, or project files were copied into this project. The ChaosStrap application structure, UI, services, and branding in this repository were authored independently.

## Current foundation

- Dark graphite and crimson visual identity based on the ChaosStrap emblem.
- Roblox Player installation detection on Windows.
- Open the official Roblox experience hub so Roblox can complete its normal authenticated launch handoff.
- Open the detected Roblox installation directory.
- Local launcher preferences stored under `%LOCALAPPDATA%\Chaos6Interactive\ChaosStrap`.
- Basic JSON FastFlag editor for the detected Roblox version's `ClientSettings\ClientAppSettings.json`.
- Navigation foundations for Overview, FastFlags, Mod Manager, Appearance, and Settings.

## Not implemented yet

The Mod Manager, update delivery, account management, channel switching, server browser, region selection, Discord integrations, tray controls, and advanced bootstrap/install pipeline are not implemented in this foundation. They should be developed as separate, tested features rather than represented as finished when they are not.

## Build

Requirements: .NET 10 SDK and Windows 10/11.

```powershell
dotnet restore
dotnet build -c Release
dotnet run
```

The current build environment used to generate this source archive did not have the .NET SDK installed, so compilation has not yet been verified. Run the commands above on a Windows development machine and share any build output for fixes. Direct Roblox client startup requires a signed launch ticket, so this first build opens the official Roblox home page rather than attempting an unsupported direct executable launch.

## Safety notes

ChaosStrap does not bypass Roblox security, modify anti-cheat components, or inject code into the Roblox process. The FastFlag editor writes only the local Roblox client settings JSON file. Roblox may ignore unsupported flags.

## Branding

Product: ChaosStrap  
Developer: xphantomcorp  
Palette: graphite, near-black, crimson red  
Logo: `Assets/chaosstrap-mark.png`

## Windows installer and code signing

The GitHub Actions workflow builds both a Windows x64 installer (`ChaosStrap-Setup-0.2.0-win-x64.exe`) and a portable ZIP. The installer is created with Inno Setup and includes Start Menu shortcuts, an optional desktop shortcut, and an uninstall entry.

The installer metadata identifies the publisher as `xphantomcorp`. **This metadata alone does not make Windows show a verified publisher.** Windows only displays a trusted publisher when the executable and installer are digitally signed with a valid code-signing certificate issued to the publisher. Without a certificate, Windows may show an unknown/unverified publisher warning.

To enable signing after obtaining a trusted code-signing certificate in PFX format:

1. In the GitHub repository, open **Settings → Secrets and variables → Actions**.
2. Add a secret named `WINDOWS_PFX_BASE64` containing the certificate file encoded as Base64.
3. Add a secret named `WINDOWS_PFX_PASSWORD` containing the PFX password.
4. Re-run the workflow. It will sign the published application executables and installer.

Keep the PFX file and password private. Never commit either to the repository. Certificate providers have different identity-verification and issuance requirements; the certificate's legal subject name is what Windows uses as the verified publisher identity. Do not use a self-signed certificate if your goal is to avoid the unknown-publisher warning.

## Automatic GitHub builds

This repository includes a GitHub Actions workflow at `.github/workflows/build-windows.yml`.

- Every push to `main` or `master` and every pull request targeting those branches runs a Windows x64 publish build.
- Use **Actions → Build ChaosStrap for Windows → Run workflow** to start a build manually.
- Download `ChaosStrap-win-x64.zip` from the completed workflow run's **Artifacts** section.
- To create a versioned GitHub Release automatically, push a tag beginning with `v`, for example:

```powershell
git tag v0.1.0
git push origin v0.1.0
```

The release includes a Windows installer EXE and a portable ZIP of the self-contained Windows x64 application. Run the installer to install ChaosStrap, or extract the portable ZIP to use it without installing.
