rm "$PSScriptRoot\artifacts\PdbDemo*.nupkg" -ErrorAction SilentlyContinue

$version="0.9.16"

nuget pack -Version $version -Symbols $PSScriptRoot\BubbleSortNuGet\PdbDemo.nuspec -outputdirectory "$PSScriptRoot\artifacts"

nuget push -Source "https://www.nuget.org/api/v2/package" "$PSScriptRoot\artifacts\PdbDemo-symbols.$version.nupkg"
nuget push -Source "https://nuget.smbsrc.net/" "$PSScriptRoot\artifacts\PdbDemo-symbols.$version.symbols.nupkg"