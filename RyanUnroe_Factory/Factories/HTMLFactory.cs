using RyanUnroe_Factory.Elements;
using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Factories
{
    public class HTMLFactory : ILanguageFactory
    {
        public Element CreateButton(string value, int height, int width, int top, int left)
        {
            return new HTMLButtonElement(value, height, width, top, left);
        }

        public Element CreateTextBlock(string value, int height, int width, int top, int left)
        {
            return new HTMLTextBlockElement(value, height, width, top, left);
        }
    }
}