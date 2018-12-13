$testProjects = "$PSScriptRoot\Company.App.Application.Tests", "$PSScriptRoot\Company.App.Presentation.Tests"
$nugetOpenCoverPackage = Join-Path -Path $env:USERPROFILE -ChildPath "\.nuget\packages\OpenCover"
$latestOpenCover = Join-Path -Path ((Get-ChildItem -Path $nugetOpenCoverPackage | Sort-Object Fullname -Descending)[0].FullName) -ChildPath "tools\OpenCover.Console.exe"

$nugetReportGeneratorPackage = Join-Path -Path $env:USERPROFILE -ChildPath "\.nuget\packages\ReportGenerator"
#$latestReportGenerator = Join-Path -Path ((Get-ChildItem -Path $nugetReportGeneratorPackage | Sort-Object Fullname -Descending)[0].FullName) -ChildPath "tools\ReportGenerator.exe"
$latestReportGenerator = Join-Path -Path ((Get-ChildItem -Path $nugetReportGeneratorPackage | Sort-Object Fullname -Descending)[0].FullName) -ChildPath "tools\netcoreapp2.0\ReportGenerator.dll"

$nugetCoberturaConverterPackage = Join-Path -Path $env:USERPROFILE -ChildPath "\.nuget\packages\OpenCoverToCoberturaConverter"
$latestCoberturaConverter = Join-Path -Path (Get-ChildItem -Path $nugetCoberturaConverterPackage | Sort-Object Fullname -Descending)[0].FullName -ChildPath "tools\OpenCoverToCoberturaConverter.exe"

$coverageReportFolderName = "$PSScriptRoot\CodeCoverage"
$coverageFileName = "$coverageReportFolderName\OpenCover.xml"
$coberturaFileName = "$coverageReportFolderName\Cobertura.xml"

If (Test-Path $coverageReportFolderName) {
    Remove-Item $coverageReportFolderName -Force -Recurse
}
New-Item -ItemType directory -Path $coverageReportFolderName

$testRuns = 1;
foreach ($testProject in $testProjects) {
    $dotnetArguments = "xunit", "-xml `"`"$coverageReportFolderName\testRuns_$testRuns.testresults`"`""

    "================ Running tests with OpenCover ================"
    & $latestOpenCover `
        -register:user `
        -target:dotnet.exe `
        -targetdir:$testProject `
        "-targetargs:$dotnetArguments" `
        -returntargetcode `
        -output:$coverageFileName `
        -mergeoutput `
        -oldStyle `
        -excludebyattribute:"*.ExcludeFromCodeCoverageAttribute;System.CodeDom.Compiler.GeneratedCodeAttribute" `
        -filter:"+[*]* -[*].Tests.* -[*]Xamarin.* -[*]Microsoft.Cci* -[*]Mono.* -[*Moq*]* -[*]Misc.Core.Entities.*"

    $testRuns++
}

& dotnet.exe $latestReportGenerator "-reports:$coverageFileName" "-targetdir:$coverageReportFolderName"

"================ Converting coverage reports to Cobertura format ================"
& $latestCoberturaConverter `
    -input:$coverageFileName `
    -output:$coberturaFileName `
     "-sources:$PSScriptRoot\..\"
