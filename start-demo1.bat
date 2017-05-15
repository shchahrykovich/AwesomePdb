@echo off
setlocal


SET dir=%~dp0Demo1\
SET symbols=%dir%\SymbolStore\
set cache=%~dp0\LocalCache
SET _NT_SYMBOL_PATH=cache*%cache%;srv*https://nuget.smbsrc.net/;srv*%symbols%

start cmd /k "cd %dir%SrcSrv & set prompt=$G & title SrcSrv stream"

start PerfView %~dp0\Demo1\PerfView\AppTrace.etl.zip
start PerfViewBeta %~dp0\Demo1\PerfView\AppTrace.etl.zip