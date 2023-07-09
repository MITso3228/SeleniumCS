/// This project was created in order to complete Test Task
/// Author: Kostiantyn Vasyliev
/// Email: k.vasiliev32@gmail.com

using SeleniumCS.Helpers;

namespace SeleniumCS.Tests
{
    [SetUpFixture]
    public abstract class GlobalSetup
    {
        private LogFilesHelper logsHelper = new LogFilesHelper();
        public Logging logger = new();

        [SetUp]
        public void SetupBeforeEveryTestClass()
        {
            logsHelper.clearLogs(NUnit.Framework.TestContext.CurrentContext.Test.ClassName.Split(".").Last());
        }

        [TearDown]
        public void SetupAfterEveryTestClass()
        {
            logsHelper.createLogs(logger.getLogs(), NUnit.Framework.TestContext.CurrentContext.Test.ClassName.Split(".").Last());
        }
    }
}
