using System.Windows;
using System.Windows.Controls;

namespace ZeeArchiver
{
    /// <summary>
    /// Main Window for ZeeArchiver
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = "ZeeArchiver - Archive Manager";
        }

        private void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            var extractWindow = new ExtractionWindow();
            extractWindow.ShowDialog();
        }

        private void CompressButton_Click(object sender, RoutedEventArgs e)
        {
            var compressWindow = new CompressionWindow();
            compressWindow.ShowDialog();
        }

        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "ZeeArchiver - Windows Edition\n\n" +
                "An efficient and simple to use Archiver and decompressor.\n" +
                "Supports multiple archive formats including 7z, ZIP, TAR, GZIP, and more.\n\n" +
                "Copyright © 2025 Mahmoud Galal\n" +
                "Support: mahmoudgalal57@yahoo.com",
                "About ZeeArchiver",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}
