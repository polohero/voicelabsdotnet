using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VoiceLabs.Client
{
    [DataContract]
    public class AnalyticsData
    {
        public AnalyticsData()
        {
            MetaData = new Dictionary<string, AnalyticsSlot>(50);
        }

        public AnalyticsData(string speech)
        {
            MetaData = new Dictionary<string, AnalyticsSlot>(50);
            Speech = speech;
        }

        public AnalyticsData(
            string speech,
            Dictionary<string, AnalyticsSlot> metaData)
        {
            MetaData = metaData;
            Speech = speech;
        }

        [DataMember(Name = "metadata")]
        public Dictionary<string, AnalyticsSlot> MetaData { get; set; }

        [DataMember(Name = "speech")]
        public string Speech { get; set; }

        public void AddMetaData(string key, string value)
        {
            if( true == MetaData.ContainsKey(key))
            {
                throw new ArgumentException(
                    "A duplicate key was attempted to be adding to the metadata. " +
                    "I believe this needs to be unique, so I developed the library as such " +
                    "but I've never actually asked VoiceLabs if it's required and just assumed.",
                    "key");
            }

            MetaData.Add(key, new AnalyticsSlot(key, value));

        }
    }
}
