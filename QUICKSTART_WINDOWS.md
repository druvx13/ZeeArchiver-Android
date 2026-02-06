# ZeeArchiver - Windows Quick Start Guide

This guide will help you get started with the Windows version of ZeeArchiver.

## For End Users (Just Want to Use the App)

### Option 1: Download from GitHub Actions (Easiest & Always Latest)
1. Go to [Actions tab](https://github.com/druvx13/ZeeArchiver-Android/actions)
2. Click "Build Windows Application" in the left sidebar
3. Click the latest successful workflow run (green checkmark)
4. Scroll to bottom and download **ZeeArchiver-Windows-x64.zip**
5. Extract the ZIP file
6. Run `ZeeArchiver.exe`

> ✅ **Self-contained:** No .NET installation needed!  
> 📖 **Detailed instructions:** [.github/BUILDING.md](.github/BUILDING.md)

### Option 2: Download Pre-built Release
1. Go to the [Releases](https://github.com/druvx13/ZeeArchiver-Android/releases) page
2. Download the latest Windows release (ZeeArchiver-Windows-vX.X.X.zip)
3. Extract the ZIP file
4. Run `ZeeArchiver.exe`

### Option 3: Build It Yourself

#### Requirements:
- Windows 10 or Windows 11
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

#### Steps:
1. **Download the code:**
   - Click the green "Code" button on GitHub
   - Select "Download ZIP"
   - Extract the ZIP file

2. **Build the application:**
   - Open Command Prompt or PowerShell
   - Navigate to the extracted folder
   - Run: `build.bat`

3. **Run the application:**
   - Navigate to: `ZeeArchiver\bin\Release\net8.0-windows\`
   - Double-click `ZeeArchiver.exe`

#### Create Standalone Executable:
If you want a single executable that doesn't require .NET to be installed:
1. Run: `build-standalone.bat`
2. Find the executable in: `ZeeArchiver\bin\Release\net8.0-windows\win-x64\publish\`
3. Copy `ZeeArchiver.exe` to any Windows machine and run it!

---

## For Developers

### Development Requirements:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- (Optional) [Visual Studio 2022](https://visualstudio.microsoft.com/) with .NET desktop development workload
- (Optional) [Visual Studio Code](https://code.visualstudio.com/) with C# extension

### Getting Started:

#### Using Visual Studio:
1. Clone the repository
2. Open `ZeeArchiver.sln` in Visual Studio 2022
3. Press F5 to build and run

#### Using Command Line:
```bash
# Clone the repository
git clone https://github.com/druvx13/ZeeArchiver-Android.git
cd ZeeArchiver-Android

# Restore packages
dotnet restore ZeeArchiver.sln

# Build
dotnet build ZeeArchiver.sln

# Run
dotnet run --project ZeeArchiver/ZeeArchiver.csproj
```

### Project Structure:
```
ZeeArchiver/
├── App.xaml              # Application definition
├── App.xaml.cs           # Application code-behind
├── MainWindow.xaml       # Main window UI
├── MainWindow.xaml.cs    # Main window logic
├── ExtractionWindow.xaml # Extraction UI
├── ExtractionWindow.xaml.cs
├── CompressionWindow.xaml # Compression UI
├── CompressionWindow.xaml.cs
├── Styles/
│   └── AppStyles.xaml    # UI styles and themes
└── Resources/            # Images, icons, etc.
```

### Key Technologies:
- **Framework**: .NET 8.0 (Windows)
- **UI**: WPF (Windows Presentation Foundation)
- **Archive Library**: SharpCompress 0.37.2
- **Language**: C# 12.0

### Adding New Features:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Test thoroughly
5. Submit a pull request

---

## Common Issues

### "Application failed to start"
- **Solution**: Install [.NET 8.0 Runtime](https://dotnet.microsoft.com/download/dotnet/8.0) or use the standalone build

### "Unable to extract archive"
- **Solution**: Make sure you have write permissions to the destination folder
- Try extracting to a different location (e.g., Desktop or Documents)

### "Build failed"
- **Solution**: Make sure .NET 8.0 SDK is installed
- Run `dotnet --version` to verify installation
- Try running `dotnet restore` first

### Archive format not supported
- Current supported formats:
  - **Extraction**: 7z, ZIP, RAR, TAR, GZ, BZ2, XZ, and combinations
  - **Compression**: ZIP, TAR, TAR.GZ, TAR.BZ2

---

## Feature Comparison: Windows vs Android

| Feature | Windows | Android |
|---------|---------|---------|
| Extract 7z | ✅ Yes | ✅ Yes |
| Extract ZIP | ✅ Yes | ✅ Yes |
| Extract RAR | ✅ Yes | ✅ Yes |
| Extract TAR/GZ/BZ2 | ✅ Yes | ✅ Yes |
| Create 7z | ❌ No | ✅ Yes |
| Create ZIP | ✅ Yes | ✅ Yes |
| Create TAR | ✅ Yes | ✅ Yes |
| Password Support | ✅ ZIP only | ✅ ZIP & 7z |
| File Browser | ✅ Windows native | ✅ Custom |
| Multi-threading | ✅ Yes | ✅ Yes |

---

## Support

For issues, questions, or feature requests:
- **GitHub Issues**: [Create an issue](https://github.com/druvx13/ZeeArchiver-Android/issues)
- **Email**: mahmoudgalal57@yahoo.com

---

## Next Steps

After installing:
1. Try extracting an archive
2. Try creating a new archive
3. Explore the different compression formats
4. Share feedback!

For more detailed information, see [README_WINDOWS.md](README_WINDOWS.md).
