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
        Element CreateButton(string value, string height, string width, string top, string left);
        Element CreateTextBlock(string value, string height, string width, string top, string left);

    
    }
}
