﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using SeleniumCS.Pages;
using SeleniumCS.Helpers;

namespace SeleniumCS.Tests
{
    public abstract class Setup : GlobalSetup
    {
        public IWebDriver driver;
        private LogFilesHelper logsHelper = new LogFilesHelper();

        [SetUp]
        public void SetupBeforeEverySingleTest()
        {
            var path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

            logger.Custom($"\nTEST NAME: {NUnit.Framework.TestContext.CurrentContext.Test.Name}");

            ChromeOptions options = new();
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(path + @"\drivers\chromedriver.exe", options);

            logger.Info("Initilized Chrome WebDriver");

            HomePage rozetkaHomePage = new(driver, logger);
            rozetkaHomePage.GoToPage();
        }

        [TearDown]
        public void CleanUpAfterEverySingleTest()
        {
            driver.Quit();
            logger.Info("Closed Chrome WebDriver");
        }
    }
}