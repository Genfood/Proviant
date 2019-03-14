namespace Proviant
{
    /// <summary>
    /// Key value.
    /// </summary>
    internal class KeyValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Proviant.KeyValue"/> class.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="value">If set to <c>true</c> value.</param>
        internal KeyValue(string key, bool value = false)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        internal string Key { get; set; }

        /// <summary>
        /// Gets or sets a value.
        /// </summary>
        /// <value><c>true</c> if value; otherwise, <c>false</c>.</value>
        internal bool Value { get; set; }
    }
}