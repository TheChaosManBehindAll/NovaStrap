using System.Text.Json;

namespace ChaosStrap.Services;

public sealed class LauncherSettings
{
    public bool CloseAfterLaunch { get; set; }
    public bool CheckForUpdatesOnStart { get; set; } = true;
    public bool EnableRichPresence { get; set; }
    public string Theme { get; set; } = "Crimson";
}

public sealed class SettingsStore
{
    private readonly string _file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Chaos6Interactive", "ChaosStrap", "settings.json");
    public LauncherSettings Load()
    {
        try
        {
            if (File.Exists(_file)) return JsonSerializer.Deserialize<LauncherSettings>(File.ReadAllText(_file)) ?? new();
        }
        catch (JsonException) { }
        catch (IOException) { }
        return new();
    }
    public void Save(LauncherSettings settings)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(_file)!);
        File.WriteAllText(_file, JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true }));
    }
}
