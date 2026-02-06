# Migration Guide: Android to Windows

This document explains the conversion from the Android version to the Windows version and helps developers understand the changes.

## Architecture Changes

### Platform Shift
| Aspect | Android Version | Windows Version |
|--------|----------------|-----------------|
| **Language** | Java + Kotlin | C# |
| **Framework** | Android SDK | .NET 8.0 + WPF |
| **UI System** | Activities/Fragments | Windows/UserControls |
| **Archive Library** | p7zip (native C++) | SharpCompress (C#) |
| **Build System** | Gradle + NDK | MSBuild (.NET SDK) |

---

## Code Mapping

### UI Components

#### Main Screen
- **Android**: `StartupActivity.kt` → **Windows**: `MainWindow.xaml` + `MainWindow.xaml.cs`
- Layout defined in XML → Layout defined in XAML
- Click listeners → Event handlers in code-behind

#### Extraction
- **Android**: `ExtractionActivity.java` → **Windows**: `ExtractionWindow.xaml.cs`
- Intents → Direct window instantiation (`new ExtractionWindow().ShowDialog()`)
- File picker: Android Storage Access Framework → `OpenFileDialog` / `OpenFolderDialog`

#### Compression
- **Android**: `CompressActivity.java` + `CompressionFragment.java` → **Windows**: `CompressionWindow.xaml.cs`
- Consolidated into single window
- File selection via standard Windows dialogs

### Archive Operations

#### Extraction
**Android (using p7zip JNI):**
```java
Archive archive = new Archive();
archive.extractArchive(archPath, extractPath, callback);
```

**Windows (using SharpCompress):**
```csharp
using var archive = ArchiveFactory.Open(archivePath);
foreach (var entry in archive.Entries)
{
    entry.WriteToDirectory(destinationPath, extractionOptions);
}
```

#### Compression
**Android (using p7zip JNI):**
```java
archive.createArchive(archName, paths, length, level, 
    dictionary, wordSize, orderMode, solidDefined, 
    solidBlockSize, method, encryptMethod, formatIndex, 
    encryptHeaders, encryptHeadersAllowed, password, 
    multiThread, callback);
```

**Windows (using SharpCompress):**
```csharp
using var stream = File.Create(archivePath);
using var writer = WriterFactory.Open(stream, ArchiveType.Zip, writerOptions);
foreach (var file in files)
{
    writer.Write(Path.GetFileName(file), file);
}
```

---

## Feature Parity

### ✅ Fully Supported
- Extract ZIP archives
- Extract TAR archives  
- Extract GZIP archives
- Extract BZIP2 archives
- Extract RAR archives
- Extract 7z archives (read-only)
- Create ZIP archives
- Create TAR archives
- Create TAR.GZ archives
- Create TAR.BZ2 archives
- Password-protected ZIP extraction
- Progress tracking

### ⚠️ Partially Supported
- **7z Creation**: Android supports via p7zip, Windows read-only
- **Password Protection**: Windows supports ZIP only, Android supports ZIP & 7z
- **Encryption Methods**: Limited to what SharpCompress supports

### ❌ Not Yet Implemented (Future)
- Built-in file browser (uses Windows native dialogs instead)
- Archive information display (format details, codecs)
- Arabic localization
- Multiple compression levels

---

## Dependencies

### Android Version
```gradle
dependencies {
    implementation 'androidx.appcompat:appcompat:1.7.0'
    implementation 'androidx.recyclerview:recyclerview:1.3.2'
    implementation "androidx.lifecycle:lifecycle-viewmodel-ktx:2.8.6"
    // Plus native libraries: lib7z.so, libRar.so, libzeearchiver.so
}
```

### Windows Version
```xml
<ItemGroup>
    <PackageReference Include="SharpCompress" Version="0.37.2" />
</ItemGroup>
```

---

## Threading Model

### Android
- Uses `AsyncTask` and background threads
- Callbacks via interfaces (`UpdateCallback`, `ExtractCallback`)
- UI updates through `runOnUiThread()`

### Windows
- Uses `async`/`await` with `Task.Run()`
- Progress updates via `Dispatcher.Invoke()`
- Automatic UI thread marshaling with WPF data binding

---

## File System Access

### Android
```java
// Requires runtime permissions
if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
    requestPermissions(new String[]{
        Manifest.permission.READ_EXTERNAL_STORAGE,
        Manifest.permission.WRITE_EXTERNAL_STORAGE
    }, REQUEST_CODE);
}
```

### Windows
```csharp
// No special permissions needed
// Uses standard Windows file dialogs
var openFileDialog = new OpenFileDialog();
if (openFileDialog.ShowDialog() == true)
{
    var filePath = openFileDialog.FileName;
    // Process file...
}
```

---

## Error Handling

### Android
```java
try {
    int result = archive.extractArchive(path, dest, callback);
    if (result != 0) {
        // Handle error code
    }
} catch (Exception e) {
    Log.e(TAG, "Error", e);
    showErrorDialog(e.getMessage());
}
```

### Windows
```csharp
try
{
    await Task.Run(() => ExtractArchive(archivePath, destinationPath));
    MessageBox.Show("Success!", "Extraction Complete");
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}", "Error", 
        MessageBoxButton.OK, MessageBoxImage.Error);
}
```

---

## Build & Deployment

### Android
```bash
# Build APK
./gradlew assembleRelease

# Output: app/build/outputs/apk/release/app-release.apk
```

### Windows
```bash
# Build standard exe (requires .NET installed)
dotnet build -c Release

# Build standalone exe (no .NET required)
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# Output: ZeeArchiver/bin/Release/net8.0-windows/win-x64/publish/ZeeArchiver.exe
```

---

## Testing Recommendations

### For Android Developers Transitioning to Windows:

1. **Learn C# Basics**: If you know Java, C# will feel familiar
   - Similar syntax with improvements
   - Better async/await support
   - LINQ for collection operations

2. **Understand WPF**: 
   - XAML is similar to Android XML layouts
   - Data binding is more powerful
   - MVVM pattern is recommended (this version uses code-behind for simplicity)

3. **Development Tools**:
   - Visual Studio 2022 (full IDE, like Android Studio)
   - Visual Studio Code (lightweight, like Android Studio's code editor)
   - JetBrains Rider (paid, excellent for C#)

4. **Debug Windows App**:
   - Set breakpoints in Visual Studio
   - Use Debug → Start Debugging (F5)
   - View output in Debug console

---

## Resources

### Learning C# (for Android/Java developers)
- [C# for Java Developers](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/)
- [WPF Tutorial](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)

### SharpCompress Documentation
- [GitHub](https://github.com/adamhathcock/sharpcompress)
- [API Reference](https://github.com/adamhathcock/sharpcompress/wiki)

### .NET Documentation
- [.NET 8.0 Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [WPF Documentation](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)

---

## Contributing to Windows Version

1. Fork the repository
2. Make changes in the `ZeeArchiver/` directory
3. Test on Windows 10/11
4. Ensure backward compatibility with Android version
5. Update documentation
6. Submit pull request

---

## Future Improvements

Potential enhancements for the Windows version:

- [ ] Implement MVVM pattern for better separation of concerns
- [ ] Add 7z compression support (requires different library or p7zip integration)
- [ ] Add multi-language support (Arabic, etc.)
- [ ] Add dark mode theme
- [ ] Add compression level options
- [ ] Add drag-and-drop support
- [ ] Add context menu integration (right-click on files)
- [ ] Add archive preview without extraction
- [ ] Improve progress reporting with percentage
- [ ] Add archive testing/verification
- [ ] Add batch operations

---

For questions about this migration, contact mahmoudgalal57@yahoo.com
