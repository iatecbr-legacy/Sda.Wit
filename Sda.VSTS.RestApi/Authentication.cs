using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.VSTS.RestApi
{
    //internal static class Authentication
    //{
    //    //Below is the clientId of your app registration. 
    //    //You have to replace the below with the Application Id for your app registration
    //    private static string ClientId = "81239bcc-3398-47e4-aba3-3d8bd6a11a38";

    //    private static PublicClientApplication PublicClientApp = new PublicClientApplication(ClientId);

    //    //Set the API Endpoint to Graph 'me' endpoint
    //    //private static string _graphAPIEndpoint = "https://graph.microsoft.com/v1.0/me";

    //    //Set the scope for API call to user.read
    //    private static string[] _scopes = new string[] { "user.read" };


    //    /// <summary>
    //    /// Call AcquireTokenAsync - to acquire a token requiring user to sign-in
    //    /// </summary>
    //    public static async void AcquireTokenAsync(Action<string> callback)
    //    {
    //        AuthenticationResult authResult = null;

    //        if (PublicClientApp.Users.Count() != 0)
    //        {
    //            try
    //            {
    //                authResult = await PublicClientApp.AcquireTokenSilentAsync(_scopes, PublicClientApp.Users.FirstOrDefault());
    //            }
    //            //catch (MsalUiRequiredException ex)
    //            //{

    //            //}
    //            catch (Exception ex)
    //            {
    //                throw new Exception($"Error Acquiring Token Silently:{System.Environment.NewLine}{ex}");
    //            }
    //        }
    //        else
    //        {
    //            try
    //            {
    //                authResult = await PublicClientApp.AcquireTokenAsync(_scopes);
    //            }
    //            catch (MsalException msalex)
    //            {
    //                // A MsalUiRequiredException happened on AcquireTokenSilentAsync. This indicates you need to call AcquireTokenAsync to acquire a token
    //                System.Diagnostics.Debug.WriteLine($"MsalUiRequiredException: {msalex.Message}");

    //                throw new Exception($"Error Acquiring Token:{System.Environment.NewLine}{msalex}");
    //            }
    //        }

    //        if (authResult != null)
    //        {
    //            callback(authResult.AccessToken);
    //        }

    //    }


    //    ///// <summary>
    //    ///// Perform an HTTP GET request to a URL using an HTTP Authorization header
    //    ///// </summary>
    //    ///// <param name="url">The URL</param>
    //    ///// <param name="token">The token</param>
    //    ///// <returns>String containing the results of the GET operation</returns>
    //    //public async Task<string> GetHttpContentWithToken(string url, string token)
    //    //{
    //    //    var httpClient = new System.Net.Http.HttpClient();
    //    //    System.Net.Http.HttpResponseMessage response;
    //    //    try
    //    //    {
    //    //        var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Get, url);
    //    //        //Add the token in Authorization header
    //    //        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
    //    //        response = await httpClient.SendAsync(request);
    //    //        var content = await response.Content.ReadAsStringAsync();
    //    //        return content;
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        return ex.ToString();
    //    //    }
    //    //}


    //    ///// <summary>
    //    ///// Display basic information contained in the token
    //    ///// </summary>
    //    //private void DisplayBasicTokenInfo(AuthenticationResult authResult)
    //    //{
    //    //    TokenInfoText.Text = "";
    //    //    if (authResult != null)
    //    //    {
    //    //        TokenInfoText.Text += $"Name: {authResult.User.Name}" + Environment.NewLine;
    //    //        TokenInfoText.Text += $"Username: {authResult.User.DisplayableId}" + Environment.NewLine;
    //    //        TokenInfoText.Text += $"Token Expires: {authResult.ExpiresOn.ToLocalTime()}" + Environment.NewLine;
    //    //        TokenInfoText.Text += $"Access Token: {authResult.AccessToken}" + Environment.NewLine;
    //    //    }
    //    //}


    //    /// <summary>
    //    /// Sign out the current user
    //    /// </summary>
    //    private static void SignOut()
    //    {
    //        if (PublicClientApp.Users.Any())
    //        {
    //            try
    //            {
    //                PublicClientApp.Remove(PublicClientApp.Users.FirstOrDefault());
    //                //this.ResultText.Text = "User has signed-out";
    //                //this.CallGraphButton.Visibility = Visibility.Visible;
    //                //this.SignOutButton.Visibility = Visibility.Collapsed;
    //            }
    //            catch (MsalException ex)
    //            {
    //                throw new Exception($"Error signing-out user: {ex.Message}");
    //            }
    //        }
    //    }

    //}
}

