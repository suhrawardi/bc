namespace bc.Specs.Utilities.Soap {
    using System;
    using System.Net;
    using System.Text;
    using System.Web.Services;
    
    public partial class Klanten_Soap_Client : bc.Specs.Utilities.Soap.Generated.Klanten_Service {
        public Klanten_Soap_Client(string url) {
            this.Url = url;
        }

        protected override System.Net.WebRequest GetWebRequest(Uri uri) {
            HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);
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
