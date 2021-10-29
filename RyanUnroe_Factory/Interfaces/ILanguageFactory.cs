using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Interfaces
{
    public interface ILanguageFactory
    {
        //create button element
        //create text block element
        Element CreateButton(string value, int height, int width, int top, int left);
        Element CreateTextBlock(string value, int height, int width, int top, int left);
    
    }
}
