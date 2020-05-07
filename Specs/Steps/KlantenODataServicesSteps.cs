using Simple.OData.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

using bc.Specs.Utilities.OData;


namespace bc.Specs.Steps
{
    [Binding]
    public class KlantenODataServiceSteps : ODataSteps
    {
        private ODataClient odataClient;
        private IEnumerable<IDictionary<String,Object>> result;

        public KlantenODataServiceSteps(FeatureContext featureContext,
                                       ScenarioContext scenarioContext) :
                                       base(featureContext, scenarioContext) { }

        [Given(@"a klanten ODATA endpoint")]
        public void GivenAContractDetailsODataEndpoint()
        {
            this.odataClient = new V4Client(this.config).Client;
        }

        [When(@"I fetch the first (.*) records from the ODATA endpoint")]
        public void WhenIFetchTheFirstRecordsFromTheODataEndpointFilteredBy(int nrOfRecords)
        {
            this.result = Task.Run(async () =>
                await this.odataClient
                    .FindEntriesAsync("Company('" + this.config.company + "')/Klanten?$top=3")
            ).Result;
        }

        [Then(@"I should have (.*) records")]
        public void ThenIReceivedRecords(int nrOfRecords)
        {
            Debug(this.result);
            Info(this.result.ToList().Count.ToString());
            Assert.Equal(this.result.ToList().Count, nrOfRecords);
        }
    }
}