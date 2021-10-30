using RyanUnroe_Factory.Factories;
using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Clients
{
    public class XAMLClient : IClient
    {
       
        //Create and store factories
        public ILanguageFactory factory = new XAMLFactory();

        private List<Element> GetElements(List<Dictionary<string, string>> elements)
        {
            List<Element> temp = new List<Element>();
            foreach(Dictionary<string, string> dict in elements) {
                switch (dict["type"]) 
                {
                    case "button":
                        temp.Add(factory.CreateButton(dict["value"], dict["height"], dict["width"], dict["top"], dict["left"] ));
                        break;
                    case "text":
                        temp.Add(factory.CreateTextBlock(dict["value"], dict["height"], dict["width"], dict["top"], dict["left"]));
                        break;

                }

            } 
            return temp;

        }
        public async void Export(List<Dictionary<string, string>> elements)
        {
            List<Element> boys = GetElements(elements);


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
            foreach (Element el in boys)
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
    }
}
