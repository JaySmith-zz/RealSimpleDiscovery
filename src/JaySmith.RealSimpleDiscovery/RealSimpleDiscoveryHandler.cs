namespace JaySmith.RealSimpleDiscovery
{
    using System.Configuration;
    using System.Text;
    using System.Web;
    using System.Xml;

    public class RealSimpleDiscoveryHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            const string prefix = "http://";

            context.Response.ContentType = "text/xml";
            using (var rsd = new XmlTextWriter(context.Response.OutputStream, Encoding.UTF8))
            {
                var section = (RealSimpleDiscoverySection)ConfigurationManager.GetSection("realSimpleDiscovery");

                rsd.Formatting = Formatting.Indented;
                rsd.WriteStartDocument();

                // Rsd tag
                rsd.WriteStartElement("rsd");
                rsd.WriteAttributeString("version", "1.0");

                // Service 
                rsd.WriteStartElement("service");
                rsd.WriteElementString("engineName", "JaySmith.RealSimpleDiscovery Engine v1.0");
                rsd.WriteElementString("engineLink", "https://github.com/JaySmith/RealSimpleDiscovery");
                rsd.WriteElementString("homePageLink", AbsolutePath(context));

                // APIs
                rsd.WriteStartElement("apis");

                foreach (ApiElement api in section.Apis)
                {
                    rsd.WriteStartElement("api");
                    rsd.WriteAttributeString("name", api.Name);
                    rsd.WriteAttributeString("preferred", api.Preferred.ToString());
                    rsd.WriteAttributeString("apiLink", prefix + context.Request.Url.Authority + VirtualPathUtility.ToAbsolute("~/" + api.ApiLink));
                    rsd.WriteAttributeString("blogID", AbsolutePath(context));
                    rsd.WriteEndElement();
                }

                // End APIs
                rsd.WriteEndElement();

                // End Service
                rsd.WriteEndElement();

                // End Rsd
                rsd.WriteEndElement();

                rsd.WriteEndDocument();
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }

        private static string AbsolutePath(HttpContext context)
        {
            var path = context.Request.Url.AbsoluteUri.Replace(context.Request.Url.AbsolutePath, null);
            
            return path.EndsWith("/") ? path : path + "/";
        }
    }
}