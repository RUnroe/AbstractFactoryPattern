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

        private void ExportXAML_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExportHTML_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}