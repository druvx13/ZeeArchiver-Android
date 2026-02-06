#!/bin/bash

echo "Building ZeeArchiver for Windows..."
echo ""

# Check if .NET SDK is installed
if ! command -v dotnet &> /dev/null; then
    echo "ERROR: .NET SDK is not installed or not in PATH."
    echo "Please download and install .NET 8.0 SDK from:"
    echo "https://dotnet.microsoft.com/download/dotnet/8.0"
    exit 1
fi

echo "Restoring NuGet packages..."
dotnet restore ZeeArchiver.sln
if [ $? -ne 0 ]; then
    echo "ERROR: Failed to restore packages."
    exit 1
fi

echo ""
echo "Building in Release configuration..."
dotnet build ZeeArchiver.sln --configuration Release
if [ $? -ne 0 ]; then
    echo "ERROR: Build failed."
    exit 1
fi

echo ""
echo "========================================"
echo "Build completed successfully!"
echo "========================================"
echo ""
echo "Executable location:"
echo "ZeeArchiver/bin/Release/net8.0-windows/ZeeArchiver.exe"
echo ""
echo "Note: To run on Linux/Mac, you need Wine or a Windows VM."
echo "To create a self-contained executable, run: ./build-standalone.sh"
echo ""
