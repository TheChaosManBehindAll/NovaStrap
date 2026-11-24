# 🔒 Security policy

## Reporting a vulnerability

NovaStrap is an independent desktop tool for managing Roblox client configuration. If you believe you have found a security vulnerability:

1. **Do not open a public GitHub issue** with exploitable details, proof-of-concept code or private data.
2. Contact the maintainer through the GitHub profile: [xphantomcorp](https://github.com/TheChaosManBehindAll).
3. Include a clear description, the affected build (version or source commit) and steps to reproduce. Share sensitive details privately.

## Scope

### In scope

- Anything that would let NovaStrap execute unintended code, write outside its documented local data locations, or exfiltrate user data.
- Vulnerabilities in the shipped installer or portable package.
- Mishandling of local configuration files (`settings.json`, `ClientAppSettings.json`).

### Out of scope

- Roblox platform vulnerabilities — report those to Roblox Corporation through their official channels.
- Social engineering of the Roblox account system.
- FastFlag values that change how the Roblox client behaves. Flags are official client configuration; Roblox decides which values to honour.

## What NovaStrap handles (and what it never touches)

- ✅ Local launcher preferences: `%LOCALAPPDATA%\Chaos6Interactive\NovaStrap\settings.json`
- ✅ The local Roblox FastFlag file: `<ClientVersionDirectory>\ClientSettings\ClientAppSettings.json`
- ❌ Roblox passwords, `.ROBLOSECURITY` cookies, session tokens or any account credentials — NovaStrap has no sign-in system and never stores account data.

## Response

There is no published response-time commitment. Reports are triaged as development capacity allows, and fixes land in the public build history like everything else in the project.
