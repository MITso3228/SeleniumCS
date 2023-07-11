/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

namespace SeleniumCS.Helpers
{
    public class LogFilesHelper
    {
        private string targetFolder = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/Logs";
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
