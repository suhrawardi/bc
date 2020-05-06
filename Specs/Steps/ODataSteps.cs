using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;


namespace bc.Specs.Steps
{
    [Binding]
    public class ODataSteps : BaseSteps
    {
        protected string username;
        protected string password;
        protected string host;
        protected string env;
        protected string company;

        public ODataSteps(FeatureContext featureContext,
                         ScenarioContext scenarioContext) :
                         base(featureContext, scenarioContext)
        {
            this.username = this.GetEnv("NAV_USER");
            this.password = this.GetEnv("NAV_PASSWORD");
            this.host = this.GetEnv("ODATA_HOST");
            this.env = this.GetEnv("ENVIRONMENT");
            this.company = this.GetEnv("COMPANY");
        }

        [BeforeScenario(Order = 0)]
        public void DoItBeforeHand()
        {
            this.Debug(this.host);
        }
    }
}