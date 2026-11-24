# 🪐 NovaStrap official kit — apply guide

This folder is the complete official package for the renamed project: rebranded README, MIT license, governance docs, brand identity, issue/PR templates, release template and the official emblem assets. Everything is drop-in for `TheChaosManBehindAll/NovaStrap`.

## Order of operations

1. **Run `RENAME_CHECKLIST.md` first** — rename the GitHub repo and the code identity (csproj, namespaces, assets, installer, workflows).
2. **Copy this kit into the repository** (table below).
3. **GitHub polish** — About, topics, social preview, pin.

## File placement

| File in this kit | Destination in the repository |
|---|---|
| `README.md` | `README.md` (replace the current one) |
| `LICENSE` | `LICENSE` (new — activates the MIT badge and the GitHub license detection) |
| `SECURITY.md` | `SECURITY.md` (replace — already NovaStrap-branded) |
| `CONTRIBUTING.md` | `CONTRIBUTING.md` (new) |
| `CODE_OF_CONDUCT.md` | `CODE_OF_CONDUCT.md` (new — linked from CONTRIBUTING; GitHub picks it up automatically) |
| `BRAND.md` | `docs/BRAND.md` or repository root (identity guide for the project) |
| `RENAME_CHECKLIST.md` | working document — keep locally or drop in `docs/`; once the sweep is done it has served its purpose |
| `docs/RELEASE_TEMPLATE.md` | `docs/RELEASE_TEMPLATE.md` (replace) |
| `.github/ISSUE_TEMPLATE/config.yml` | `.github/ISSUE_TEMPLATE/config.yml` (replace) |
| `.github/ISSUE_TEMPLATE/bug_report.yml` | `.github/ISSUE_TEMPLATE/bug_report.yml` (replace) |
| `.github/ISSUE_TEMPLATE/feature_request.yml` | `.github/ISSUE_TEMPLATE/feature_request.yml` (replace) |
| `.github/PULL_REQUEST_TEMPLATE.md` | `.github/PULL_REQUEST_TEMPLATE.md` (replace) |
| `.github/workflows/ci.yml` | `.github/workflows/ci.yml` (replace — adds concurrency + NuGet caching) |
| `.github/workflows/build-windows.yml` | `.github/workflows/build-windows.yml` (replace — adds optional code-signing, conditional Inno Setup install, release hardening) |
| `.github/workflows/winget.yml` | `.github/workflows/winget.yml` (replace — input validation first, real asset-name URL) |
| `brand/novastrap-emblem.png` | Canonical 1254 × 1254 transparent source artwork |
| `brand/novastrap-mark.ico` | Canonical multi-resolution Windows icon |
| `Assets/novastrap-mark.png` | Ready-to-use repository/app copy of the official emblem (identical to the brand source) |
| `Assets/novastrap-mark.ico` | Ready-to-use application and installer icon |

The archive includes both the canonical files under `brand/` and ready-to-use copies under `Assets/`. The `Assets/` copies match the paths referenced by the README, application and installer. When merging the kit into your application repository, copy the two files from the kit's `Assets/` folder into the corresponding `Assets/` folder in your local clone.

### Copy with PowerShell (from the extracted kit folder, into your local clone)

```powershell
Copy-Item README.md, LICENSE, SECURITY.md, CONTRIBUTING.md, CODE_OF_CONDUCT.md .\
New-Item -ItemType Directory -Force docs | Out-Null
Copy-Item docs\RELEASE_TEMPLATE.md docs\
Copy-Item BRAND.md docs\
New-Item -ItemType Directory -Force .github\ISSUE_TEMPLATE | Out-Null
Copy-Item .github\ISSUE_TEMPLATE\* .github\ISSUE_TEMPLATE\
Copy-Item .github\PULL_REQUEST_TEMPLATE.md .github\
New-Item -ItemType Directory -Force .github\workflows | Out-Null
Copy-Item .github\workflows\* .github\workflows\
New-Item -ItemType Directory -Force Assets | Out-Null
Copy-Item brand\novastrap-emblem.png Assets\novastrap-mark.png
Copy-Item brand\novastrap-mark.ico Assets\novastrap-mark.ico
```

Then commit and push. GitHub picks up the license, CoC, issue/PR templates and README automatically — no settings changes needed.

## Workflow fixes (vs the originals you pasted)

The three files under `.github/workflows/` were rewritten from the originals with real fixes, not just renames:

