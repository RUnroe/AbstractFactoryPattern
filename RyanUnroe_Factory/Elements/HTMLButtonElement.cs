using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Elements
{
    class HTMLButtonElement : Element
    {
        public HTMLButtonElement(string value, int height, int width, int top, int left)
        : base(value, height, width, top, left) { }
        public override string getCode()
        {
            return $"<button style='position:absolute;height:{Height}px;width:{Width}px;top:{Top}px;left:{Left}px;'>{Value}</button>";
        }
    }
}