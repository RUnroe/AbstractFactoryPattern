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
        IClient HTMLclient = new HTMLClient();
        IClient XAMLclient = new XAMLClient();

        List<Dictionary<string, string>> elements = new List<Dictionary<string, string>>();
        
        public MainPage()
        {
            this.InitializeComponent();
        }

        

        //Buttons call methods in client
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, string> button = new Dictionary<string, string>();
            button.Add("type", "button");
            button.Add("value", value.Text);
            button.Add("height", height.Text);
            button.Add("width", width.Text);
            button.Add("top", top.Text);
            button.Add("left", left.Text);
            elements.Add(button);
            //Draw on screen
            TextBlock textBlock = new TextBlock();
            textBlock.Name = $"{idCount++}";
            textBlock.Text = ($"Button (value:{value.Text}, height:{height.Text}, width:{width.Text}, top:{top.Text}, left:{left.Text})");
            elementOutput.Children.Add(textBlock);
        }

        private void CreateTextBlock_Click(object sender, RoutedEventArgs e)
        {

            Dictionary<string, string> text = new Dictionary<string, string>();
            text.Add("type", "text");
            text.Add("value", value.Text);
            text.Add("height", height.Text);
            text.Add("width", width.Text);
            text.Add("top", top.Text);
            text.Add("left", left.Text);
            elements.Add(text);
            //Draw on screen
            TextBlock textBlock = new TextBlock();
            textBlock.Name = $"{idCount++}";
            textBlock.Text = ($"Text Block (value:{value.Text}, height:{height.Text}, width:{width.Text}, top:{top.Text}, left:{left.Text})");
            elementOutput.Children.Add(textBlock);
        }

        private void RemoveLastElement_Click(object sender, RoutedEventArgs e)
        {
            //Call client method
            if (elements.Count != 0)
            {
                elements.Remove(elements.Last());
                //Draw on screen
                elementOutput.Children.Remove(elementOutput.Children.Last());
            }
        }

        private void ExportXAML_Click(object sender, RoutedEventArgs e)
        {
            XAMLclient.Export(elements);
        }
        private void ExportHTML_Click(object sender, RoutedEventArgs e)
        {
            HTMLclient.Export(elements);
        }
    }
}