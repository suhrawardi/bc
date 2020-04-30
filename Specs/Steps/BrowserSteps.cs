using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using Xunit.Abstractions;
using System;
using System.IO;
using TechTalk.SpecFlow;


namespace bc.Specs.Steps
{
    [Binding]
    public class BrowserSteps : BaseSteps, IDisposable
    {
        private string username;
        private string password;
        private string host;
        private string env;

        private ChromeDriver chromeDriver;

        public BrowserSteps(FeatureContext featureContext,
                            ScenarioContext scenarioContext,
                            ITestOutputHelper testOutputHelper) :
                            base(featureContext, scenarioContext, testOutputHelper)
        {
            this.chromeDriver = getChromeDriver();

            this.username = this.GetEnv("NAV_USER");
            this.password = this.GetEnv("NAV_PASSWORD");
            this.host = this.GetEnv("HOST");
            this.env = this.GetEnv("ENVIRONMENT");
        }

        public ChromeDriver getChromeDriver()
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

        [BeforeScenario(Order = 0)]
        public void DoItBeforeHand()
        {
            // nothing
        }

        [When(@"I visit the web client")]
        public void WhenIVisitTheWebClient()
        {
            get("/");
        }

        [When(@"I visit '(.*)'")]
        public void WhenIVisitThePage(string path)
        {
            get(path);
        }

        [When(@"I log in")]
        public void WhenIVisitThePage()
        {
            makeScreenshot();
            fillIn("User name:", this.username);
            makeScreenshot();
            fillIn("Password:", this.password);
            makeScreenshot();
            click("Sign In");
            makeScreenshot();

            // context.browser.wait_until_page_contains('Dynamics 365 Business Central')
            // time.sleep(3.5)
            // context.browser.switch_to_iframe()
            // context.browser.wait_until_page_contains(os.getenv('COMPANY'))
            // logger.info('On page %s', context.browser.current_url)
        }

        [Then(@"I see (.*)")]
        public void ThenISee(string text)
        {
//          _scenarioContext.Pending();
        }

        public void makeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot) chromeDriver).GetScreenshot();
            var datetime = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            var path = "C:\\Users\\Jarra\\Workspace\\bc\\report\\screenshots\\"; 
            screenshot.SaveAsFile(path + datetime + ".png", ScreenshotImageFormat.Png);
        }

        public void fillIn(string label, string value)
        {
            var xpath = "//label[contains(.,'" + label + "')]/following::input[1]";
            IWebElement element = this.chromeDriver.FindElement(By.XPath(xpath));
            element.SendKeys(value);
        }

        public void click(string text)
        {
            var xpath = "//button[contains(.,'" + text + "')]";
            IWebElement button = this.chromeDriver.FindElement(By.XPath(xpath));
            button.Click();
        }

        public void get(string path)
        {
            string url = "https://" + this.host + "/" + this.env + path;
            this.chromeDriver.Navigate().GoToUrl(url);
        }

        public void Dispose()  
        {  
            if (this.chromeDriver != null)  
            {  
                this.chromeDriver.Dispose();  
                this.chromeDriver = null;  
            }  
        }  
    }
}
