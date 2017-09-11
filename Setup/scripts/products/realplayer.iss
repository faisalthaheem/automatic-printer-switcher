[CustomMessages]
realplayer_title=Real Player

en.realplayer_size=0.5 MB
de.realplayer_size=0,5 MB


[Code]

const
	realplayer_url = 'http://www.computedsynergy.com/dependencies/RealPlayer11GOLD.exe';

procedure realplayer();
begin
	if not RegKeyExists(HKLM, 'SOFTWARE\RealNetworks\RealPlayer') then
		AddProduct('RealPlayer11GOLD.exe',
			'',
			CustomMessage('realplayer_title'),
			CustomMessage('realplayer_size'),
			realplayer_url);
end;