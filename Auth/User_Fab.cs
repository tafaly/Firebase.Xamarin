namespace Firebase.Xamarin.Auth
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class User
    {


        /// <summary>
        /// To add ...
        /// </summary>
        [JsonProperty("phoneNumber", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// To add ...
        /// </summary>
        [JsonProperty("lastLoginAt", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string LastLoginAt { get; set; }
        /// <summary>
        /// To add ...
        /// </summary>
        [JsonProperty("createdAt", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string CreateAt { get; set; }

    }

    public class RequestToken
    {

        /// <summary>
        /// To Add ...
        /// </summary>
        [JsonProperty("access_token", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string AccessToken
        {
            get;
            set;
        }

        /// <summary>
        /// To Add ...
        /// </summary>
        [JsonProperty("expires_in", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue(0)]
        public int ExpiresIn
        {
            get;
            set;
        }

        /// <summary>
        /// To Add ...
        /// </summary>
        [JsonProperty("token_type", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string TokenType
        {
            get;
            set;
        }

        /// <summary>
        /// To Add ...
        /// </summary>
        [JsonProperty("refresh_token", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string RefreshToken
        {
            get;
            set;
        }

        /// <summary>
        /// To Add ...
        /// </summary>
        [JsonProperty("id_token", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string FirebaseToken
        {
            get;
            set;
        }
        /// <summary>
        /// To Add ...
        /// </summary>
        [JsonProperty("user_id", DefaultValueHandling = DefaultValueHandling.Populate)]
        [DefaultValue("")]
        public string UserId
        {
            get;
            set;
        }
    }
}
