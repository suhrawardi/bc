using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;


namespace bc.Specs.Utilities.Browser
{
    public class Chromium : IDisposable
    {
        private ChromeDriver _chromeDriver;

        public Chromium()
        {
            this._chromeDriver = getChromeDriver();
        }

        private ChromeDriver getChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--allow-running-insecure-content");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--headless");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--verbose");
            options.AddArgument("--window-size=1920,1080");
            return new ChromeDriver(options);
        }

        public void MakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot) this._chromeDriver).GetScreenshot();
            var datetime = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            var projectDir =  System.IO.Path.GetFullPath(@"..\..\..\");
            var path = projectDir + "\\report\\screenshots\\"; 
            screenshot.SaveAsFile(path + datetime + ".png", ScreenshotImageFormat.Png);
        }

        public void FillIn(string label, string value)
        {
            var xpath = "//label[contains(.,'" + label + "')]/following::input[1]";
            IWebElement element = this._chromeDriver.FindElement(By.XPath(xpath));
            element.SendKeys(value);
        }

        public void Click(string text)
        {
            var xpath = "//button[contains(.,'" + text + "')]";
            IWebElement button = this._chromeDriver.FindElement(By.XPath(xpath));
            button.Click();
        }

        public void Get(string url)
        {
            this._chromeDriver.Navigate().GoToUrl(url);
        }

        public void Dispose()  
        {  
            if (this._chromeDriver != null)  
            {  
                this._chromeDriver.Dispose();  
                this._chromeDriver = null;  
            }  
        }  
    }
}