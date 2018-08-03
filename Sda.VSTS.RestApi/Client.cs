//https://www.visualstudio.com/en-us/docs/integrate/get-started/authentication/authentication_guidance

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Linq;
using System.Runtime.InteropServices;

namespace Sda.VSTS.RestApi
{

    public class Client
    {
        private HttpClient client;
        public WorkItemTracking WorkItemTracking;

        private static AuthenticationContext authContext;

        private const string baseAddress = "https://sda-iatec.visualstudio.com";
        private const string VSTSResourceId = "499b84ac-1321-427f-aa17-267ca6975798"; //Static value to target VSTS. Do not change
        private const string replyUrl = "urn:ietf:wg:oauth:2.0:oob";
        private const string clientId = "872cd9fa-d31f-45e0-9eab-6e460a02d1f1"; //VS ClientId. Please use this instead of your app's clientId


        public Client(string project)
        {
            Urls.SetProject(project);
            WorkItemTracking = new WorkItemTracking(this);

            client = new HttpClient();
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "ManagedClientConsoleAppSample");
            client.DefaultRequestHeaders.Add("X-TFS-FedAuthRedirect", "Suppress");

            authContext = GetAuthenticationContext(null);
            AuthenticationResult result = null;

            try
            {
                //PromptBehavior.RefreshSession will enforce an auth prompt every time. NOTE: Auto will take your windows login state if possible
                result = authContext.AcquireTokenAsync(VSTSResourceId, clientId, new Uri(replyUrl), new PlatformParameters(PromptBehavior.Auto)).Result;
                Console.WriteLine("Token expires on: " + result.ExpiresOn);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);
            }
            catch (UnauthorizedAccessException)
            {
                // If the token has expired, prompt the user with a login prompt
                result = authContext.AcquireTokenAsync(VSTSResourceId, clientId, new Uri("urn:ietf:wg:oauth:2.0:oob"), new PlatformParameters(PromptBehavior.Always)).Result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType(), ex.Message);
            }

        }

        private static AuthenticationContext GetAuthenticationContext(string tenant)
        {
            AuthenticationContext ctx = null;
            if (tenant != null)
                //ctx = new AuthenticationContext("https://login.microsoftonline.com/" + tenant, new FileCache());
                ctx = new AuthenticationContext("https://login.microsoftonline.com/" + tenant);
            else
            {
                //ctx = new AuthenticationContext("https://login.windows.net/common", new FileCache());
                ctx = new AuthenticationContext("https://login.windows.net/common");
                if (ctx.TokenCache.Count > 0)
                {
                    string homeTenant = ctx.TokenCache.ReadItems().First().TenantId;
                    //ctx = new AuthenticationContext("https://login.microsoftonline.com/" + homeTenant, new FileCache());
                    ctx = new AuthenticationContext("https://login.microsoftonline.com/" + homeTenant);
                }
            }

            return ctx;
        }

        public static void SignOut()
        {
            // Clear the token cache
            authContext.TokenCache.Clear();

            // Clear cookies from the browser control.
            ClearCookies();
        }

        #region Cookie Management

        // This function clears cookies from the browser control used by ADAL.
        private static void ClearCookies()
        {
            const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
        }

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);

        #endregion

        #region AJAX Methods

        internal HttpResponseMessage Get(string url)
        {
            return client.GetAsync(url).Result;
        }

        internal HttpResponseMessage Post(string url)
        {
            //return client.PostAsync()
            throw new NotImplementedException();
        }

        #endregion AJAX Methods

    }
}
