@echo off

:: ��z�m� temizle
if "%1"=="Clean" (
    dotnet clean
    echo Solution cleaned.
)

:: ��z�m� derle
if "%1"=="Build" (
    dotnet build
    echo Solution built.
)

:: Testleri �al��t�r
if "%1"=="Test" (
    dotnet test
    echo Tests run successfully.
)

:: AOUBook projesini �al��t�r
if "%1"=="RunAOUBook" (
    dotnet run --project ./AOUBook/AOUBook.csproj
    echo AOUBook project running.
)

:: AOUBook.Api projesini �al��t�r
if "%1"=="RunAOUBookApi" (
    dotnet run --project ./AOUBook.Api/AOUBook.Api.csproj
    echo AOUBook.Api project running.
)

:: Her iki projeyi de �al��t�r
if "%1"=="RunAll" (
    dotnet run --project ./AOUBook/AOUBook.csproj
    dotnet run --project ./AOUBook.Api/AOUBook.Api.csproj
    echo Both projects running.
)

:: Yard�m
if "%1"=="" (
    echo Usage: build.bat [Clean|Build|Test|RunAOUBook|RunAOUBookApi|RunAll]
)
