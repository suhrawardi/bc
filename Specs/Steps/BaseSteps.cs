using ObjectDumper;
using Newtonsoft.Json;
using NLog;
using System;
using System.Net;
using TechTalk.SpecFlow;


namespace bc.Specs.Steps
{
    [Binding]
    public class BaseSteps
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        protected FeatureContext _featureContext;
        protected ScenarioContext _scenarioContext;
        protected String _projectDir;

        public BaseSteps(FeatureContext featureContext,
                         ScenarioContext scenarioContext) {
            this._featureContext = featureContext;
            this._scenarioContext = scenarioContext;
            this._projectDir =  System.IO.Path.GetFullPath(@"..\..\..\");

            DotNetEnv.Env.Load(this._projectDir + ".env");
        }

        public String GetEnv(String key)
        {
            return DotNetEnv.Env.GetString(key);
        }

        public void Info(String value)
        {
            logger.Info(value);
        }

        public void Debug(String value)
        {
            logger.Debug(value);
        }

        public void Debug(Array value)
        {
            string json = JsonConvert.SerializeObject(value, Formatting.Indented);
            Console.WriteLine(json);
            logger.Debug(json);
        }

        public void Debug(Object value)
        {
            var writer = new System.IO.StringWriter();
            Dumper.Dump(value, "Object Dumper", writer);
            logger.Debug(writer);
        }
    }
}