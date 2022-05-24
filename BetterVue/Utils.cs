using System.Xml.Linq;

namespace BetterVue {
    public static class Utils {

        public static async Task<XDocument> SendRequestAsync(string username, string password, string domain, string method, string parms, HttpClient http) {
            using (var request = new HttpRequestMessage(HttpMethod.Post, $"https://svue-proxy.herokuapp.com/svue/portal.sfusd.edu")) {

                request.Headers.Add("SOAPAction", "\"http://edupoint.com/webservices/ProcessWebServiceRequest\"");
                request.Content = new StringContent(
                    "<soap-env:Envelope xmlns:soap-env=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap-env:Body><ns0:ProcessWebServiceRequest xmlns:ns0=\"http://edupoint.com/webservices/\">" +
                        $"<ns0:userID>{username}</ns0:userID>" +
                        $"<ns0:password>{password}</ns0:password>" +
                        "<ns0:skipLoginLog>true</ns0:skipLoginLog>" +
                        "<ns0:parent>false</ns0:parent>" +
                        "<ns0:webServiceHandleName>PXPWebServices</ns0:webServiceHandleName>" +
                        $"<ns0:methodName>{method}</ns0:methodName>" +
                        $"<ns0:paramStr>&lt;Parms&gt;{parms}&lt;/Parms&gt;</ns0:paramStr>" +
                    "</ns0:ProcessWebServiceRequest></soap-env:Body></soap-env:Envelope>",
                    null, "text/xml");
                var response = await (await http.SendAsync(request)).Content.ReadAsStringAsync();
                var responseXml = XDocument.Parse(response);
                XNamespace xmlns = "http://edupoint.com/webservices/";
                var xml = responseXml.Descendants(xmlns + "ProcessWebServiceRequestResult").First().Value.Replace("<br>", "&#xA;");

                return XDocument.Parse(xml);
            }

        }

    }
}
