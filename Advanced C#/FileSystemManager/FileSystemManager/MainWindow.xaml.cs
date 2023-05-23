using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FileSystemManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileSystemVisitor fileSystemVisitor;
        private int directoryCount;
        private int fileCount;
        private bool shouldAbort = false;

        public MainWindow()
        {
            InitializeComponent();
            fileSystemVisitor = new FileSystemVisitor(textBox_folderPath.Text);
            fileSystemVisitor.DirectoryFound += FileSystemVisitor_DirectoryFound;
            fileSystemVisitor.FileFound += FileSystemVisitor_FileFound;
        }

        public delegate void FolderFoundEventHandler(int count);

        private void button_selectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox_folderPath.Text = dialog.FileName;
            }
        }

        private void button_showList_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_folderPath.Text))
            {
                MessageBox.Show(ResourceStrings.ResourceManager.GetString("selectFolderInfo"));
            }
            else
            {
                directoryCount = 0;
                fileCount = 0;
                var filter = GetFilter();
                fileSystemVisitor.filter = filter;
                fileSystemVisitor.folderPath = textBox_folderPath.Text;
                fileSystemVisitor.Start += FileSystemVisitor_Start;
                List<FileSystemItem> fileSystemItems = new List<FileSystemItem>();
                foreach (string item in fileSystemVisitor)
                {
                    bool isFolder = Directory.Exists(item);
                    string itemName = isFolder ? Path.GetFileName(item) : item;

                    fileSystemItems.Add(new FileSystemItem { Name = itemName, IsFolder = isFolder });
                }

                dataGrid_filesList.ItemsSource = fileSystemItems;
            }

            shouldAbort = false;
            fileSystemVisitor.Finish += FileSystemVisitor_Finish;
        }

        private Func<string, bool> GetFilter()
        {
            Func<string, bool> filter = null;

            ComboBoxItem selectedItem = (ComboBoxItem)comboBox_filters.SelectedItem;
            string selectedFilter = selectedItem?.Content.ToString();

            switch (selectedFilter)
            {
                case "Show folders":
                    filter = path => Directory.Exists(path);
                    break;
                case "Show files":
                    filter = path => File.Exists(path);
                    break;
                case "Show .dll files":
                    filter = path => File.Exists(path) && Path.GetExtension(path) == ".dll";
                    break;
            }

            return filter;
        }

        private void comboBox_filters_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            button_showList_Click(sender, e);
        }

        private void FileSystemVisitor_Finish(object sender, EventArgs e)
        {
            label_statusValue.Content = ResourceStrings.ResourceManager.GetString("onFinishInfo");
            button_abort.Visibility = Visibility.Hidden;
        }

        private void FileSystemVisitor_Start(object sender, EventArgs e)
        {
            label_statusValue.Content = ResourceStrings.ResourceManager.GetString("onStartInfo");
            button_abort.Visibility = Visibility.Visible;
        }

        private void FileSystemVisitor_DirectoryFound(object sender, FileSystemEventArgs e)
        {
            e.DirectoryCount = directoryCount++;
            label_directoriesCount.Content = directoryCount;
        }

        private void FileSystemVisitor_FileFound(object sender, FileSystemEventArgs e)
        {
            e.FileCount = fileCount++;
            label_filesCount.Content = fileCount;
        }

        private void button_abort_Click(object sender, RoutedEventArgs e)
        {
            shouldAbort = true;
        }
    }
}
