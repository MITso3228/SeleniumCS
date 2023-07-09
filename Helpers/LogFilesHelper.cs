using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCS.Helpers
{
    public class LogFilesHelper
    {
        private string targetFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Logs";
        private string targetFile = "testLogs.txt";
        public void clearLogs(string fileName)
        {
            var files = Directory.GetFiles(targetFolder);
            foreach (var file in files)
            {
                if (file.Contains(fileName))
                {
                    File.Delete(file);
                }
            }
        }

        public void createLogs(string logs, string name)
        {
            File.WriteAllText(targetFolder + "/" + name + ".txt", logs);
        }
    }
}
