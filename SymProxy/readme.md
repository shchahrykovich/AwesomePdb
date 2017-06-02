SymProxy docker container
===

```
// Start container
docker run -d -v C:\Symbols\LocalCache:C:\SymProxy shchegrikovich/symproxy

// Get ip address
docker inspect -f "{{ .NetworkSettings.Networks.nat.IPAddress }}" {container-id}

// Test
symchk /v %SystemRoot%\system32\ntdll.dll /s http://{container-ip}/Symbols/ | more

// Update _NT_SYMBOL_PATH
setx /M _NT_SYMBOL_PATH "cache*C:\Symbols\LocalCache;SRV**http://{container-ip}/Symbols/"
```
