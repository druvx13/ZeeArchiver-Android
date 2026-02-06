# ZeeArchiver - Dual Platform Archive Manager

## 🎯 Project Overview

ZeeArchiver is now available on **TWO platforms**:

```
┌─────────────────────────────────────────────────────────────┐
│                     ZeeArchiver                            │
│         Archive Compression & Extraction Tool              │
└─────────────────────────────────────────────────────────────┘
                          │
                          ├─────────────┬─────────────┐
                          │             │             │
                     ┌────▼────┐   ┌───▼────┐   ┌───▼────┐
                     │ Android │   │Windows │   │ Future │
                     │ Version │   │Version │   │  Web?  │
                     └─────────┘   └────────┘   └────────┘
```

---

## 📁 Repository Structure

```
ZeeArchiver-Android/
│
├── 📱 Android Application (/app)
│   ├── Java + Kotlin source code
│   ├── Native C++ (p7zip integration)
│   ├── Android layouts & resources
│   └── Gradle build system
│
├── 💻 Windows Application (/ZeeArchiver)
│   ├── C# source code
│   ├── WPF XAML layouts
│   ├── SharpCompress library
│   └── .NET build system
│
├── 📚 Documentation
│   ├── README.md              (Main - Android focused)
│   ├── README_WINDOWS.md      (Windows detailed guide)
│   ├── QUICKSTART_WINDOWS.md  (Windows quick start)
│   ├── MIGRATION.md           (Android→Windows dev guide)
│   ├── COMPARISON.md          (Platform comparison)
│   └── PROJECT_SUMMARY.md     (This file)
│
└── 🔧 Build Scripts
    ├── build.sh               (Linux/Mac)
    ├── build.bat              (Windows)
    └── build-standalone.bat   (Windows standalone)
```

---

## 🚀 Quick Start

### For Users

