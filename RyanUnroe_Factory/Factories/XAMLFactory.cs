using RyanUnroe_Factory.Elements;
using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Factories
{
    public class XAMLFactory : ILanguageFactory
    {
        public Element CreateButton(string value, string height, string width, string top, string left)
        {
            return new XAMLButtonElement(value, height, width, top, left);
        }

        public Element CreateTextBlock(string value, string height, string width, string top, string left)
        {
            return new XAMLTextBlockElement(value, height, width, top, left);
        }
    }
}
