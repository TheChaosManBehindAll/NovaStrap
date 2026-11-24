using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using ChaosStrap.Services;

namespace ChaosStrap;

public partial class MainWindow : Window
{
    private readonly RobloxInstallService _roblox = new();
    private readonly SettingsStore _settingsStore = new();
    private LauncherSettings _settings;
    private FastFlagStore _flags;

    public MainWindow()
    {
        InitializeComponent();
        _settings = _settingsStore.Load();
        _flags = new FastFlagStore(_roblox);
        CloseAfterLaunch.IsChecked = _settings.CloseAfterLaunch;
        CheckUpdates.IsChecked = _settings.CheckForUpdatesOnStart;
        RichPresence.IsChecked = _settings.EnableRichPresence;
        RefreshInstallStatus();
    }

    private void InitializeComponent() => Avalonia.Markup.Xaml.AvaloniaXamlLoader.Load(this);

    private void Navigate_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is not Button { Tag: string page }) return;
        HomePage.IsVisible = page == "Home";
        FastFlagsPage.IsVisible = page == "FastFlags";
        ModsPage.IsVisible = page == "Mods";
        AppearancePage.IsVisible = page == "Appearance";
        SettingsPage.IsVisible = page == "Settings";
        var titles = new Dictionary<string, (string Eyebrow, string Title)>
        {
            ["Home"] = ("CHAOSSTRAP / HOME", "Your Roblox, your rules."),
            ["FastFlags"] = ("CHAOSSTRAP / CONFIGURATION", "Fine-tune your client."),
            ["Mods"] = ("CHAOSSTRAP / CUSTOMIZATION", "Make it yours."),
            ["Appearance"] = ("CHAOSSTRAP / PERSONALIZATION", "A look that feels like Chaos."),
            ["Settings"] = ("CHAOSSTRAP / PREFERENCES", "Your launcher, your settings.")
        };
        PageEyebrow.Text = titles[page].Eyebrow;
        PageTitle.Text = titles[page].Title;
        if (page == "FastFlags") LoadFlagsIntoEditor();
    }

    private void Refresh_Click(object? sender, RoutedEventArgs e) => RefreshInstallStatus();

    private void RefreshInstallStatus()
    {
        var player = _roblox.FindPlayer();
        var installed = player is not null;
        InstallStatus.Text = installed ? "Roblox detected" : "Roblox not detected";
        InstallValue.Text = installed ? "Installed" : "Not installed";
        InstallPath.Text = installed ? Path.GetDirectoryName(player!)! : "Install Roblox to enable local configuration.";
        _flags = new FastFlagStore(_roblox);
    }

    private void Launch_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            _roblox.Launch();
            if (_settings.CloseAfterLaunch && _roblox.IsInstalled) Close();
        }
        catch (Exception ex)
        {
            InstallStatus.Text = "Launch failed";
            InstallPath.Text = ex.Message;
        }
    }

    private void OpenInstall_Click(object? sender, RoutedEventArgs e)
    {
        var folder = _roblox.GetInstallDirectory();
        if (folder is null) { InstallPath.Text = "Roblox Player is not installed."; return; }
        OpenPath(folder);
    }

    private void OpenWebsite_Click(object? sender, RoutedEventArgs e) => OpenPath("https://www.roblox.com");

    private static void OpenPath(string path) => Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });

    private void LoadFlagsIntoEditor()
    {
        FastFlagPath.Text = string.IsNullOrEmpty(_flags.PathName) ? "Roblox installation not found." : _flags.PathName;
        try { FastFlagEditor.Text = _flags.Read(); }
        catch (Exception ex) { FastFlagEditor.Text = "{\n  \"error\": \"" + ex.Message.Replace("\"", "'") + "\"\n}"; }
    }

    private void ReloadFlags_Click(object? sender, RoutedEventArgs e) => LoadFlagsIntoEditor();

    private async void SaveFlags_Click(object? sender, RoutedEventArgs e)
    {
        try
        {
            _flags.Save(FastFlagEditor.Text ?? "{}");
            await ShowMessage("FastFlags saved", "Your local ClientAppSettings.json file was updated.");
        }
        catch (Exception ex) { await ShowMessage("Couldn't save FastFlags", ex.Message); }
    }

    private void SaveSettings_Click(object? sender, RoutedEventArgs e)
    {
        _settings.CloseAfterLaunch = CloseAfterLaunch.IsChecked == true;
        _settings.CheckForUpdatesOnStart = CheckUpdates.IsChecked == true;
        _settings.EnableRichPresence = RichPresence.IsChecked == true;
        try
        {
            _settingsStore.Save(_settings);
            PageEyebrow.Text = "CHAOSSTRAP / SAVED";
        }
        catch (Exception ex) { PageEyebrow.Text = "SAVE FAILED: " + ex.Message; }
    }

    private async Task ShowMessage(string title, string message)
    {
        var dialog = new Window
        {
            Title = title, Width = 420, Height = 190, CanResize = false,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel { Margin = new Avalonia.Thickness(20), Spacing = 14, Children =
            {
                new TextBlock { Text = title, FontSize = 17, FontWeight = Avalonia.Media.FontWeight.SemiBold },
                new TextBlock { Text = message, TextWrapping = Avalonia.Media.TextWrapping.Wrap },
                new Button { Content = "OK", HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right, Classes = { "action" } }
            }}
        };
        if (dialog.Content is StackPanel panel && panel.Children.LastOrDefault() is Button button)
            button.Click += (_, _) => dialog.Close();
        await dialog.ShowDialog(this);
    }
}
