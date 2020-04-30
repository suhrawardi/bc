using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;
using Xunit.Abstractions;

using bc.Specs.Utilities.Soap;
using bc.Specs.Utilities.Soap.Generated;


namespace bc.Specs.Steps
{
    [Binding]
    public class KlantenSoapServiceSteps : BaseSteps
    {
        private string username;
        private string password;
        private string host;
        private string env;
        private string company;

        private KlantenServiceClient soapClient;
        private Klanten[] result;

        public KlantenSoapServiceSteps(FeatureContext featureContext,
                                       ScenarioContext scenarioContext,
                                       ITestOutputHelper testOutputHelper) :
                                       base(featureContext, scenarioContext, testOutputHelper)
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
            this.Debug(this.username);
            this.Debug(this.password);
            this.Debug(this.env);
            this.Debug(this.host);
        }

        [Given(@"a klanten SOAP endpoint")]
        public void GivenAContractDetailsSoapEndpoint()
        {
            this.soapClient = new KlantenServiceClient(this.host,
                                                       this.env,
                                                       this.company,
                                                       this.username,
                                                       this.password);
        }

        [When(@"I fetch the first (.*) records from the SOAP endpoint")]
        public void WhenIFetchTheFirstRecordsFromTheSoapEndpointFilteredBy(int nrOfRecords)
        {
            this.result = this.soapClient.ReadMultiple(null, null, 3);
        }

        [Then(@"I received (.*) records")]
        public void ThenIReceivedRecords(int nrOfRecords)
        {
            this._testOutputHelper.WriteLine(this.result.Length.ToString());
            Assert.Equal(this.result.Length, nrOfRecords);
        }
    }
}