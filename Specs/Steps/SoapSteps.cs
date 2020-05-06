using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

using bc.Specs.Utilities.Soap;
using bc.Specs.Utilities.Soap.Generated;


namespace bc.Specs.Steps
{
    [Binding]
    public class SoapSteps : BaseSteps
    {
        protected string username;
        protected string password;
        protected string host;
        protected string env;
        protected string company;

        public SoapSteps(FeatureContext featureContext,
                         ScenarioContext scenarioContext) :
                         base(featureContext, scenarioContext)
        {
            this.username = this.GetEnv("NAV_USER");
            this.password = this.GetEnv("NAV_PASSWORD");
            this.host = this.GetEnv("SOAP_HOST");
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