@echo off

:: Çözümü temizle
if "%1"=="Clean" (
    dotnet clean
    echo Solution cleaned.
)

:: Çözümü derle
if "%1"=="Build" (
    dotnet build
    echo Solution built.
)

:: Testleri çalýþtýr
if "%1"=="Test" (
    dotnet test
    echo Tests run successfully.
)

:: AOUBook projesini çalýþtýr
if "%1"=="RunAOUBook" (
    dotnet run --project ./AOUBook/AOUBook.csproj
    echo AOUBook project running.
)

:: AOUBook.Api projesini çalýþtýr
if "%1"=="RunAOUBookApi" (
    dotnet run --project ./AOUBook.Api/AOUBook.Api.csproj
    echo AOUBook.Api project running.
)

:: Her iki projeyi de çalýþtýr
if "%1"=="RunAll" (
    dotnet run --project ./AOUBook/AOUBook.csproj
    dotnet run --project ./AOUBook.Api/AOUBook.Api.csproj
    echo Both projects running.
)

:: Yardým
if "%1"=="" (
    echo Usage: build.bat [Clean|Build|Test|RunAOUBook|RunAOUBookApi|RunAll]
)
