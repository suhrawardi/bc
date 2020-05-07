using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

using bc.Specs.Utilities.Soap;
using bc.Specs.Utilities.Soap.Generated;


namespace bc.Specs.Steps
{
    [Binding]
    public class KlantenSoapServiceSteps : SoapSteps
    {
        private KlantenServiceClient soapClient;
        private Klanten[] result;

        public KlantenSoapServiceSteps(FeatureContext featureContext,
                                       ScenarioContext scenarioContext) :
                                       base(featureContext, scenarioContext) { }

        [Given(@"a klanten SOAP endpoint")]
        public void GivenAContractDetailsSoapEndpoint()
        {
            this.soapClient = new KlantenServiceClient(this.config);
        }

        [When(@"I fetch the first (.*) records from the SOAP endpoint")]
        public void WhenIFetchTheFirstRecordsFromTheSoapEndpointFilteredBy(int nrOfRecords)
        {
            this.result = this.soapClient.ReadMultiple(null, null, 3);
        }

        [Then(@"I received (.*) records")]
        public void ThenIReceivedRecords(int nrOfRecords)
        {
            Info(this.result.Length.ToString());
            Debug(this.result);
            Assert.Equal(this.result.Length, nrOfRecords);
        }
    }
}