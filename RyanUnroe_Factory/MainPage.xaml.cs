using RyanUnroe_Factory.Clients;
using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RyanUnroe_Factory
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int idCount = 0;
        Client client = new Client();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private int parseInput(string input)
        {
            if(Int32.TryParse(input, out int number))
            {
                return number;
            }
            return 0;
        }

        //Buttons call methods in client
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //Call client method
            client.AddButtonToList(value.Text, parseInput(height.Text), parseInput(width.Text), parseInput(top.Text), parseInput(left.Text));
            //Draw on screen
            TextBlock textBlock = new TextBlock();
            textBlock.Name = $"{idCount++}";
            textBlock.Text = ($"Button (value:{value.Text}, height:{height.Text}, width:{width.Text}, top:{top.Text}, left:{left.Text})");
            elementOutput.Children.Add(textBlock);
        }

        private void CreateTextBlock_Click(object sender, RoutedEventArgs e)
        {
            //Call client method
            client.AddTextBlockToList(value.Text, parseInput(height.Text), parseInput(width.Text), parseInput(top.Text), parseInput(left.Text));
            //Draw on screen
            TextBlock textBlock = new TextBlock();
            textBlock.Name = $"{idCount++}";
            textBlock.Text = ($"Text Block (value:{value.Text}, height:{height.Text}, width:{width.Text}, top:{top.Text}, left:{left.Text})");
            elementOutput.Children.Add(textBlock);
        }

        private void RemoveLastElement_Click(object sender, RoutedEventArgs e)
        {
            //Call client method
            client.RemoveLastElementFromList();
            //Draw on screen
            elementOutput.Children.Remove(elementOutput.Children.Last());
        }

        private async void ExportXAML_Click(object sender, RoutedEventArgs e)
        {
            string fileContent = $"<Page\n" +
                "x: Class = 'Generated.MainPage'\n" +
                "xmlns = 'http://schemas.microsoft.com/winfx/2006/xaml/presentation'\n" +
                "xmlns: x = 'http://schemas.microsoft.com/winfx/2006/xaml'\n" +
                "xmlns: local = 'using:Generated'\n" +
                "xmlns: d = 'http://schemas.microsoft.com/expression/blend/2008'\n" +
                "xmlns: mc = 'http://schemas.openxmlformats.org/markup-compatibility/2006'\n" +
                "mc: Ignorable = 'd'\n" +
                "Background = '{ThemeResource ApplicationPageBackgroundThemeBrush}' >\n" + 
                "<Grid>";
            foreach (Element el in client.XAMLelements)
            {
                fileContent += $"{ el.getCode()}\n";
            }

            fileContent += "</Grid>\n" +
                "</Page> ";

            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.xaml",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, fileContent);
        }

        private async void ExportHTML_Click(object sender, RoutedEventArgs e)
        {
            string fileContent = "<!DOCTYPE html>\n" +
                "<html lang='en'>\n" +
                "<head>\n" +
                "<meta charset='UTF-8'>\n" +
                "<meta http-equiv='X-UA-Compatible' content='IE=edge'>\n" +
                "<meta name = 'viewport' content='width=device-width, initial-scale=1.0'>\n" +
                "<title> Sample HTML </title>\n" +
                "</head>\n" +
                "<body>\n";
            foreach (Element el in client.HTMLelements)
            {
                fileContent += $"{ el.getCode()}\n";
            }

            fileContent += "</body>\n" +
                "</html> ";

            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile =
                await storageFolder.CreateFileAsync("sample.html",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, fileContent);
        }
    }
}