namespace Proviant
{
    internal class KeyValue
    {
        internal KeyValue(string key, bool value = false)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public bool Value { get; set; }
    }
}