#### Android:
1. Download from [Play Store](https://play.google.com/store/apps/details?id=com.mg.zeearchiver)
2. Or download APK from releases
3. Install and grant permissions
4. Start archiving!

#### Windows:
1. Download from [Releases](https://github.com/druvx13/ZeeArchiver-Android/releases)
2. Extract and run `ZeeArchiver.exe`
3. Or build from source (see below)

### For Developers

#### Build Android Version:
```bash
# Requires: Android Studio, Android NDK r23
cd app
./gradlew assembleRelease
```

#### Build Windows Version:
```bash
# Requires: .NET 8.0 SDK
dotnet restore ZeeArchiver.sln
dotnet build ZeeArchiver.sln -c Release

# Or use build scripts:
build.bat        # Windows
./build.sh       # Linux/Mac
```

---

## ⚡ Key Features

### Common Features (Both Platforms)
- ✅ Extract 7z, ZIP, RAR, TAR, GZIP, BZIP2, XZ archives
- ✅ Create ZIP and TAR archives
- ✅ Password-protected archives (ZIP)
- ✅ Progress tracking
- ✅ Multi-file operations
- ✅ User-friendly interface

### Android Exclusive
- ✅ Create 7z archives
- ✅ More compression options
- ✅ Arabic localization
- ✅ Archive info viewer
- ✅ Custom file browser

### Windows Exclusive
- ✅ Native Windows integration
- ✅ Simpler, cleaner codebase
- ✅ Easier to modify
- ✅ No permissions needed
- ✅ Smaller dependency tree

---

## 📊 Technical Comparison

| Aspect | Android | Windows |
|--------|---------|---------|
| **Language** | Java + Kotlin | C# |
| **UI Framework** | Android SDK | WPF |
| **Archive Library** | p7zip (C++) | SharpCompress (C#) |
| **Lines of Code** | ~8,000+ | ~775 |
| **Native Code** | Yes (50k+ lines) | No |
| **Complexity** | High | Low |
| **Maintainability** | Moderate | High |
| **Performance** | Excellent | Very Good |
| **Format Support** | Extensive | Good |

---

## 📦 Supported Formats

### Extraction (Read)
Both versions support:
- 7z, ZIP, RAR, TAR, TAR.GZ, TAR.BZ2, TAR.XZ
- GZIP (.gz), BZIP2 (.bz2), XZ
- ISO, CPIO

Android additionally supports:
- AR, ARJ, CAB, CHM, DMG, LZH, WIM, and more

### Compression (Write)
Both versions support:
- ZIP, TAR, TAR.GZ, TAR.BZ2

Android additionally supports:
- 7z (with full options)
- XZ, GZIP, BZIP2 standalone
- WIM

---

## 🛠️ Technology Stack

### Android Version
```
┌─────────────────────────┐
│   Android Application   │
│   (Java + Kotlin)       │
├─────────────────────────┤
│   JNI Wrapper Layer     │
│   (C++)                 │
├─────────────────────────┤
│   p7zip Library         │
│   (Native C++)          │
└─────────────────────────┘
```

### Windows Version
```
┌─────────────────────────┐
│   WPF Application       │
│   (C# + XAML)           │
├─────────────────────────┤
│   SharpCompress         │
│   (Pure C#)             │
├─────────────────────────┤
│   .NET 8.0 Runtime      │
└─────────────────────────┘
```

---

## 📈 Development Status

### Android Version: ✅ **Stable**
- Mature and feature-complete
- Available on Play Store and Amazon
- Maintenance mode (bug fixes, updates)

### Windows Version: 🚀 **Active Development**
- Recently converted from Android
- Core features complete
- Additional features in progress
- Community contributions welcome!

---

## 🎯 Use Cases

### Use Android Version When:
- 📱 Working on mobile devices
- 🗜️ Need 7z compression
- 🌍 Need Arabic language
- ⚡ Need maximum performance
- 📚 Need extensive format support

### Use Windows Version When:
- 💻 Working on desktop/laptop
- 🪟 Want native Windows experience
- 📦 ZIP/TAR is sufficient
- 🔧 Want to modify the code
- 🎯 Prefer simpler architecture

---

## 🤝 Contributing

We welcome contributions to both versions!

### Contributing to Android:
- Follow Android development guidelines
- Understand JNI and native code
- Test on multiple Android versions
- Maintain backward compatibility

### Contributing to Windows:
- Follow C# coding conventions
- Use WPF best practices
- Test on Windows 10 and 11
- Keep dependencies minimal

See individual README files for detailed contribution guidelines.

---

## 📄 License

**MIT License** - Both versions are free and open source!

Copyright © 2025 Mahmoud Galal

---

## 📞 Support & Contact

- **Email**: mahmoudgalal57@yahoo.com
- **Issues**: [GitHub Issues](https://github.com/druvx13/ZeeArchiver-Android/issues)
- **Android**: [Play Store Reviews](https://play.google.com/store/apps/details?id=com.mg.zeearchiver)

---

## 🗺️ Documentation Guide

Choose your path:

```
📚 I want to...
│
├─ Use the Android app
│  └─ Read: README.md
│
├─ Use the Windows app
│  └─ Read: QUICKSTART_WINDOWS.md or README_WINDOWS.md
│
├─ Understand the differences
│  └─ Read: COMPARISON.md
│
├─ Migrate Android code to Windows
│  └─ Read: MIGRATION.md
│
└─ Get a high-level overview
   └─ Read: PROJECT_SUMMARY.md (this file)
```

---

## 🎉 What's Next?

### Planned Features:
- 🌙 Dark mode for Windows
- 🌍 Multi-language support for Windows
- 🖱️ Drag & drop for Windows
- 📊 Improved compression options for Windows
- 🔍 Archive preview for Windows
- 🔄 Context menu integration for Windows

### Future Platforms:
- 🌐 Web version (planned)
- 🐧 Linux native version (considering)
- 🍎 macOS version (considering)

---

**Thank you for using ZeeArchiver! 🙏**

Choose your platform and start archiving today!
