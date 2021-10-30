using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Interfaces
{
    public abstract class Element
    {
        public Element(string value, string height, string width, string top, string left)
        {
            this.Value = value;
            this.Height = height;
            this.Width = width;
            this.Top = top;
            this.Left = left;
        }

        
        public string Value { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string Top { get; set; }
        public string Left { get; set; }

        public abstract string getCode();
    }
}
