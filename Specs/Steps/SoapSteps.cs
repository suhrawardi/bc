using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

using bc.Specs.Utilities.Soap;


namespace bc.Specs.Steps
{
    [Binding]
    public class SoapSteps : BaseSteps
    {
        protected SoapConfig config = new SoapConfig();

        public SoapSteps(FeatureContext featureContext,
                         ScenarioContext scenarioContext) :
                         base(featureContext, scenarioContext)
        {
            this.config.host = this.GetEnv("SOAP_HOST");
            this.config.env = this.GetEnv("ENVIRONMENT");
            this.config.company = this.GetEnv("COMPANY");
            this.config.username = this.GetEnv("NAV_USER");
            this.config.password = this.GetEnv("NAV_PASSWORD");
        }
    }
}