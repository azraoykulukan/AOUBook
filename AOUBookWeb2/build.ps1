function Clean {
    dotnet clean
    Write-Host "Solution cleaned."
}

function Build {
    dotnet build
    Write-Host "Solution built."
}

function Test {
    dotnet test
    Write-Host "Tests run successfully."
}

function RunAOUBook {
    dotnet run --project ./AOUBook/AOUBook.csproj
    Write-Host "AOUBook project running."
}

function RunAOUBookApi {
    dotnet run --project ./AOUBook.Api/AOUBook.Api.csproj
    Write-Host "AOUBook.Api project running."
}

function RunAll {
    RunAOUBook
    RunAOUBookApi
}

function Help {
    Write-Host "Usage: .\build.ps1 [Clean|Build|Test|RunAOUBook|RunAOUBookApi|RunAll|Help]"
}

param (
    [string]$Task = "Help"
)

switch ($Task) {
    "Clean" { Clean }
    "Build" { Build }
    "Test" { Test }
    "RunAOUBook" { RunAOUBook }
    "RunAOUBookApi" { RunAOUBookApi }
    "RunAll" { RunAll }
    "Help" { Help }
    default { Help }
}
