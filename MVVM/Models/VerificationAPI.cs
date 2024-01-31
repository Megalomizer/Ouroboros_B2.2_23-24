using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuroborosEvents.MVVM.Models
{
    public class VerificationAPI
    {
        public string InputData { get; set; }
        public bool IsValid { get; set; }
        public bool IsSyntaxValid { get; set; }
        public bool IsMailServerDefined { get; set; }
        public bool IsKnownSpammerDomain { get; set; }
        public bool IsDisposable { get; set; }

        public static async Task<VerificationAPI> VerifyEmailAsync(string emailAddress)
        {
            string apiKey = "bdc_ddaa930b5aad4a21b6765545c17d1ed5";
            string apiUrl = $"https://api.bigdatacloud.net/data/email-verify?emailAddress={Uri.EscapeDataString(emailAddress)}&key={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // GET Request for ver
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    // check status 200 (success)
                    if (response.IsSuccessStatusCode)
                    {
                        // Make result into string
                        string result = await response.Content.ReadAsStringAsync();

                        return JsonConvert.DeserializeObject<VerificationAPI>(result);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }
    }
}

