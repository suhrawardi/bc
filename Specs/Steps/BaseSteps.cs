using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit.Abstractions;


namespace bc.Specs.Steps
{
    [Binding]
    public class BaseSteps
    {
        protected FeatureContext _featureContext;
        protected ScenarioContext _scenarioContext;
        protected ITestOutputHelper _testOutputHelper;
        protected String _projectDir;

        public BaseSteps(FeatureContext featureContext,
                         ScenarioContext scenarioContext,
                         ITestOutputHelper testOutputHelper) {
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
            this._testOutputHelper = testOutputHelper;
            this._projectDir =  System.IO.Path.GetFullPath(@"..\..\..\");

            DotNetEnv.Env.Load(this._projectDir + ".env");
        }

        public String GetEnv(String key)
        {
            return DotNetEnv.Env.GetString(key);
        }

        public void Debug(String value)
        {
            this._testOutputHelper.WriteLine(value);
        }
    }
}