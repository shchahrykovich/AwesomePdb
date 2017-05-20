Awesome PDB
====
[Demo 1](start-demo1.bat)

* Add SRCSRV stream to a PDB - [Demo1/SrcSrv](Demo1/SrcSrv/)
* Create local symbol store
* Use PerfView to investigate App.exe - [Demo1/PerfView](Demo1/PerfView/)

[Demo 2](start-demo2.bat)

* Make sure SourceLink project produces Portable PDB - [Demo2/SourceLink/SourceLink.csproj](Demo2/SourceLink/SourceLink.csproj#L4)
* Review GenerateSourceLink task [Demo2/SourceLink/Directory.Build.targets](Demo2/SourceLink/Directory.Build.targets#L11)
* Run SymbolReader [Demo2/SymbolReader](Demo2/SymbolReader)

[Symbol package for Nuget](Net46Nuget)

* Compile [BubbleSortNuGet](Net46Nuget/BubbleSortNuGet)
* Run [Net46Nuget/CreateNet4NugetPackages.ps1](Net46Nuget/CreateNet4NugetPackages.ps1)
* Attach debugger to [BubbleSortDemo](Net46Nuget/BubbleSortDemo)

Portable PDB
===
Portable PDB is a new cross-platform format for storing debug symbols. Source link is a feature that allows downloading source code at debug-time.

[Description](https://github.com/dotnet/core/blob/master/Documentation/diagnostics/portable_pdb.md)

[Specification](https://github.com/dotnet/corefx/blob/master/src/System.Reflection.Metadata/specs/PortablePdb-Metadata.md)

[Source link](https://github.com/dotnet/core/blob/master/Documentation/diagnostics/source_link.md)

PDB tools
===
[**AgeStore**](https://msdn.microsoft.com/en-us/library/windows/hardware/ff538002(v=vs.85).aspx) - The AgeStore tool (agestore.exe) deletes files in a directory or directory tree, based on their last access dates. This program is particularly useful for removing old files from the downstream store used by a symbol server, in order to conserve disk space.

[**SymChk**](https://msdn.microsoft.com/en-us/library/windows/hardware/ff558844(v=vs.85).aspx) - SymChk is a program that compares executable files to symbol files to verify that the correct symbols are available.

[**PDBStr**](https://msdn.microsoft.com/en-us/library/windows/hardware/ff558874(v=vs.85).aspx) - The PDBStr tool is used by the indexing scripts to insert the version control information into the "srcsrv" alternative stream of the target .pdb file. It can also read any stream from a .pdb file. You can use this information to verify that the indexing scripts are working properly.

[**Symstore**](https://msdn.microsoft.com/en-us/library/windows/desktop/ms681417(v=vs.85).aspx) - SymStore (symstore.exe) is a tool for creating symbol stores.

[**SrcTool**](https://msdn.microsoft.com/en-us/library/windows/hardware/ff558877(v=vs.85).aspx) - The SrcTool (Srctool.exe) utility lists all files indexed within the .pdb file. For each file, it lists the full path, source control server, and version number of the file. You can use this information for reference.

[**PDBCopy**](https://msdn.microsoft.com/en-us/library/windows/hardware/ff553365(v=vs.85).aspx) - The PDBCopy tool (pdbcopy.exe) is a command-line tool that removes private symbol information from a symbol file. It can also remove selected information from the public symbol table.
