[CustomMessages]
quicktime_title=Quick Time Player

en.quicktime_size=27.0 MB
de.quicktime_size=27,0 MB


[Code]

const
	quicktime_url = 'http://www.computedsynergy.com/dependencies/QuickTimeInstaller.exe';

procedure quicktime();
begin
	if not RegKeyExists(HKLM, 'SOFTWARE\Apple Computer, Inc.\QuickTime\ActiveX') then
		AddProduct('QuickTimeInstaller.exe',
			'',
			CustomMessage('quicktime_title'),
			CustomMessage('quicktime_size'),
			quicktime_url);
end;