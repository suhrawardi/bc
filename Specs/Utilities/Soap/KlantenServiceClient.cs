namespace bc.Specs.Utilities.Soap {
    using System;
    using System.Net;
    using System.Text;
    using System.Web.Services;
    
    public partial class KlantenServiceClient : Generated.Klanten_Service {
        public KlantenServiceClient(SoapConfig config) : base() {
            this.Url =  "https://" + config.host + "/" + config.env + "/WS/" + config.company + "/Page/Klanten";
            this.AddAuthentication(config.username, config.password);
        }
    }
}
