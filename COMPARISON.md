# Platform Comparison: Android vs Windows

Quick reference guide comparing the Android and Windows versions of ZeeArchiver.

## At a Glance

| Feature | Android | Windows |
|---------|---------|---------|
| **Platform** | Android 6.0+ (API 23+) | Windows 10/11 |
| **Language** | Java + Kotlin | C# |
| **Framework** | Android SDK | .NET 8.0 + WPF |
| **Archive Engine** | p7zip (native C++) | SharpCompress (C#) |
| **Distribution** | APK via Play Store/Amazon | EXE (standalone or with .NET) |
| **Install Size** | ~15-20 MB | ~50-100 MB (standalone) |
| **Repository Location** | `/app` directory | `/ZeeArchiver` directory |

---

## Supported Archive Formats

### Extraction (Read)

| Format | Android | Windows | Notes |
|--------|---------|---------|-------|
| **7z** | ✅ Full | ✅ Full | Both support all 7z features |
| **ZIP** | ✅ Full | ✅ Full | Including password protection |
| **RAR** | ✅ Full (RAR5) | ✅ Full | Read-only due to licensing |
| **TAR** | ✅ Yes | ✅ Yes | Including variants (tar.gz, tar.bz2) |
| **GZIP** | ✅ Yes | ✅ Yes | |
| **BZIP2** | ✅ Yes | ✅ Yes | |
| **XZ** | ✅ Yes | ✅ Yes | |
| **AR** | ✅ Yes | ⚠️ Limited | |
| **ARJ** | ✅ Yes | ❌ No | |
| **CAB** | ✅ Yes | ⚠️ Limited | |
| **CHM** | ✅ Yes | ❌ No | |
| **CPIO** | ✅ Yes | ✅ Yes | |
| **ISO** | ✅ Yes | ✅ Yes | |
| **LZH** | ✅ Yes | ❌ No | |
| **WIM** | ✅ Yes | ⚠️ Limited | |

### Compression (Write)

| Format | Android | Windows | Notes |
|--------|---------|---------|-------|
| **7z** | ✅ Yes | ❌ No | Windows: read-only |
| **ZIP** | ✅ Yes | ✅ Yes | Full support on both |
| **TAR** | ✅ Yes | ✅ Yes | |
| **TAR.GZ** | ✅ Yes | ✅ Yes | |
| **TAR.BZ2** | ✅ Yes | ✅ Yes | |
| **TAR.XZ** | ✅ Yes | ⚠️ Planned | |
| **GZIP** | ✅ Yes | ⚠️ Planned | |
| **BZIP2** | ✅ Yes | ⚠️ Planned | |
| **XZ** | ✅ Yes | ⚠️ Planned | |
| **WIM** | ✅ Yes | ❌ No | |

---

## Features Comparison

### Core Features

| Feature | Android | Windows |
|---------|---------|---------|
| **Extract Archives** | ✅ Yes | ✅ Yes |
| **Create Archives** | ✅ Yes | ✅ Yes |
| **Password Protection** | ✅ ZIP & 7z | ✅ ZIP only |
| **AES-256 Encryption** | ✅ Yes | ✅ ZIP only |
| **Multi-threading** | ✅ Yes | ✅ Yes |
| **Progress Tracking** | ✅ Yes | ✅ Yes |
| **Cancel Operation** | ✅ Yes | ⚠️ Planned |
| **Archive Testing** | ⚠️ Limited | ⚠️ Planned |

### User Interface

| Feature | Android | Windows |
|---------|---------|---------|
| **File Browser** | ✅ Custom built-in | ✅ Windows native dialogs |
| **Batch Selection** | ✅ Yes | ✅ Yes |
| **Drag & Drop** | ❌ No | ⚠️ Planned |
| **Dark Mode** | ⚠️ System | ⚠️ Planned |
| **Localization** | ✅ Arabic | ⚠️ Planned |
| **Archive Preview** | ✅ Yes | ⚠️ Planned |
| **Archive Info** | ✅ Yes (formats, codecs) | ⚠️ Planned |

### Advanced Features

| Feature | Android | Windows |
|---------|---------|---------|
| **Compression Levels** | ✅ Multiple | ⚠️ Default only |
| **Dictionary Size** | ✅ Configurable | ⚠️ Default |
| **Solid Archives** | ✅ Yes (7z) | ❌ No |
| **Split Archives** | ⚠️ Limited | ❌ No |
| **Self-extracting** | ❌ No | ❌ No |
| **Encrypt Headers** | ✅ Yes (7z) | ❌ No |

---

## Performance

| Metric | Android | Windows | Notes |
|--------|---------|---------|-------|
| **Native Code** | ✅ C++ (p7zip) | ❌ Managed C# | Android typically faster |
| **Memory Usage** | ~50-200 MB | ~50-300 MB | Depends on archive size |
| **Startup Time** | < 1 second | < 2 seconds | |
| **Large Files (>1GB)** | ✅ Excellent | ✅ Good | Both handle well |

---

## Distribution & Installation

### Android
```
📱 Distribution Methods:
- Google Play Store
- Amazon App Store  
- Direct APK download

📦 Installation:
- Install APK
- Grant storage permissions
- Ready to use

💾 Size: ~15-20 MB
```

### Windows
```
💻 Distribution Methods:
- GitHub Releases
- Direct download
- Microsoft Store (planned)

📦 Installation:
Option 1: Install .NET 8.0 Runtime + run ZeeArchiver.exe (~5 MB)
Option 2: Standalone exe (no .NET needed, ~50-100 MB)

💾 Size: 5 MB (with .NET) or 50-100 MB (standalone)
```

---

## Build Process

### Android
```bash
# Requirements
- Android Studio
- Android NDK r23
- JDK 17

# Build Steps
1. Build native libraries (p7zip)
   cd p7zip_16.02/CPP/ANDROID/Format7zFree/jni
   ndk-build

2. Build APK
   ./gradlew assembleRelease

# Output
app/build/outputs/apk/release/app-release.apk
```

### Windows
```bash
# Requirements
- .NET 8.0 SDK
- (Optional) Visual Studio 2022

# Build Steps
1. Restore packages
   dotnet restore

2. Build
   dotnet build -c Release

# Or use build scripts
- Windows: build.bat
- Linux/Mac: build.sh

# Output
ZeeArchiver/bin/Release/net8.0-windows/ZeeArchiver.exe
```

---

## Dependencies

### Android
```gradle
// Android Libraries
androidx.appcompat:appcompat:1.7.0
androidx.recyclerview:recyclerview:1.3.2
androidx.lifecycle:lifecycle-viewmodel-ktx:2.8.6
androidx.activity:activity-ktx:1.9.3
kotlin-stdlib-jdk7

// Native Libraries (C++)
- lib7z.so      (p7zip core)
- libRar.so     (RAR support)
- libzeearchiver.so (JNI wrapper)
```

### Windows
```xml
<!-- NuGet Packages -->
<PackageReference Include="SharpCompress" Version="0.37.2" />

<!-- Framework -->
.NET 8.0 (Windows)
WPF (included in .NET)
```

---

## Code Statistics

### Android Version
```
Language: Java + Kotlin
Files: 24 source files
Lines of Code: ~8,000+ (estimated)
Native Code: ~50,000+ lines (p7zip)
Layout Files: ~15 XML files
```

### Windows Version
```
Language: C#
Files: 6 source files + 5 XAML files
Lines of Code: ~775 total
  - C#: ~450 lines
  - XAML: ~325 lines
Dependencies: 1 NuGet package (SharpCompress)
```

---

## Use Cases

### Best for Android:
- ✅ Mobile devices and tablets
- ✅ Need 7z compression
- ✅ Need maximum format support
- ✅ Want Arabic language support
- ✅ Prefer native performance
- ✅ Need archive header encryption

### Best for Windows:
- ✅ Desktop/laptop computers
- ✅ Prefer native Windows UI
- ✅ ZIP/TAR workflows
- ✅ Simpler, cleaner codebase
- ✅ Easier to modify/extend
- ✅ Don't need all p7zip formats

---

## Migration Path

**From Android to Windows:**
1. Review [MIGRATION.md](MIGRATION.md) for code mapping
2. Note format support differences
3. Test your archive types on Windows version
4. Consider using both versions for different platforms

**From Windows to Android:**
1. Install from Play Store or APK
2. All Windows-created archives work on Android
3. Gain access to more formats and compression options

---

## Future Roadmap

### Android (Maintenance)
- ✅ Stable and feature-complete
- Security updates
- Bug fixes
- Android version updates

### Windows (Active Development)
- 🔨 Add 7z compression support
- 🔨 Implement advanced compression options
- 🔨 Add drag-and-drop support
- 🔨 Add dark mode theme
- 🔨 Add multi-language support
- 🔨 Add archive preview
- 🔨 Add context menu integration
- 🔨 Improve UI/UX

---

## Getting Help

### Android Version
- Original developer: Mahmoud Galal
- Email: mahmoudgalal57@yahoo.com
- Play Store: Reviews/ratings

### Windows Version  
- GitHub Issues: [Create Issue](https://github.com/druvx13/ZeeArchiver-Android/issues)
- Email: mahmoudgalal57@yahoo.com
- Documentation: README_WINDOWS.md, QUICKSTART_WINDOWS.md

---

## Quick Start Links

- **Android**: See main [README.md](README.md)
- **Windows**: See [QUICKSTART_WINDOWS.md](QUICKSTART_WINDOWS.md)
- **Developers**: See [MIGRATION.md](MIGRATION.md)

---

**Both versions are MIT licensed and open source! 🎉**
