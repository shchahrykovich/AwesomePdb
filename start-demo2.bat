@echo off
setlocal

SET dir=%~dp0
SET _NT_SYMBOL_PATH=cache*%dir%\LocalCache;srv*https://nuget.smbsrc.net/

start "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe" %~dp0\demo2\Demo2-NetCore.sln