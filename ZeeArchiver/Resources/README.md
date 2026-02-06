# Resources Directory

This directory contains resources for the Windows application.

## Icon File

To add an application icon:
1. Convert the existing Android icon (`app/src/main/res/drawable-hdpi/zeearchiver.png`) to `.ico` format
2. Save it as `zeearchiver.ico` in this directory
3. Uncomment the `<ApplicationIcon>` line in `ZeeArchiver.csproj`

You can use online tools like:
- https://convertio.co/png-ico/
- https://www.icoconverter.com/

Or use ImageMagick:
```bash
convert zeearchiver.png -define icon:auto-resize=256,128,64,48,32,16 zeearchiver.ico
```
