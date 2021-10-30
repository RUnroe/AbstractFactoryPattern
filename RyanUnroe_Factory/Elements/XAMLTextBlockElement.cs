﻿using RyanUnroe_Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Elements
{
    public class XAMLTextBlockElement : Element
    {
        public XAMLTextBlockElement(string value, string height, string width, string top, string left)
       : base( value, height, width, top, left) { }
        public override string getCode()
        {
            return $"<TextBlock Width='{Width}' Height='{Height}' Margin='{Left},{Top}, 0, 0'>{Value}</TextBlock>";
               
        }
    }
}
