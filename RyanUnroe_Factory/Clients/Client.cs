using RyanUnroe_Factory.Factories;
using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Clients
{
    public class Client
    {
        //List of elements (buttons and textblocks)
        List<Element> HTMLelements = new List<Element>();
        List<Element> XAMLelements = new List<Element>();
        //Create and store factories
        public ILanguageFactory HTMLfactory = new HTMLFactory();
        public ILanguageFactory XAMLfactory = new XAMLFactory();

        public void AddButtonToList(string value, int height, int width, int top, int left)
        {
            HTMLelements.Add(HTMLfactory.CreateButton(value, height, width, top, left));
            XAMLelements.Add(XAMLfactory.CreateButton(value, height, width, top, left));
        }
        public void AddTextBlockToList(string value, int height, int width, int top, int left)
        {
            HTMLelements.Add(HTMLfactory.CreateTextBlock(value, height, width, top, left));
            XAMLelements.Add(XAMLfactory.CreateTextBlock(value, height, width, top, left));
        }
        public void RemoveLastElementFromList()
        {
            HTMLelements.Remove(HTMLelements.Last());
            XAMLelements.Remove(XAMLelements.Last());
        }
        public void ExportXAML()
        {

        }
        public void ExportHTML()
        {

        }
    }
}
