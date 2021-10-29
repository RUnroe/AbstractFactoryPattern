using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Interfaces
{
    public abstract class Element
    {
        public Element(string value, int height, int width, int top, int left)
        {
            this.Value = value;
            this.Height = height;
            this.Width = width;
            this.Top = top;
            this.Left = left;
        }

        
        public string Value { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Top { get; set; }
        public int Left { get; set; }

        public abstract string getCode();
    }
}
