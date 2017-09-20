using System;
using System.Runtime.Serialization;


namespace VoiceLabs.Client
{
    [DataContract]
    public class AnalyticsSlot
    {
        public AnalyticsSlot() { }
        public AnalyticsSlot(string name, string value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("name", "The name for the slot must not be null or whitespace");
            }
            if (null == value)
            {
                throw new ArgumentNullException("value", "The value for the slot must not be null.");
            }


            Name = name;
            Value = value;

        }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "value")]
        public string Value { get; set; }

        public bool IsSet
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Value))
                {
                    return false;
                }

                return true;
            }
        }
    }
}
