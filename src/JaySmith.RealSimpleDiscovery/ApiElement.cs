namespace JaySmith.RealSimpleDiscovery
{
    using System.Configuration;

    public class ApiElement : ConfigurationElement
    {
        public ApiElement()
        {
            Name = "MetaWeblog";
            Preferred = true;
            ApiLink = "/rsd.axd";
            BlogId = "1";
        }

        public ApiElement(string name, bool preferred, string apiLink, string blogId)
        {
            Name = name;
            Preferred = preferred;
            ApiLink = apiLink;
            BlogId = blogId;
        }

        [ConfigurationProperty("name", DefaultValue = "MetaWeblog", IsRequired = true)]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("preferred", DefaultValue = "false", IsRequired = false)]
        public bool Preferred
        {
            get { return (bool)this["preferred"]; }
            set { this["preferred"] = value; }
        }

        [ConfigurationProperty("apiLink", DefaultValue = "false", IsRequired = false)]
        public string ApiLink
        {
            get { return (string)this["apiLink"]; }
            set { this["apiLink"] = value; }
        }

        [ConfigurationProperty("blogID", DefaultValue = "1", IsRequired = false)]
        public string BlogId
        {
            get { return (string)this["blogID"]; }
            set { this["blogID"] = value; }
        }
    }
}