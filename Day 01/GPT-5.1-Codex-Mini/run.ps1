param(
    [string]$DayFolder = "$(Split-Path -Parent $MyInvocation.MyCommand.Path)"
)

Write-Host "Running .NET solver in folder: $DayFolder"

Push-Location $DayFolder
try {
    dotnet build -c Release
    dotnet run -c Release
} finally {
    Pop-Location
}
