#include "scripts\products.iss"

#include "scripts\products\winversion.iss"
#include "scripts\products\fileversion.iss"

//#include "scripts\products\iis.iss"

#include "scripts\products\kb835732.iss"
//#include "scripts\products\kb886903.iss"
//#include "scripts\products\kb928366.iss"

//#include "scripts\products\msi20.iss"
#include "scripts\products\msi31.iss"
//#include "scripts\products\ie6.iss"

//#include "scripts\products\dotnetfx11.iss"
//#include "scripts\products\dotnetfx11lp.iss"
//#include "scripts\products\dotnetfx11sp1.iss"

//#include "scripts\products\dotnetfx20.iss"
//#include "scripts\products\dotnetfx20lp.iss"
//#include "scripts\products\dotnetfx20sp1.iss"
//#include "scripts\products\dotnetfx20sp1lp.iss"
//#include "scripts\products\dotnetfx20sp2.iss"
//#include "scripts\products\dotnetfx20sp2lp.iss"

//#include "scripts\products\dotnetfx35.iss"
//#include "scripts\products\dotnetfx35lp.iss"
#include "scripts\products\dotnetfx35sp1.iss"
//#include "scripts\products\dotnetfx35sp1lp.iss"

//#include "scripts\products\mdac28.iss"
//#include "scripts\products\jet4sp8.iss"
//#include "scripts\products\sql2005express.iss"

//#include "scripts\products\realplayer.iss"
//#include "scripts\products\quicktime.iss"
//#include "scripts\products\tvuplayer.iss"

[CustomMessages]
win2000sp3_title=Windows 2000 Service Pack 3
winxpsp2_title=Windows XP Service Pack 2


[Setup]
AppName=Automatic Printer Switcher
AppVersion=2.1.1
AppVerName=APS 2.1.1
AppCopyright=Copyright © Computed Synergy 2011
VersionInfoVersion=2.1.1
VersionInfoCompany=Computed Synergy
AppPublisher=Computed Synergy
;AppPublisherURL=http://...
;AppSupportURL=http://...
;AppUpdatesURL=http://...
OutputBaseFilename=APS2.1.1.0-Setup
DefaultGroupName=Computed Synergy\APS
DefaultDirName={pf}\Automatic Printer Switcher
UninstallDisplayIcon={app}\PrinterSwitcher.exe
UninstallDisplayName=Automatic Printer Switcher
Uninstallable=true
DirExistsWarning=no
CreateAppDir=true
OutputDir=bin
SourceDir=.
AllowNoIcons=true
UsePreviousGroup=true
UsePreviousAppDir=true
ShowUndisplayableLanguages=false
LanguageDetectionMethod=uilanguage
InternalCompressLevel=fast
SolidCompression=true
Compression=lzma/fast

MinVersion=5.0
PrivilegesRequired=admin
ArchitecturesAllowed=
ArchitecturesInstallIn64BitMode=
AppPublisherURL=http://www.computedsynergy.com
AppUpdatesURL=http://www.computedsynergy.com/aps/
VersionInfoCopyright=Copyright (C) 2010-2011 Computed Synergy
VersionInfoProductName=Automatic Printer Switcher
VersionInfoProductVersion=2.1.1
ShowLanguageDialog=no
AppContact=info@computedsynergy.com
LicenseFile=license.txt
WizardImageFile=WizModernImage.bmp
WizardSmallImageFile=WizModernSmallImage.bmp

[Languages]
Name: en; MessagesFile: compiler:Default.isl
Name: de; MessagesFile: compiler:Languages\German.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: src\PrinterSwitcher.exe; DestDir: {app}; Flags: overwritereadonly

[Dirs]
Name: {userappdata}\APS

[Registry]
Root: HKCU; Subkey: Software\Computed Synergy\APS; Flags: uninsdeletekey

[Icons]
Name: {group}\Automatic Printer Switcher; Filename: {app}\PrinterSwitcher
Name: {group}\{cm:UninstallProgram,Automatic Printer Switcher}; Filename: {uninstallexe}
Name: {commondesktop}\Automatic Printer Switcher; Filename: {app}\PrinterSwitcher.exe; Tasks: desktopicon

[Run]
Filename: {app}\PrinterSwitcher.exe; Description: {cm:LaunchProgram,Automatic Printer Switcher}; Flags: nowait postinstall skipifsilent

[Code]
function InitializeSetup(): Boolean;
begin
	//init windows version
	initwinversion();

	//check if dotnetfx20 can be installed on this OS
	if not minwinspversion(5, 0, 3) then begin
		MsgBox(FmtMessage(CustomMessage('depinstall_missing'), [CustomMessage('win2000sp3_title')]), mbError, MB_OK);
		exit;
	end;
	if not minwinspversion(5, 1, 2) then begin
		MsgBox(FmtMessage(CustomMessage('depinstall_missing'), [CustomMessage('winxpsp2_title')]), mbError, MB_OK);
		exit;
	end;

	//if (not iis()) then exit;

	//msi20('2.0');
	msi31('3.1');
	//ie6('5.0.2919');

	//dotnetfx11();
	//dotnetfx11lp();
	//dotnetfx11sp1();
	//kb886903(); //better use windows update
	//kb928366(); //better use windows update

	//install .netfx 2.0 sp2 if possible; if not sp1 if possible; if not .netfx 2.0
	//if minwinversion(5, 1) then begin
	//	dotnetfx20sp2();
	//	dotnetfx20sp2lp();
	//end else begin
	//	if minwinversion(5, 0) and minwinspversion(5, 0, 4) then begin
	//		kb835732();
	//		dotnetfx20sp1();
	//		dotnetfx20sp1lp();
	//	end else begin
	//		dotnetfx20();
	//		dotnetfx20lp();
	//	end;
	//end;

//  realplayer();
//  quicktime();
  //tvuplayer();

	//dotnetfx35();
	//dotnetfx35lp();
	dotnetfx35sp1();
	//dotnetfx35sp1lp();

	//mdac28('2.7');
	//jet4sp8('4.0.8015');
	//sql2005express();


	Result := true;
end;
