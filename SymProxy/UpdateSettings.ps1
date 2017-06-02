New-Item -Path "HKLM:\SOFTWARE\Microsoft\Symbol Server Proxy"
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Symbol Server Proxy" -Name NoInternetProxy -Value 1

New-Item -Force -Path "HKLM:\SOFTWARE\Microsoft\Symbol Server Proxy\Web Directories\Symbols"
Set-ItemProperty -Path "HKLM:\SOFTWARE\Microsoft\Symbol Server Proxy\Web Directories\Symbols" -Name SymbolPath -Value "http://msdl.microsoft.com/download/symbols;http://referencesource.microsoft.com/symbols;http://srv.symbolsource.org/pdb/Public;https://dotnet.myget.org/F/dotnet-core/symbols/;https://nuget.smbsrc.net"