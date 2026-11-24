 <div align="center">

<h1>ChaosStrap</h1>

<p><strong>Take control of your Roblox experience.</strong></p>

<img src="Assets/chaosstrap-mark.png" width="190" alt="ChaosStrap Logo"/>

<p>A modern Windows Roblox bootstrapper built for performance, customisation and control.</p>

<p>
  <a href="#installation"><strong>Download</strong></a> ·
  <a href="#features"><strong>Features</strong></a> ·
  <a href="#building-from-source"><strong>Build from source</strong></a> ·
  <a href="https://github.com/TheChaosManBehindAll/ChaosStrap/issues"><strong>Report an issue</strong></a>
</p>

</div>

<div align="center">

[![Build](https://img.shields.io/github/actions/workflow/status/TheChaosManBehindAll/ChaosStrap/build-windows.yml?branch=main&style=for-the-badge&color=9b2335&label=BUILD)](https://github.com/TheChaosManBehindAll/ChaosStrap/actions)
[![Latest Release](https://img.shields.io/github/v/release/TheChaosManBehindAll/ChaosStrap?style=for-the-badge&color=9b2335&label=VERSION)](https://github.com/TheChaosManBehindAll/ChaosStrap/releases/latest)
[![Downloads](https://img.shields.io/github/downloads/TheChaosManBehindAll/ChaosStrap/total?style=for-the-badge&color=9b2335&label=DOWNLOADS)](https://github.com/TheChaosManBehindAll/ChaosStrap/releases)
[![Stars](https://img.shields.io/github/stars/TheChaosManBehindAll/ChaosStrap?style=for-the-badge&color=9b2335&label=STARS)](https://github.com/TheChaosManBehindAll/ChaosStrap/stargazers)

</div>

---

## What is ChaosStrap?

ChaosStrap is an independent Roblox bootstrapper developed by **xphantomcorp**.

It is designed to give Roblox players greater control over their game client, with tools for launching, configuration, customisation and performance management.

Instead of juggling multiple applications and manually managing settings, ChaosStrap aims to bring the tools players need into one convenient application.

Built with **C#**, **.NET 10** and **Avalonia UI**, ChaosStrap is being developed with a focus on usability, reliability and a polished Windows experience.

## Installation

ChaosStrap downloads will be distributed through the official GitHub Releases page.

<div align="center">

### Get ChaosStrap

<a href="https://github.com/TheChaosManBehindAll/ChaosStrap/releases/latest">
<strong>View Latest Release</strong>
</a>

</div>

> [!IMPORTANT]
> Only download ChaosStrap from the official repository. Downloads from unofficial sources are not verified or affiliated with the project.

### Windows

| System | Support |
| :- | :- |
| Windows 10 | Target platform |
| Windows 11 | Target platform |
| Architecture | x64 |

ChaosStrap is currently being developed for Windows. Other platforms are not currently supported.

## Features

ChaosStrap is being developed around the tools that make managing and playing Roblox easier.

### Roblox Management

- Roblox installation and update management.
- Installation repair and recovery.
- Multiple Roblox account management.
- Multiple client instances.
- Roblox version management.

### Performance and Configuration

- FastFlag management.
- Custom configuration profiles.
- Performance-related settings.
- Per-game configuration options.
- Configuration backup and restoration.

### Customisation

- Roblox modification management.
- Custom application themes.
- Customisable launcher appearance.
- Import and export of configurations.

### Integrations and Convenience

- Quickplay shortcuts.
- Server discovery and selection.
- Discord Rich Presence integration.
- Playtime tracking.
- Launch configuration management.

> [!NOTE]
> ChaosStrap is actively being developed. Not every feature listed above is currently available. Features will be marked as implemented as development progresses.

## Why ChaosStrap?

A Roblox bootstrapper should be more than a way to launch a game.

ChaosStrap is built around three main principles:

**Control**

Manage your Roblox configuration, accounts and customisation from one place.

**Performance**

Keep the application lightweight and focus on settings that have a meaningful impact on the experience.

**Reliability**

Make installation, updates and troubleshooting easier, with recovery options when something goes wrong.

## Building from source

Want to compile ChaosStrap yourself?

### Requirements

- Windows 10 or Windows 11.
- Git.
- .NET 10 SDK.
- Inno Setup 6 (for building the Windows installer).

### Clone the repository

```bash
git clone https://github.com/TheChaosManBehindAll/ChaosStrap.git
cd ChaosStrap
```

### Restore dependencies

```bash
dotnet restore ChaosStrap.csproj
```

### Build

```bash
dotnet build ChaosStrap.csproj -c Release
```

### Publish

```bash
dot