- **Code-signing now actually exists.** The old `build-windows.yml` had no signing step, while the README promises signing when `WINDOWS_PFX_BASE64` / `WINDOWS_PFX_PASSWORD` secrets are configured. The new workflow signs every published `.exe` plus the installer with `signtool` (SHA-256 digest + RFC-3161 timestamp) and skips itself cleanly when the secrets are absent — unsigned dev builds keep working.
- **Inno Setup installs only when missing.** GitHub's Windows runners already ship Inno Setup 6; the old workflow unconditionally ran `choco install`, burning build time and risking version drift on every run.
- **NuGet caching** added to both build workflows, keyed on the csproj hash — faster restores on every run.
- **Tag releases can no longer cancel each other.** `cancel-in-progress` now applies only to branch and PR runs; previously two `v*` tags pushed in quick succession could kill the first tag's release build.
- **Release step hardened:** `fail_on_unmatched_files: true`, so a missing artifact fails loudly instead of silently publishing an empty release.
- **WinGet workflow** validates its inputs before downloading anything, and its installer URL now matches the real asset name (`NovaStrap-Setup-<version>-win-x64.exe`) — `docs/RELEASE_TEMPLATE.md` had documented asset names that did not match what the build produces; fixed.

## GitHub "About" description

Paste into the repo About field, or run the `gh` command. Leads with the hooks a browser-scroller sees first:

> 🪐 NovaStrap — the Windows Roblox launcher that wraps your client in crimson chaos. FastFlag editor, Mod Manager, multi-account & multi-instance on the roadmap. .NET 10 + Avalonia. Built in public, CI-verified on every push. Chaos, in orbit.

```bash
gh repo edit TheChaosManBehindAll/NovaStrap --description "🪐 NovaStrap — the Windows Roblox launcher that wraps your client in crimson chaos. FastFlag editor, Mod Manager, multi-account & multi-instance on the roadmap. .NET 10 + Avalonia. Built in public, CI-verified on every push. Chaos, in orbit."
```

## Repository topics (20, max 20 allowed)

`novastrap` · `roblox` · `bootstrapper` · `launcher` · `roblox-launcher` · `windows` · `windows-10` · `windows-11` · `csharp` · `dotnet` · `avalonia` · `avaloniaui` · `fastflags` · `fastflag-editor` · `mod-manager` · `multi-instance` · `rich-presence` · `game-launcher` · `roblox-client` · `roblox-tools`

```bash
gh repo edit TheChaosManBehindAll/NovaStrap \
  --add-topic novastrap --add-topic roblox --add-topic bootstrapper --add-topic launcher --add-topic roblox-launcher \
  --add-topic windows --add-topic windows-10 --add-topic windows-11 \
  --add-topic csharp --add-topic dotnet --add-topic avalonia --add-topic avaloniaui \
  --add-topic fastflags --add-topic fastflag-editor --add-topic mod-manager \
  --add-topic multi-instance --add-topic rich-presence \
  --add-topic game-launcher --add-topic roblox-client --add-topic roblox-tools
```

The `novastrap` topic is yours — first mover owns the topic page. Topics also keep the repo discoverable on `github.com/topics/roblox` and `topics/fastflags`.

## After applying — quick wins

1. **Social preview:** upload `Assets/novastrap-mark.png` (Settings → General → Social preview) so every share shows the emblem.
2. **Pin the repo** on your profile — pinned cards render the README description and topics.
3. **License done:** the kit ships `LICENSE` (MIT), and the README badge is now the dynamic `shields.io/github/license` shield — it turns green the moment `LICENSE` is pushed.
4. **First release:** when `0.3.0` is ready, follow `docs/RELEASE_TEMPLATE.md` and push tag `v0.3.0` — the Windows Build & Release workflow auto-creates the GitHub Release with `NovaStrap-Setup-0.3.0-win-x64.exe` and the portable ZIP attached.
5. **Screenshots:** once the UI stabilises, drop PNGs into `Assets/Screenshots/` and uncomment the screenshot block in the README (the marked placeholder is still there).

## Badge notes (verified against shields.io on 2026-11-24)

The named logos `avaloniaui`, `roblox`, `dotnet`, `github`, `git` and `githubactions` render; `windows`, `csharp` and `innosetup` do **not** resolve anymore, so those badges carry no logo. Brand color across all badges is **Nova Red `F30E1A`**, sampled from the emblem.
