docker run -d -v C:\Symbols\LocalCache:C:\SymProxy shchegrikovich/symproxy
docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" {container-id}
symchk /v %SystemRoot%\system32\ntdll.dll /s http://{container-ip}/Symbols/ | more

setx /M _NT_SYMBOL_PATH "cache*C:\Symbols\LocalCache;SRV**http://{container-ip}/Symbols/"