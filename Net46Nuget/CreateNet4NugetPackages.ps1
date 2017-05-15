rm "$PSScriptRoot\artifacts\DotNextPdbDemo*.nupkg" -ErrorAction SilentlyContinue

$version="0.9.16"

nuget pack -Version $version -Symbols $PSScriptRoot\BubbleSortNuGet\DotNextPdbDemo.nuspec -outputdirectory "$PSScriptRoot\artifacts"

nuget push -Source "https://www.nuget.org/api/v2/package" "$PSScriptRoot\artifacts\DotNextPdbDemo-symbols.$version.nupkg"
nuget push -Source "https://nuget.smbsrc.net/" "$PSScriptRoot\artifacts\DotNextPdbDemo-symbols.$version.symbols.nupkg"