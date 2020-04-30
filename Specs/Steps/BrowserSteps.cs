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

        private bc.Specs.Utilities.Browser.Chromium browser;

        public BrowserSteps(FeatureContext featureContext,
                            ScenarioContext scenarioContext,
                            ITestOutputHelper testOutputHelper) :
                            base(featureContext, scenarioContext, testOutputHelper)
        {
            this.browser = new bc.Specs.Utilities.Browser.Chromium();

            this.username = this.GetEnv("NAV_USER");
            this.password = this.GetEnv("NAV_PASSWORD");
            this.host = this.GetEnv("HOST");
            this.env = this.GetEnv("ENVIRONMENT");
        }

        [BeforeScenario(Order = 0)]
        public void DoItBeforeHand()
        {
            // nothing
        }

        [When(@"I visit the web client")]
        public void WhenIVisitTheWebClient()
        {
            string url = "https://" + this.host + "/" + this.env + "/";
            this.browser.Get(url);
        }

        [When(@"I visit '(.*)'")]
        public void WhenIVisitThePage(string path)
        {
            string url = "https://" + this.host + "/" + this.env + path;
            this.browser.Get(url);
        }

        [When(@"I log in")]
        public void WhenIVisitThePage()
        {
            this.browser.MakeScreenshot();
            this.browser.FillIn("User name:", this.username);
            this.browser.MakeScreenshot();
            this.browser.FillIn("Password:", this.password);
            this.browser.MakeScreenshot();
            this.browser.Click("Sign In");
            this.browser.MakeScreenshot();

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

        public void Dispose()  
        {  
            this.browser.Dispose();
        }  
    }
}
