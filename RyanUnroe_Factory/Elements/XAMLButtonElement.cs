using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Elements
{
    public class XAMLButtonElement : Element
    {
        public XAMLButtonElement(string value, int height, int width, int top, int left)
        : base(value, height, width, top, left) {}
        public override string getCode()
        {
            return $"<Button Content='{Value}' Width='{Width}' Height='{Height}' Margin='{Left},{Top}, 0, 0'/>";
        }
    }
}
