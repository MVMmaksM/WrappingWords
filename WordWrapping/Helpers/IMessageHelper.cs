using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWrapping.Helpers
{
    public interface IMessageHelper
    {
        void Error(string text);
        void Warning(string text);
        void Info(string text);
    }
}
