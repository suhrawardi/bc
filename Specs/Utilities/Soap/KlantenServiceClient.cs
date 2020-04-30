namespace bc.Specs.Utilities.Soap {
    using System;
    using System.Net;
    using System.Text;
    using System.Web.Services;
    
    public partial class KlantenServiceClient : Generated.Klanten_Service {
        public KlantenServiceClient(string host, string env, string company, string username, string password) : base() {
            this.Url =  "https://" + host + "/" + env + "/WS/" + company + "/Page/Klanten";
            this.AddAuthentication(username, password);
        }
    }
}
