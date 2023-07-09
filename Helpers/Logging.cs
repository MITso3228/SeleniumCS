using OpenQA.Selenium.DevTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCS.Helpers
{

    public class Logging
    {
        public string logs;
        public Logging() { }
        public void Info(String text)
        {
            Console.WriteLine($"INFO — {text}");
            logs += $"INFO — {text}\n";
        }
        public void Log(String text)
        {
            Console.WriteLine($"LOG — {text}");
            logs += $"LOG — {text}\n";
        }
        public void Error(String text)
        {
            Console.WriteLine($"ERROR — {text}");
            logs += $"ERROR — {text}\n";
        }
        public void Custom(String text)
        {
            Console.WriteLine(text);
            logs += $"{text}\n";
        }

        public string getLogs()
        {
            return logs;
        }
    }
}
