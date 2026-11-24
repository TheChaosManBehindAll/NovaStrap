using System.Diagnostics;

namespace ChaosStrap.Services;

public sealed class RobloxInstallService
{
    private static readonly string[] CandidateRoots =
    [
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Roblox", "Versions"),
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Roblox", "Versions"),
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Roblox", "Versions")
    ];

    public string? FindPlayer()
    {
        foreach (var root in CandidateRoots.Distinct(StringComparer.OrdinalIgnoreCase))
        {
            if (!Directory.Exists(root)) continue;
            try
            {
                var found = Directory.EnumerateFiles(root, "RobloxPlayerBeta.exe", SearchOption.AllDirectories)
                    .OrderByDescending(File.GetLastWriteTimeUtc).FirstOrDefault();
                if (found is not null) return found;
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
        }
        return null;
    }

    public bool IsInstalled => FindPlayer() is not null;

    public void Launch()
    {
        // Roblox requires a signed launch ticket for direct client startup.
        // Open the official experience hub; pressing Play there hands off to the
        // registered Roblox protocol with the user's authenticated session.
        Process.Start(new ProcessStartInfo("https://www.roblox.com/home") { UseShellExecute = true });
    }

    public string? GetInstallDirectory() => FindPlayer() is { } player ? Path.GetDirectoryName(player) : null;
}
