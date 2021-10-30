using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RyanUnroe_Factory.Interfaces
{
    public interface IClient 
    { 
        void Export(List<Dictionary<string, string>> elements);
    }
}
