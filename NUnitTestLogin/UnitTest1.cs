using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace NUnitTestLogin
{
    [TestFixture]
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        [Test]
        public void Test1()
        {
            //open page
            driver.Url = "http://booksrest.azurewebsites.net/tabs";

            Console.WriteLine("Opened Page " + driver.Url);

            //insert pass
            driver.FindElement(By.Id("user")).SendKeys("test");
            driver.FindElement(By.Id("password")).SendKeys("Test123");
            Console.WriteLine("Entered username and pass");

            //click
            driver.FindElement(By.TagName("button")).Click();
            Console.WriteLine("Button clicked");

            //checks alert
            IAlert alert = driver.SwitchTo().Alert();
            Console.WriteLine("Switched to alert");
            Assert.That(alert.Text, Does.Match("Wrong username or password"));
            Assert.AreEqual(alert.Text, "Wrong username or password");

            //Assert.AreSame("http://booksrest.azurewebsites.net/home-page/", "http://booksrest.azurewebsites.net/home-page/");
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}