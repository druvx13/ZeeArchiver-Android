# GitHub Actions - Building Windows Application

This repository includes a GitHub Actions workflow that automatically builds the Windows version of ZeeArchiver.

## 🚀 How to Build

### Method 1: Manual Trigger (Recommended for Testing)

1. **Navigate to Actions Tab**
   - Go to the repository on GitHub
   - Click on the "Actions" tab at the top

2. **Select the Workflow**
   - Click on "Build Windows Application" in the left sidebar

3. **Run the Workflow**
   - Click the "Run workflow" button (on the right side)
   - (Optional) Enter a version number (e.g., v1.0.0)
   - Click the green "Run workflow" button

4. **Wait for Build to Complete**
   - The build typically takes 2-5 minutes
   - You'll see a green checkmark when it's done

5. **Download the Artifacts**
   - Click on the completed workflow run
   - Scroll to the bottom of the page
   - Under "Artifacts", you'll see:
     - **ZeeArchiver-Windows-x64.zip** - Full package with VERSION.txt
     - **ZeeArchiver-Windows-Executable** - Just the .exe file
   - Click to download

### Method 2: Automatic Trigger on Push

The workflow also runs automatically when:
- Code is pushed to branches: `main` or `copilot/convert-android-to-windows-app`
- Changes are made to files in the `ZeeArchiver/` directory
- A Git tag starting with `v` is created (e.g., `v1.0.0`)

### Method 3: Release Tags

To create a versioned release:

```bash
# Create and push a tag
git tag v1.0.0
git push origin v1.0.0
```

This will trigger the build and create artifacts with version v1.0.0.

---

## 📦 What Gets Built

The GitHub Actions workflow creates:

### 1. ZeeArchiver-Windows-x64.zip
A complete package containing:
- `ZeeArchiver.exe` - The main application (self-contained)
- `VERSION.txt` - Build information (version, commit hash, build date)

**File Size:** ~50-100 MB (includes .NET runtime)

### 2. ZeeArchiver.exe (Standalone)
Just the executable file, available as a separate artifact.

### 3. SHA256 Checksum
`ZeeArchiver-Windows-x64.zip.sha256` - For verifying download integrity

---

## ✅ Build Features

The GitHub Actions workflow:

- ✅ **Self-Contained** - Includes .NET runtime (no installation needed)
- ✅ **Single File** - Everything in one executable
- ✅ **Trimmed** - Unused code removed for smaller size
- ✅ **Windows x64** - Optimized for 64-bit Windows
- ✅ **Checksums** - SHA256 hash for security verification
- ✅ **Version Info** - Tracks build date and commit
- ✅ **90-day Retention** - Artifacts kept for 3 months

---

## 🔍 Verifying Downloads

After downloading, verify the integrity:

### On Windows (PowerShell):
```powershell
# Calculate hash of downloaded file
$hash = Get-FileHash -Path ZeeArchiver-Windows-x64.zip -Algorithm SHA256
$hash.Hash

# Compare with provided checksum
Get-Content ZeeArchiver-Windows-x64.zip.sha256
```

### On Linux/Mac:
```bash
# Calculate hash
sha256sum ZeeArchiver-Windows-x64.zip

# Compare with provided checksum
cat ZeeArchiver-Windows-x64.zip.sha256
```

The hashes should match exactly.

---

## 📋 Build Requirements

The workflow uses:
- **Runner:** Windows Latest (GitHub-hosted)
- **.NET SDK:** 8.0.x
- **Actions:**
  - `actions/checkout@v4` - Check out code
  - `actions/setup-dotnet@v4` - Set up .NET
  - `actions/upload-artifact@v4` - Upload build artifacts

---

## 🛠️ Customizing the Build

### Change Version Number

When manually triggering, you can specify a version:
1. Click "Run workflow"
2. Enter version in the input field (e.g., `v1.2.3`)
3. Click "Run workflow"

The version will appear in `VERSION.txt`.

### Modify Build Configuration

Edit `.github/workflows/build-windows.yml` to:
- Change target platform (e.g., `win-arm64`)
- Adjust retention days
- Add additional build steps
- Modify artifact contents

### Build for Different Architectures

To build for ARM64:
```yaml
- name: Publish self-contained Windows ARM64 executable
  run: |
    dotnet publish ZeeArchiver/ZeeArchiver.csproj `
      -c Release `
      -r win-arm64 `
      --self-contained true `
      -p:PublishSingleFile=true `
      -o ./publish/win-arm64
```

---

## 🚨 Troubleshooting

### Build Fails

**Check the logs:**
1. Go to the Actions tab
2. Click on the failed workflow run
3. Click on the failed job/step
4. Review the error message

**Common issues:**
- `.NET SDK not found` → Check .NET version in workflow
- `Project not found` → Verify project path is correct
- `Out of disk space` → Reduce `PublishTrimmed` size

### No Artifacts Available

**Possible causes:**
- Build failed before upload step
- Artifact expired (90-day retention)
- Insufficient permissions

**Solution:**
- Check if build completed successfully
- Verify you're logged into GitHub
- Re-run the workflow

### Checksum Doesn't Match

**What to do:**
1. Re-download the file
2. Check for network issues
3. Verify you're comparing the right files
4. If still failing, re-run the build

---

## 📊 Workflow Status

You can add a status badge to your README:

```markdown
![Build Status](https://github.com/druvx13/ZeeArchiver-Android/workflows/Build%20Windows%20Application/badge.svg)
```

This shows whether the latest build passed or failed.

---

## 💡 Tips

1. **Bookmark the Actions Page** - For quick access to builds
2. **Watch for Notifications** - GitHub will email you when builds fail
3. **Clean Old Artifacts** - They expire after 90 days automatically
4. **Tag Releases** - Use semantic versioning (v1.0.0, v1.1.0, etc.)
5. **Test Locally First** - Run `build.bat` before triggering CI

---

## 🔗 Related Documentation

- [Main README](../README.md) - Android version
- [Windows README](../README_WINDOWS.md) - Windows implementation details
- [Quick Start](../QUICKSTART_WINDOWS.md) - Getting started guide
- [Build Scripts](../build.bat) - Local build instructions

---

## 📞 Support

If you encounter issues with the GitHub Actions build:

1. Check existing [GitHub Issues](https://github.com/druvx13/ZeeArchiver-Android/issues)
2. Review workflow logs for error details
3. Create a new issue with:
   - Workflow run URL
   - Error message
   - Steps to reproduce

---

**Happy Building! 🎉**
