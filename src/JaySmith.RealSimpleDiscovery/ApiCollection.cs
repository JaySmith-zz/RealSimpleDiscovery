namespace JaySmith.RealSimpleDiscovery
{
    using System.Configuration;

    public class ApiCollection : ConfigurationElementCollection
    {
        public ApiCollection()
        {
            var collection = (ApiElement)CreateNewElement();
            Add(collection);
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        protected override sealed ConfigurationElement CreateNewElement()
        {
            return new ApiElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ApiElement)element).Name;
        }

        public ApiElement this[int index]
        {
            get { return (ApiElement)BaseGet(index); }
            set 
            {
                if (BaseGet(index) != null) BaseRemoveAt(index);
                
                BaseAdd(index, value);
            }
        }

        new public ApiElement this[string name]
        {
            get { return (ApiElement)BaseGet(name); }
        }

        public int IndexOf(ApiElement apiElement)
        {
            return BaseIndexOf(apiElement);
        }

        public void Add(ApiElement apiElement)
        {
            BaseAdd(apiElement);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }

        public void Remove(ApiElement element)
        {
            if (BaseIndexOf(element) >= 0)
                BaseRemove(element.Name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void Clear()
        {
            BaseClear();
        }
    }
}