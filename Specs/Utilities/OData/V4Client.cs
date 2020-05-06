namespace bc.Specs.Utilities.OData {
    using Simple.OData.Client;
    using NLog;
    using System;
    using System.Net;
    using System.Collections.Generic;
    
    public partial class V4Client {
        private string Url;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public ODataClient Client { get; }

        public V4Client(string host, string env, string company, string username, string password) {
            this.Url = "https://" + host + "/" + env + "/ODataV4/";
            logger.Debug(this.Url);

            NetworkCredential netCredential = new NetworkCredential(username, password);
            ICredentials credentials = netCredential.GetCredential(new Uri(this.Url), "Basic");
            this.Client = new ODataClient(new ODataClientSettings(this.Url, credentials)
            {
                IgnoreResourceNotFoundException = true,
                OnTrace = (x, y) => logger.Debug(string.Format(x, y)),
            });
        }
    }
}
