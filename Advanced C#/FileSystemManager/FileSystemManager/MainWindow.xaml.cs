using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly string selectFolderInfo = "Select folder path first";
        private FileSystemVisitor fileSystemVisitor;
        private List<string> filteredItems;

        public MainWindow()
        {
            InitializeComponent();
        }

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
                MessageBox.Show(selectFolderInfo);
            }
            else
            {
                var filter = GetFilter();
                FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(textBox_folderPath.Text, filter);
                List<FileSystemItem> fileSystemItems = new List<FileSystemItem>();
                foreach (string item in fileSystemVisitor)
                {
                    bool isFolder = Directory.Exists(item);
                    string itemName = isFolder ? Path.GetFileName(item) : item;

                    fileSystemItems.Add(new FileSystemItem { Name = itemName, IsFolder = isFolder });
                }

                dataGrid_filesList.ItemsSource = fileSystemItems;
            }
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
    }
}
