# ZeeArchiver - Windows Edition

![ZeeArchiver](app/src/main/res/drawable-hdpi/zeearchiver.png)

**ZeeArchiver** is an efficient and simple-to-use archiver and decompressor for Windows. It supports compression and decompression for multiple archive formats including 7z, ZIP, TAR, GZIP, BZIP2, XZ, and RAR.

**Copyright © 2025 Mahmoud Galal**  
For support, contact: mahmoudgalal57@yahoo.com

---

## 🎯 About This Windows Version

This is a **Windows desktop application** converted from the original Android version. It provides the same core functionality with a native Windows WPF user interface.

### Key Differences from Android Version:
- **Platform**: Windows desktop (WPF) instead of Android
- **Language**: C# (.NET 8.0) instead of Java/Kotlin
- **Archive Library**: SharpCompress instead of p7zip native library
- **UI Framework**: WPF (Windows Presentation Foundation) instead of Android Activities/Fragments

---

## ✨ Features

### Supported Formats:
- **Extraction**: 7z, ZIP, RAR, TAR, GZIP (*.gz), BZIP2 (*.bz2), XZ, TAR.GZ, TAR.BZ2, TAR.XZ, and more
- **Compression**: ZIP, TAR, TAR.GZ, TAR.BZ2

### Capabilities:
- Extract archives to any folder on your system
- Create new archives from files and folders
- Simple and intuitive user interface
- Progress tracking during operations
- Support for password-protected archives (ZIP format)
- Multi-file selection for compression

---

## 🔧 System Requirements

- **Operating System**: Windows 10 or Windows 11
- **.NET Runtime**: .NET 8.0 or later
- **RAM**: 2 GB minimum, 4 GB recommended
- **Storage**: 50 MB for installation

---

## 📦 Installation

### Option 1: Download Pre-built Binary (Recommended)

**Using GitHub Actions (Always Latest):**
1. Go to the [Actions tab](https://github.com/druvx13/ZeeArchiver-Android/actions)
2. Click on "Build Windows Application"
3. Select the latest successful run (green checkmark)
4. Scroll down and download **ZeeArchiver-Windows-x64.zip** from artifacts
5. Extract and run `ZeeArchiver.exe`

> 💡 **Note:** The executable is self-contained (includes .NET runtime). No additional installation needed!

**From GitHub Releases:**
1. Download the latest release from the [Releases](https://github.com/druvx13/ZeeArchiver-Android/releases) page
2. Extract the ZIP file to a folder of your choice
3. Run `ZeeArchiver.exe`

> 📖 **For detailed build instructions:** See [.github/BUILDING.md](.github/BUILDING.md)

### Option 2: Build from Source

#### Prerequisites:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- Visual Studio 2022 (optional, for IDE support)

#### Build Steps:

1. **Clone the repository:**
   ```bash
   git clone https://github.com/druvx13/ZeeArchiver-Android.git
   cd ZeeArchiver-Android
   ```

2. **Build the project:**
   ```bash
   dotnet build ZeeArchiver.sln --configuration Release
   ```

3. **Run the application:**
   ```bash
   dotnet run --project ZeeArchiver/ZeeArchiver.csproj
   ```

   Or navigate to the build output:
   ```bash
   cd ZeeArchiver/bin/Release/net8.0-windows
   ZeeArchiver.exe
   ```

#### Create a Standalone Executable:
To create a self-contained executable that doesn't require .NET runtime to be installed:

```bash
dotnet publish ZeeArchiver/ZeeArchiver.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true
```

The executable will be in `ZeeArchiver/bin/Release/net8.0-windows/win-x64/publish/`

---

## 🚀 Usage

### Extracting an Archive:
1. Launch ZeeArchiver
2. Click **"Extract Archive"**
3. Browse and select the archive file you want to extract
4. Choose the destination folder
5. Click **"Extract"**
6. Wait for the extraction to complete

### Creating an Archive:
1. Launch ZeeArchiver
2. Click **"Create Archive"**
3. Click **"Add Files"** or **"Add Folder"** to select files/folders to compress
4. Select the archive format (ZIP, TAR, TAR.GZ, TAR.BZ2)
5. Choose where to save the archive
6. Click **"Create Archive"**
7. Wait for the compression to complete

---

## 🏗️ Project Structure

```
ZeeArchiver-Android/
├── ZeeArchiver/                  # Windows WPF Application
│   ├── MainWindow.xaml          # Main application window
│   ├── ExtractionWindow.xaml    # Archive extraction interface
│   ├── CompressionWindow.xaml   # Archive creation interface
│   ├── Styles/                  # UI styling resources
│   └── ZeeArchiver.csproj       # C# project file
├── ZeeArchiver.sln              # Visual Studio solution file
├── app/                         # Original Android app (for reference)
└── README_WINDOWS.md            # This file
```

---

## 🛠️ Technologies Used

- **Framework**: .NET 8.0 (Windows)
- **UI**: WPF (Windows Presentation Foundation)
- **Archive Library**: [SharpCompress](https://github.com/adamhathcock/sharpcompress)
- **Language**: C# 12.0

---

## 📋 Original Android Version

The original Android version of this application is still available in the `app/` directory. It includes:
- Native p7zip integration via JNI
- Android-specific UI components
- Support for more archive formats through p7zip

For more information about the Android version, see the main [README.md](README.md).

---

## 🐛 Known Limitations

1. **7z Compression**: Not yet supported (extraction only). The SharpCompress library primarily focuses on reading 7z archives.
2. **RAR Compression**: Not supported (extraction only due to licensing restrictions).
3. **Archive Password**: Currently only supports password-protected ZIP files.

---

## 🤝 Contributing

Contributions are welcome! If you'd like to improve the Windows version:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -m 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the [MIT License](LICENSE).

---

## 📧 Support

For bug reports, feature requests, or support:
- **Email**: mahmoudgalal57@yahoo.com
- **GitHub Issues**: [Create an issue](https://github.com/druvx13/ZeeArchiver-Android/issues)

---

## 🙏 Acknowledgments

- Original Android application by Mahmoud Galal
- [SharpCompress](https://github.com/adamhathcock/sharpcompress) library by Adam Hathcock
- [p7zip](http://p7zip.sourceforge.net/) project for the Android native implementation
- Microsoft for .NET and WPF frameworks

---

**Enjoy using ZeeArchiver on Windows! 🎉**
