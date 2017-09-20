using System;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace VoiceLabs.Client
{
    [DataContract]
    public class AnalyticsRequest
    {
        public AnalyticsRequest() { }

        public AnalyticsRequest(
            string userID,
            string sessionID,
            string intent,
            AnalyticsData data,
            string appToken)
        {
            AppToken = appToken;
            UserID = mD5Hash(userID);
            SessionID = sessionID;
            Intent = intent;
            Data = data;
            EventType = "SPEECH";
        }

        public void Send()
        {
            Client client = new Client();
            client.Process(this);
        }


        [DataMember(Name = "app_token")]
        public string AppToken { get; set; }

        [DataMember(Name = "user_hashed_id")]
        public string UserID { get; set; }

        [DataMember(Name = "session_id")]
        public string SessionID { get; set; }

        [DataMember(Name = "intent")]
        public string Intent { get; set; }

        [DataMember(Name = "data")]
        public AnalyticsData Data { get; set; }

        [DataMember(Name = "event_type")]
        public string EventType { get; set; }

        private static string mD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
