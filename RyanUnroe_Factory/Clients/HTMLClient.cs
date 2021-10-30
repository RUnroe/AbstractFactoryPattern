using RyanUnroe_Factory.Factories;
using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Clients
{
    public class HTMLClient : IClient
    {
        //Create and store factories
        public ILanguageFactory factory = new HTMLFactory();

        private List<Element> GetElements(List<Dictionary<string, string>> elements)
        {
            List<Element> temp = new List<Element>();
            foreach (Dictionary<string, string> dict in elements)
            {
                switch (dict["type"])
                {
                    case "button":
                        temp.Add(factory.CreateButton(dict["value"], dict["height"], dict["width"], dict["top"], dict["left"]));
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

            string fileContent = "<!DOCTYPE html>\n" +
                "<html lang='en'>\n" +
                "<head>\n" +
                "<meta charset='UTF-8'>\n" +
                "<meta http-equiv='X-UA-Compatible' content='IE=edge'>\n" +
                "<meta name = 'viewport' content='width=device-width, initial-scale=1.0'>\n" +
                "<title> Sample HTML </title>\n" +
                "</head>\n" +
                "<body>\n";
            foreach (Element el in boys)
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
