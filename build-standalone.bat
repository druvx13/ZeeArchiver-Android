@echo off
echo Building standalone ZeeArchiver for Windows...
echo.

REM Check if .NET SDK is installed
dotnet --version >nul 2>&1
if errorlevel 1 (
    echo ERROR: .NET SDK is not installed or not in PATH.
    echo Please download and install .NET 8.0 SDK from:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    pause
    exit /b 1
)

echo Publishing self-contained application for Windows x64...
dotnet publish ZeeArchiver/ZeeArchiver.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:PublishTrimmed=true
if errorlevel 1 (
    echo ERROR: Publish failed.
    pause
    exit /b 1
)

echo.
echo ========================================
echo Standalone build completed successfully!
echo ========================================
echo.
echo Self-contained executable location:
echo ZeeArchiver\bin\Release\net8.0-windows\win-x64\publish\ZeeArchiver.exe
echo.
echo This executable includes all dependencies and doesn't require .NET to be installed.
echo You can copy this file and run it on any Windows 10/11 machine.
echo.
pause
