# 🚀 Rename checklist — ChaosStrap → NovaStrap

Work top to bottom. GitHub items first (they redirect automatically), then code, then packaging. Tick every box before pushing the rebrand commit.

## 1. GitHub repository

- [ ] **Rename the repo:** Settings → General → *Repository name* → `NovaStrap`. GitHub 301-redirects every old URL (issues, PRs, stars, clones) automatically, so nothing breaks for existing visitors.
- [ ] **Update your local clone:** `git remote set-url origin https://github.com/TheChaosManBehindAll/NovaStrap.git`
- [ ] **About description:** paste the new text from `REPO_KIT_GUIDE.md` (or run the `gh repo edit` command there).
- [ ] **Topics:** apply the 20-topic set from `REPO_KIT_GUIDE.md` (adds `novastrap`, drops `inno-setup`).
- [ ] **Social preview:** Settings → General → Social preview → upload `brand/novastrap-emblem.png`.
- [ ] **Website field:** point it at the Releases page until a real site exists.

## 2. Code identity

- [ ] Rename `ChaosStrap.csproj` → `NovaStrap.csproj`.
- [ ] In the csproj: update `AssemblyName`, `RootNamespace`, and any `ApplicationTitle` / `Product` / `AssemblyTitle` / `FileVersionInfo` metadata strings.
- [ ] Rename root namespace folders/references so `namespace ChaosStrap.*` becomes `namespace NovaStrap.*` (IDE rename or a project-wide find/replace on `namespace ChaosStrap`, `using ChaosStrap`).
- [ ] Window title in `MainWindow.axaml(.cs)`: "NovaStrap".
- [ ] Accent resource in `App.axaml`: rename the theme entry **"Chaos Crimson" → "Nova Red"** and set its hex to **`#F30E1A`** (was `#E51D35`). Keep `#0C0C10` Graphite as the base.
- [ ] Single-instance / app mutex / named-pipe identifiers (if any): grep for hardcoded identity strings.

## 3. Local data

- [ ] Settings store base directory: `%LOCALAPPDATA%\Chaos6Interactive\ChaosStrap\` → `%LOCALAPPDATA%\Chaos6Interactive\NovaStrap\`. The `Chaos6Interactive` studio folder can stay as-is.
- [ ] Add a one-time migration on startup: if the old `ChaosStrap\settings.json` exists and the new one doesn't, copy it across so existing users keep their preferences.

## 4. Assets

- [ ] Copy `brand/novastrap-emblem.png` → `Assets/novastrap-mark.png` (this replaces `chaosstrap-mark.png`).
- [ ] Copy `brand/novastrap-mark.ico` → `Assets/novastrap-mark.ico` (replaces `chaosstrap-mark.ico`).
- [ ] Update every reference: csproj resource entries, Avalonia window icon, `App.manifest` icon path, installer script.
- [ ] Delete the old `chaosstrap-mark.*` files in the same commit.

## 5. Installer

- [ ] Rename `installer/ChaosStrap.iss` → `installer/NovaStrap.iss`.
- [ ] In the script: `MyAppName` → `NovaStrap`, output installer name → `NovaStrap-Setup-{version}-win-x64.exe`, icon reference → `Assets\novastrap-mark.ico`, and the version stays aligned with the csproj (`0.2.0` today).
- [ ] **AppId decision (recommended): generate a NEW GUID** for a clean break — old ChaosStrap installs stay as a separate entry in "Apps & features" and should be uninstalled manually once. Only reuse the old GUID if you want the installer to upgrade those installs in place.

## 6. CI / workflows

- [ ] Replace the repo's three workflows with the kit's `.github/workflows/` versions — same triggers, plus: optional code-signing when `WINDOWS_PFX_BASE64` / `WINDOWS_PFX_PASSWORD` secrets are set (matches what the README promises), NuGet caching, Inno Setup installed only when missing, a hardened release step, and artifact names `NovaStrap-Windows-<SHA>` / `NovaStrap-win-x64-portable.zip`.
- [ ] When submitting to WinGet later, call the reusable `winget.yml` workflow with the package identifier and the `WINGET_TOKEN` secret.

## 7. Sweep

- [ ] `git grep -i chaosstrap` → **zero hits** left in the repo (the README, SECURITY.md, templates and docs in this kit already read "NovaStrap").
- [ ] `git grep -iE "9B2335|E51D35"` → only historical changelog entries, if any; all badges and code accents are `F30E1A`.

## 8. Ship it

- [ ] Rebrand commit on `main` (CI green).
- [ ] When ready, follow `docs/RELEASE_TEMPLATE.md` and push tag `v0.2.0` — the workflow builds and attaches `NovaStrap-Setup-0.2.0-win-x64.exe` + `NovaStrap-win-x64-portable.zip`.
