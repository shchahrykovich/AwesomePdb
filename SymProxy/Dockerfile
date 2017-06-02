FROM microsoft/nanoserver

ADD https://az880830.vo.msecnd.net/nanoserver-ga-2016/Microsoft-NanoServer-IIS-Package_base_10-0-14393-0.cab /install/Microsoft-NanoServer-IIS-Package_base_10-0-14393-0.cab
ADD https://az880830.vo.msecnd.net/nanoserver-ga-2016/Microsoft-NanoServer-IIS-Package_English_10-0-14393-0.cab /install/Microsoft-NanoServer-IIS-Package_English_10-0-14393-0.cab
ADD https://raw.githubusercontent.com/Microsoft/iis-docker/8ffb45926630255cff635b6c693e0efd43a96aa7/nanoserver/ServiceMonitor.exe /ServiceMonitor.exe

RUN dism.exe /online /add-package /packagepath:c:\install\Microsoft-NanoServer-IIS-Package_base_10-0-14393-0.cab & \
    dism.exe /online /add-package /packagepath:c:\install\Microsoft-NanoServer-IIS-Package_English_10-0-14393-0.cab & \
    dism.exe /online /add-package /packagepath:c:\install\Microsoft-NanoServer-IIS-Package_base_10-0-14393-0.cab & \
    rd /s /q c:\install

RUN dism.exe /Enable-Feature /Online /FeatureName:IIS-ISAPIFilter /all

ADD Tools\\symproxy.dll C:\\Windows\\System32\\inetsrv\\symproxy.dll
ADD Tools\\symproxy.man C:\\Windows\\System32\\inetsrv\\symproxy.man
ADD Tools\\symsrv.dll C:\\Windows\\System32\\inetsrv\\symsrv.dll
RUN echo. 2>C:\\Windows\\System32\\inetsrv\\symsrv.yes

RUN mkdir C:\SymProxyScripts
ADD staticContentClear.xml C:\\SymProxyScripts\\staticContentClear.xml
ADD Install.bat C:\\SymProxyScripts\\Install.bat
ADD UpdateSettings.ps1 C:\\SymProxyScripts\\UpdateSettings.ps1

RUN mkdir C:\SymProxy
RUN C:\\SymProxyScripts\\Install.bat C:\\SymProxy

RUN powershell.exe C:\\SymProxyScripts\\UpdateSettings.ps1

EXPOSE 80
ENTRYPOINT ["C:\\ServiceMonitor.exe", "w3svc"]