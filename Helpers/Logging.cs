/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

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
