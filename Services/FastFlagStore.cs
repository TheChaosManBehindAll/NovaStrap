using System.Text.Json;

namespace ChaosStrap.Services;

public sealed class FastFlagStore
{
    private readonly string _path;
    public FastFlagStore(RobloxInstallService install)
    {
        var root = install.GetInstallDirectory();
        _path = root is null ? string.Empty : Path.Combine(root, "ClientSettings", "ClientAppSettings.json");
    }
    public string PathName => _path;
    public string Read() => !string.IsNullOrWhiteSpace(_path) && File.Exists(_path) ? File.ReadAllText(_path) : "{}";
    public void Save(string json)
    {
        if (string.IsNullOrWhiteSpace(_path)) throw new InvalidOperationException("Roblox Player was not detected. Install Roblox before editing FastFlags.");
        using var document = JsonDocument.Parse(json);
        Directory.CreateDirectory(System.IO.Path.GetDirectoryName(_path)!);
        File.WriteAllText(_path, JsonSerializer.Serialize(document.RootElement, new JsonSerializerOptions { WriteIndented = true }));
    }
}
