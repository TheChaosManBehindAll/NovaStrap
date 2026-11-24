; ChaosStrap Windows installer
; Built with Inno Setup. Publisher metadata is shown only as signed/trusted
; when the installer is signed with a certificate issued to the publisher.

#define AppName "ChaosStrap"
#define AppVersion "0.2.0"
#define AppPublisher "xphantomcorp"
#define AppExeName "ChaosStrap.exe"

[Setup]
AppId={{9A8D4D82-2D65-4E2F-AF1A-3B1D7D9C0A21}
AppName={#AppName}
AppVersion={#AppVersion}
AppPublisher={#AppPublisher}
AppPublisherURL=https://github.com/xphantomcorp/ChaosStrap
AppSupportURL=https://github.com/xphantomcorp/ChaosStrap/issues
AppUpdatesURL=https://github.com/xphantomcorp/ChaosStrap/releases
DefaultDirName={autopf}\ChaosStrap
DefaultGroupName=ChaosStrap
DisableProgramGroupPage=yes
OutputDir=..\installer-output
OutputBaseFilename=ChaosStrap-Setup-{#AppVersion}-win-x64
SetupIconFile=..\Assets\chaosstrap-mark.ico
UninstallDisplayName={#AppName}
UninstallDisplayIcon={app}\{#AppExeName}
ArchitecturesInstallIn64BitMode=x64
ArchitecturesAllowed=x64
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
VersionInfoVersion=0.2.0.0
VersionInfoCompany={#AppPublisher}
VersionInfoDescription=ChaosStrap Windows Installer
VersionInfoProductName={#AppName}
VersionInfoProductVersion={#AppVersion}
CloseApplications=yes
RestartApplications=no

[Tasks]
Name: "desktopicon"; Description: "Create a desktop shortcut"; GroupDescription: "Additional shortcuts:"; Flags: unchecked

[Files]
Source: "..\publish\win-x64\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{autoprograms}\ChaosStrap"; Filename: "{app}\{#AppExeName}"
Name: "{autodesktop}\ChaosStrap"; Filename: "{app}\{#AppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Launch ChaosStrap"; Flags: postinstall nowait skipifsilent

[Code]
function InitializeSetup(): Boolean;
begin
  Result := IsWin64;
  if not Result then
    MsgBox('ChaosStrap currently supports 64-bit Windows only.', mbError, MB_OK);
end;
