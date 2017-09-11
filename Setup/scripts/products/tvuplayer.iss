[CustomMessages]
tvuplayer_title=TVU Player

en.tvuplayer_size=5.6 MB
de.tvuplayer_size=5,6 MB


[Code]

const
	tvuplayer_url = 'http://www.computedsynergy.com/dependencies/TVUPlayer2.5.3.1.exe';

procedure tvuplayer();
begin
	if not RegKeyExists(HKLM, 'SOFTWARE\RealNetworks\RealPlayer') then
		AddProduct('tvuplayer.exe',
			'/s',
			CustomMessage('tvuplayer_title'),
			CustomMessage('tvuplayer_size'),
			tvuplayer_url);
end;