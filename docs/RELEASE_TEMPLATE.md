# Release notes template

Copy this into the GitHub Release created by the **Windows Build & Release** workflow when a `v*` tag is pushed (see README → Release preparation).

---

# NovaStrap v{VERSION}

<!-- Example: v0.3.0 -->

## ⚡ What's new

<!-- 3–6 bullets, concrete and user-facing. Link the PRs. -->
- Feature: … (#123)
- Improvement: … (#124)
- Fix: … (#125)

## ✅ Shipped in this release

<!-- Mirror the README feature tables. Only list what is genuinely live in this build. -->

## 🚧 Still on the roadmap

<!-- Keep expectations honest. -->
See the [roadmap](https://github.com/TheChaosManBehindAll/NovaStrap#-the-roadmap) for everything still being built.

## 📦 Downloads

| Asset | Audience |
|---|---|
| `NovaStrap-Setup-{VERSION}-win-x64.exe` | Most users — recommended installer |
| `NovaStrap-win-x64-portable.zip` | Portable / no-install preference |

## ⚠️ Known issues

<!-- Be honest. Example: The Launch action opens the Roblox website; the direct-launch pipeline is still under development. -->

## 🔎 Verification

- Built by GitHub Actions from commit `{SHA}` — workflow run: {RUN_URL}.
- Review the release assets against the workflow run before installing.

---

**Checklist before publishing:**

1. Version metadata updated in `NovaStrap.csproj` **and** `installer/NovaStrap.iss` to the same value.
2. CI and Windows Build & Release workflows green on the tagged commit.
3. Installer and portable ZIP tested on a clean Windows x64 machine.
4. Installer filename matches the released version.
5. Notes above are filled in — no `{PLACEHOLDER}` left behind.
