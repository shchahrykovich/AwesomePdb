srctool -r App.pdb


pdbstr -w -p:App.pdb -i:srcsrv.txt -s:srcsrv


srctool -x App.pdb


symstore add /f App.pdb /s ../SymbolStore /t demo1