namespace Firebase.Xamarin.Auth
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public partial class FirebaseAuthProvider
    {
        private const string GoogleUserInfoUrl = "https://www.googleapis.com/identitytoolkit/v3/relyingparty/getAccountInfo?key={0}";
        private const string GoogleTokenUrl = "https://securetoken.googleapis.com/v1/token?key={0}";



        //user infos
        public async Task<FirebaseAccountInfo> SignInWithTokenAsync(string tk)
        {
            var content = $"{{\"idToken\":\"{tk}\"}}";
            var x = await this._SignInWithTokenAsync(GoogleUserInfoUrl, content).ConfigureAwait(false);
            return x;
        }
        private async Task<FirebaseAccountInfo> _SignInWithTokenAsync(string googleUrl, string postContent)
        {
            var response = await this.client.PostAsync(new Uri(string.Format(googleUrl, this.authConfig.ApiKey)), new StringContent(postContent, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var jsonReturn = JObject.Parse(responseData);
                var message = (string)jsonReturn["error"]["message"];

                // Login
                // Email address not found in database
                if (message.Equals("EMAIL_NOT_FOUND"))
                {
                    throw new FirebaseInvalidEmailException("Email address not found");
                }
                // Login
                // Invalid password supplied
                else if (message.Equals("INVALID_PASSWORD"))
                {
                    throw new FirebaseIncorrectPasswordException("Incorrect passord");
                }
                // New User
                // Email address already exists
                else if (message.Equals("EMAIL_EXISTS"))
                {
                    throw new FirebaseUsedEmailException("Email address already exists");
                }
                // New User
                // Week Password
                else if (message.Contains("WEAK_PASSWORD"))
                {
                    throw new FirebaseWeakPasswordException("Weak password, must be at least 6 characters");
                }
                // Just end on default status check
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            var auth = JsonConvert.DeserializeObject<FirebaseAccountInfo>(responseData);

            return auth;
        }

        //token id
        public async Task<RequestToken> RequestTokenAsync(string r_tk)
        {

            var content = $"{{\"grant_type\":\"refresh_token\",\"refresh_token\":\"{r_tk}\"}}";
            var x = await this._RequestTokenAsync(GoogleTokenUrl, content).ConfigureAwait(false);
            return x;
        }

        private async Task<RequestToken> _RequestTokenAsync(string googleUrl, string postContent)
        {
            var response = await this.client.PostAsync(new Uri(string.Format(googleUrl, this.authConfig.ApiKey)), new StringContent(postContent, Encoding.UTF8, "application/json")).ConfigureAwait(false);
            var responseData = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var jsonReturn = JObject.Parse(responseData);
                var message = (string)jsonReturn["error"]["message"];

                // Login
                // Email address not found in database
                if (message.Equals("EMAIL_NOT_FOUND"))
                {
                    throw new FirebaseInvalidEmailException("Email address not found");
                }
                // Login
                // Invalid password supplied
                else if (message.Equals("INVALID_PASSWORD"))
                {
                    throw new FirebaseIncorrectPasswordException("Incorrect passord");
                }
                // New User
                // Email address already exists
                else if (message.Equals("EMAIL_EXISTS"))
                {
                    throw new FirebaseUsedEmailException("Email address already exists");
                }
                // New User
                // Week Password
                else if (message.Contains("WEAK_PASSWORD"))
                {
                    throw new FirebaseWeakPasswordException("Weak password, must be at least 6 characters");
                }
                // Just end on default status check
                else
                {
                    response.EnsureSuccessStatusCode();
                }
            }

            var r = JsonConvert.DeserializeObject<RequestToken>(responseData);

            return r;
        }

    }
    public class FirebaseAccountInfo
    {
        public string kind { get; set; }
        public User[] users { get; set; }
    }
}
