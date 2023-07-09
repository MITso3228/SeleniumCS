using SeleniumCS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
