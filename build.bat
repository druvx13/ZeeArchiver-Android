@echo off
echo Building ZeeArchiver for Windows...
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

echo Restoring NuGet packages...
dotnet restore ZeeArchiver.sln
if errorlevel 1 (
    echo ERROR: Failed to restore packages.
    pause
    exit /b 1
)

echo.
echo Building in Release configuration...
dotnet build ZeeArchiver.sln --configuration Release
if errorlevel 1 (
    echo ERROR: Build failed.
    pause
    exit /b 1
)

echo.
echo ========================================
echo Build completed successfully!
echo ========================================
echo.
echo Executable location:
echo ZeeArchiver\bin\Release\net8.0-windows\ZeeArchiver.exe
echo.
echo To create a self-contained executable, run:
echo build-standalone.bat
echo.
pause
