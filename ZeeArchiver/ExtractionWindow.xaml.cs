using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Readers;
using System.Threading.Tasks;

namespace ZeeArchiver
{
    public partial class ExtractionWindow : Window
    {
        private string? selectedArchivePath;
        private string? extractionPath;

        public ExtractionWindow()
        {
            InitializeComponent();
        }

        private void SelectArchiveButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Select Archive to Extract",
                Filter = "All Archives|*.7z;*.zip;*.rar;*.tar;*.gz;*.bz2;*.xz;*.tar.gz;*.tar.bz2;*.tar.xz;*.tgz;*.tbz2;*.txz|" +
                        "7-Zip Archives (*.7z)|*.7z|" +
                        "ZIP Archives (*.zip)|*.zip|" +
                        "RAR Archives (*.rar)|*.rar|" +
                        "TAR Archives (*.tar)|*.tar|" +
                        "GZIP Archives (*.gz)|*.gz|" +
                        "BZIP2 Archives (*.bz2)|*.bz2|" +
                        "XZ Archives (*.xz)|*.xz|" +
                        "All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedArchivePath = openFileDialog.FileName;
                ArchivePathTextBox.Text = selectedArchivePath;
                
                // Auto-suggest extraction path
                var directory = Path.GetDirectoryName(selectedArchivePath);
                var fileName = Path.GetFileNameWithoutExtension(selectedArchivePath);
                extractionPath = Path.Combine(directory ?? "", fileName);
                ExtractionPathTextBox.Text = extractionPath;
            }
        }

        private void SelectExtractionPathButton_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new OpenFolderDialog
            {
                Title = "Select Extraction Folder"
            };

            if (folderDialog.ShowDialog() == true)
            {
                extractionPath = folderDialog.FolderName;
                ExtractionPathTextBox.Text = extractionPath;
            }
        }

        private async void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(selectedArchivePath))
            {
                MessageBox.Show("Please select an archive file to extract.", "No Archive Selected", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(extractionPath))
            {
                MessageBox.Show("Please select an extraction path.", "No Extraction Path", 
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!File.Exists(selectedArchivePath))
            {
                MessageBox.Show("The selected archive file does not exist.", "File Not Found", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Disable UI during extraction
            ExtractButton.IsEnabled = false;
            ProgressBar.Visibility = Visibility.Visible;
            StatusTextBlock.Text = "Extracting...";

            try
            {
                await Task.Run(() => ExtractArchive(selectedArchivePath, extractionPath));

                MessageBox.Show($"Archive extracted successfully to:\n{extractionPath}", 
                    "Extraction Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                
                StatusTextBlock.Text = "Extraction completed successfully!";
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error extracting archive:\n{ex.Message}", "Extraction Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                StatusTextBlock.Text = "Extraction failed.";
            }
            finally
            {
                ExtractButton.IsEnabled = true;
                ProgressBar.Visibility = Visibility.Collapsed;
            }
        }

        private void ExtractArchive(string archivePath, string destinationPath)
        {
            // Create destination directory if it doesn't exist
            Directory.CreateDirectory(destinationPath);

            using var archive = ArchiveFactory.Open(archivePath);
            var extractionOptions = new ExtractionOptions
            {
                ExtractFullPath = true,
                Overwrite = true
            };

            foreach (var entry in archive.Entries)
            {
                if (!entry.IsDirectory)
                {
                    Dispatcher.Invoke(() => 
                    {
                        StatusTextBlock.Text = $"Extracting: {entry.Key}";
                    });
                    
                    entry.WriteToDirectory(destinationPath, extractionOptions);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
