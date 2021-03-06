namespace bc.Specs.Utilities.Soap {
    using System;
    using System.Net;
    using System.Text;
    using System.Web.Services;
    
    public partial class BaseClient : System.Web.Services.Protocols.SoapHttpClientProtocol {
        public BaseClient() : base() {}

        protected void AddAuthentication(string username, string password) {
            NetworkCredential netCredential = new NetworkCredential(username, password);
            ICredentials credentials = netCredential.GetCredential(new Uri(this.Url), "Basic");
            this.Credentials = credentials;
            this.PreAuthenticate = true;
        }

        protected override WebRequest GetWebRequest(Uri uri) {
            HttpWebRequest request = (HttpWebRequest) base.GetWebRequest(uri);
            if (PreAuthenticate) {
                NetworkCredential networkCredentials = Credentials.GetCredential(uri, "Basic");
                if (networkCredentials != null) {
                    string creds = networkCredentials.UserName + ":" + networkCredentials.Password;
                    byte[] credentialBuffer = new UTF8Encoding().GetBytes(creds);
                    request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(credentialBuffer);
                }
                else {
                    throw new ApplicationException("No network credentials");
                }
            }
            return request;
        }
    }
}