# Contributing to NovaStrap

First off — thanks for even reading this. NovaStrap is built in public, and every bug report, receipt and pull request pushes the orbit a little further out.

> [!IMPORTANT]
> By participating in this project you agree to abide by the [Code of Conduct](CODE_OF_CONDUCT.md). Keep it clean, keep it chaotic (the fun kind).

## Ways to contribute

| You want to… | Do this |
|---|---|
| Report a bug | Open a [bug report](https://github.com/TheChaosManBehindAll/NovaStrap/issues/new?template=bug_report.yml) with reproduction steps. Clear steps get fixed fastest. |
| Suggest a feature | Check the [roadmap](https://github.com/TheChaosManBehindAll/NovaStrap#-the-roadmap) first. Already listed? Subscribe to that discussion instead of opening a duplicate. Not listed? Open a [feature request](https://github.com/TheChaosManBehindAll/NovaStrap/issues/new?template=feature_request.yml). |
| Contribute code | For substantial changes, open the issue **before** writing the implementation, so it can be discussed against the project's direction. Small, obvious fixes can go straight to a PR. |
| Improve docs | Typos, unclear wording, missing steps — PRs welcome. If user-facing behaviour changed, the README feature tables must change with it. |

## Development setup

| Requirement | Purpose |
|---|---|
| Windows 10 or Windows 11, x64 | Development and target OS |
| [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) | Restore, build, run, publish |
| [Inno Setup 6](https://jrsoftware.org/isinfo.php) | Compile the installer (optional) |

```powershell
git clone https://github.com/TheChaosManBehindAll/NovaStrap.git
Set-Location .\NovaStrap
dotnet restore .\NovaStrap.csproj
dotnet build .\NovaStrap.csproj --configuration Release
dotnet run --project .\NovaStrap.csproj
```

CI runs the same restore + build on every push and pull request, so a green local build is usually a green CI run.

## Ground rules

1. **Keep the honesty contract.** Every user-facing feature in the README is labelled **live**, **partial** or **planned**. If your change alters what actually ships, update the feature tables and roadmap checkboxes in the same PR. We hype what we ship — nothing else.
2. **Version metadata moves together.** If a release is involved, update the version in `NovaStrap.csproj` **and** `installer/NovaStrap.iss` in the same commit.
3. **No secrets in diffs.** No passwords, cookies, tokens, signing keys or personal data in code, logs or screenshots.
4. **Match the codebase.** Follow the C# conventions already in the repository. Consistent code reads like one author wrote it.

## The hard line

NovaStrap is configuration and launch management — nothing else. Pull requests that add DLL injection, memory editing, exploit tooling, authentication bypass, `.ROBLOSECURITY` handling or anything that modifies Roblox program behaviour will be rejected on sight. This is not negotiable and it protects the project, its users and its maintainer.

## Submitting a pull request

1. Fork or branch off `main` with a descriptive name (`fix/fastflag-save-path`, `feature/mod-deploy`).
2. Build and test on Windows x64. Exercise the feature you touched, not just the build.
3. Fill in the PR template completely — what, why, how tested.
4. One logical change per PR. A diff that does three things gets reviewed three times slower.

## Licensing

NovaStrap is [MIT licensed](LICENSE). By contributing, you agree that your contributions are licensed under the same terms — the project stays free and open for everyone, permanently.
