using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

using bc.Specs.Utilities.OData;


namespace bc.Specs.Steps
{
    [Binding]
    public class ODataSteps : BaseSteps
    {
        protected ODataConfig config = new ODataConfig();

        public ODataSteps(FeatureContext featureContext,
                          ScenarioContext scenarioContext) :
                          base(featureContext, scenarioContext)
        {
            this.config.host = this.GetEnv("ODATA_HOST");
            this.config.env = this.GetEnv("ENVIRONMENT");
            this.config.company = this.GetEnv("COMPANY");
            this.config.username = this.GetEnv("NAV_USER");
            this.config.password = this.GetEnv("NAV_PASSWORD");
        }
    }
}