namespace JaySmith.RealSimpleDiscovery
{
    using System.Configuration;

    public class RealSimpleDiscoverySection : ConfigurationSection
    {
        [ConfigurationProperty("apis", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ApiCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public ApiCollection Apis
        {
            get { return (ApiCollection)base["apis"]; }
        }
    }
}
