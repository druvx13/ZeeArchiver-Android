using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using SharpCompress.Common;
using SharpCompress.Writers;
using System.Threading.Tasks;

namespace ZeeArchiver
{
    public partial class CompressionWindow : Window
    {
        private List<string> selectedFiles = new List<string>();
        private string? outputPath;

        public CompressionWindow()
        {
            InitializeComponent();
            CompressionFormatComboBox.SelectedIndex = 0; // Default to ZIP
        }

        private void SelectFilesButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Select Files to Compress",
                Multiselect = true,
                Filter = "All Files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFiles.AddRange(openFileDialog.FileNames);
                UpdateFilesList();
            }
        }

        private void SelectFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var folderDialog = new OpenFolderDialog
            {
                Title = "Select Folder to Compress"
            };

            if (folderDialog.ShowDialog() == true)
            {
                var folderPath = folderDialog.FolderName;
                var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
                selectedFiles.AddRange(files);
                UpdateFilesList();
            }
        }

        private void ClearFilesButton_Click(object sender, RoutedEventArgs e)
        {
            selectedFiles.Clear();
            UpdateFilesList();
        }

        private void UpdateFilesList()
        {
            FilesListBox.Items.Clear();
            foreach (var file in selectedFiles.Distinct())
            {
                FilesListBox.Items.Add(Path.GetFileName(file));
            }
            FileCountTextBlock.Text = $"{selectedFiles.Count} file(s) selected";
        }

        private void SelectOutputButton_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Save Archive As",
                Filter = "ZIP Archive (*.zip)|*.zip|" +
                        "TAR Archive (*.tar)|*.tar|" +
                        "GZIP Archive (*.tar.gz)|*.tar.gz|" +
                        "BZIP2 Archive (*.tar.bz2)|*.tar.bz2"
            };

            // Set default extension based on selected format
            var format = (CompressionFormatComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            switch (format)
            {
                case "ZIP":
                    saveFileDialog.DefaultExt = ".zip";
                    saveFileDialog.FilterIndex = 1;
                    break;
                case "TAR":
                    saveFileDialog.DefaultExt = ".tar";
                    saveFileDialog.FilterIndex = 2;
                    break;
                case "TAR.GZ":
                    saveFileDialog.DefaultExt = ".tar.gz";
                    saveFileDialog.FilterIndex = 3;
                    break;
                case "TAR.BZ2":
                    saveFileDialog.DefaultExt = ".tar.bz2";
                    saveFileDialog.FilterIndex = 4;
                    break;
            }

            if (saveFileDialog.ShowDialog() == true)
            {
                outputPath = saveFileDialog.FileName;
                OutputPathTextBox.Text = outputPath;
            }
        }

        private async void CompressButton_Click(object sender, RoutedEventArgs e)
        {
            if (!selectedFiles.Any())
            {
                MessageBox.Show("Please select files or folders to compress.", "No Files Selected",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                MessageBox.Show("Please specify an output path for the archive.", "No Output Path",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Disable UI during compression
            CompressButton.IsEnabled = false;
            ProgressBar.Visibility = Visibility.Visible;
            StatusTextBlock.Text = "Compressing...";

            try
            {
                var format = (CompressionFormatComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                await Task.Run(() => CompressFiles(selectedFiles, outputPath, format));

                MessageBox.Show($"Archive created successfully:\n{outputPath}",
                    "Compression Complete", MessageBoxButton.OK, MessageBoxImage.Information);

                StatusTextBlock.Text = "Compression completed successfully!";
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating archive:\n{ex.Message}", "Compression Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                StatusTextBlock.Text = "Compression failed.";
            }
            finally
            {
                CompressButton.IsEnabled = true;
                ProgressBar.Visibility = Visibility.Collapsed;
            }
        }

        private void CompressFiles(List<string> files, string archivePath, string? format)
        {
            var writerOptions = new WriterOptions(CompressionType.Deflate)
            {
                LeaveStreamOpen = false
            };

            using var stream = File.Create(archivePath);
            
            switch (format)
            {
                case "ZIP":
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Zip, writerOptions))
                    {
                        AddFilesToArchive(writer, files);
                    }
                    break;
                case "TAR":
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, new WriterOptions(CompressionType.None)))
                    {
                        AddFilesToArchive(writer, files);
                    }
                    break;
                case "TAR.GZ":
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, new WriterOptions(CompressionType.GZip)))
                    {
                        AddFilesToArchive(writer, files);
                    }
                    break;
                case "TAR.BZ2":
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Tar, new WriterOptions(CompressionType.BZip2)))
                    {
                        AddFilesToArchive(writer, files);
                    }
                    break;
                default:
                    using (var writer = WriterFactory.Open(stream, ArchiveType.Zip, writerOptions))
                    {
                        AddFilesToArchive(writer, files);
                    }
                    break;
            }
        }

        private void AddFilesToArchive(IWriter writer, List<string> files)
        {
            foreach (var file in files.Distinct())
            {
                if (File.Exists(file))
                {
                    Dispatcher.Invoke(() =>
                    {
                        StatusTextBlock.Text = $"Adding: {Path.GetFileName(file)}";
                    });

                    writer.Write(Path.GetFileName(file), file);
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
