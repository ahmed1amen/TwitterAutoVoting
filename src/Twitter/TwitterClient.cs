using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using test.Utilities;
using Twitter;

namespace test
{
    public class Response
    {

        public string Page { get; set; }
        public string Location { get; set; }
        // public CookieContainer CookieContainer { get; set; }
        public Uri ResponseUri { get; set; }
        public HttpStatusCode StatusCode { get; set; }

    }
    public class TwitterClient
    {
        private bool islogin { get; set; } = false;
        public CookieContainer CookieContainer { get; set; } = new CookieContainer();
        // public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailOrPhone { get; set; }
        public TwitterClient(string username, string password, string emailOrPhone)
        {
            Username = username;
            Password = password;
            EmailOrPhone = emailOrPhone;
        }
        /*private void AddHeader(string key, string value)
        {
            if (Headers.ContainsKey(key))
            {
                Headers[key] = value;
            }
            else
            {
                Headers.Add(key, value);
            }
        }*/


        Response getRequest(string url_from, string Referer = null, CookieContainer cookies = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                using (var client = new BetterWebClient(cookies == null ? CookieContainer : cookies))
                {

                    client.Headers[HttpRequestHeader.UserAgent] = islogin ? "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.2; Win64; x64; Trident/7.0; .NET4.0C; .NET4.0E; .NET CLR 2.0.50727; .NET CLR 3.0.30729; .NET CLR 3.5.30729; Tablet PC 2.0; Zoom 3.6.0)" : "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36";
                    if (!string.IsNullOrWhiteSpace(Referer))
                        client.Headers[HttpRequestHeader.Referer] = Referer;
                    string response = client.DownloadString(url_from);
                    extractCookies(client.ResponseHeaders["Set-Cookie"]);
                    return new Response { Page = response, Location = client.Location, StatusCode = client.StatusCode, ResponseUri = client.ResponseUri };
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        void extractCookies(string cookies)
        {
            if (cookies == null)
                return;
            foreach (var singleCookie in cookies.Split(','))
            {
                try
                {
                    Match match = Regex.Match(singleCookie, "(.+?)=(.+?);");
                    if (match.Captures.Count == 0)
                        continue;
                    CookieContainer.Add(
                        new System.Net.Cookie(
                            match.Groups[1].ToString(),
                            match.Groups[2].ToString(),
                            "/",
                            ".twitter.com"));
                }
                catch (Exception)
                {

                }

            }
        }

        Response postRequest(string url_from, string parameters, string Referer = null, CookieContainer cookies = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                using (var client = new BetterWebClient(cookies == null ? CookieContainer : cookies))
                {

                    client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:65.0) Gecko/20100101 Firefox/65.0";
                    if (!string.IsNullOrWhiteSpace(Referer))
                        client.Headers[HttpRequestHeader.Referer] = Referer;
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";

                    string response = client.UploadString(url_from, parameters);
                    extractCookies(client.ResponseHeaders["Set-Cookie"]);
                    return new Response { Page = response, Location = client.Location, StatusCode = client.StatusCode, ResponseUri = client.ResponseUri };
                }

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        void SaveCookies()
        {
            var formatter = new SoapFormatter();
            if (!Directory.Exists("Cookies"))
                Directory.CreateDirectory("Cookies");
            string file = $"Cookies/{Username}.dat";

            using (Stream s = File.Create(file))
                formatter.Serialize(s, CookieContainer);
        }
        public bool CookiesFound { get; set; }
        public void CheckCookies()
        {
            try
            {
                var formatter = new SoapFormatter();
                string file = $"Cookies/{Username}.dat";
                using (Stream s = File.OpenRead(file))
                    CookieContainer = (CookieContainer)formatter.Deserialize(s);
                if (CookieContainer != null)
                    CookiesFound = true;
            }
            catch (Exception)
            {

            }
        }
        public bool Login()
        {
            try
            {
                islogin = true;
                var loginPage = getRequest("https://mobile.twitter.com/login/");
                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(loginPage.Page);
                islogin = false;
                var authenticity_token = htmlDoc.DocumentNode.SelectSingleNode("//input[@name = 'authenticity_token']").GetAttributeValue("value", "");
                var postLogin = postRequest("https://twitter.com/sessions", $"session[username_or_email]={Username}&session[password]={Password}&authenticity_token={authenticity_token}&remember_me=1&return_to_ssl=true&scribe_log=&redirect_after_login=&ui_metrics=", "https://twitter.com/login");
                if (postLogin.ResponseUri.OriginalString.ToLower().Contains("account/access"))
                {
                    AccountAccess(postLogin.Page);

                }
                else if (postLogin.ResponseUri.OriginalString.ToLower().Contains("account/login_challenge"))
                {
                    LoginChallenge(postLogin.ResponseUri.OriginalString, postLogin.Page);
                    //runBrowserThread(new Uri("https://twitter.com"));
                    SaveCookies();
                    return true;
                }
                if (postLogin.ResponseUri.LocalPath == "/")
                {
                    //runBrowserThread(new Uri("https://twitter.com"));
                    SaveCookies();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        string getJsonValue(string page, string key)
        {
            try
            {
                Regex regex = new Regex($"(?:\"{key}\":\")(.*?)(?:\")");
                string value = regex.Match(page.Replace(" ", "").Replace("\n", "")).Value;
                value = value.Replace($"\"{key}\":\"", "");
                if (value.LastOrDefault() == '"')
                    value = value.Remove(value.Length - 1);
                return value;
            }
            catch (Exception)
            {


            }
            return null;
        }
        public HttpClientHandler handler = new HttpClientHandler();
        HttpClient clientLogin;
        public async void Vote(string voteUri, int selected_choice)
        {
            try
            {

                handler = new HttpClientHandler();
                handler.CookieContainer = CookieContainer;
                handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                clientLogin = new HttpClient(handler);


                clientLogin.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/80.0.3987.149 Safari/537.36");
                clientLogin.DefaultRequestHeaders.Add("authorization", "Bearer AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA");
                clientLogin.DefaultRequestHeaders.Add("x-twitter-auth-type", "OAuth2Session");
                clientLogin.DefaultRequestHeaders.Add("x-twitter-active-user", "yes");
                clientLogin.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                clientLogin.DefaultRequestHeaders.Add("X-MicrosoftAjax", "Delta=true");

                int index = voteUri.IndexOf("?");
                if (index > 0)
                    voteUri = voteUri.Substring(0, index);
                string tweet_id = voteUri.Split('/')[voteUri.Split('/').Length - 1];

                Response res = getRequest("https://twitter.com/");
                //var matches = Regex.Matches(res.Page, "ct0=(.*?);");
                string ct0 = ""; // matches[0].Groups[1].Value;
            
                var card = getRequest($"https://twitter.com/i/cards/tfw/v1/{tweet_id}", voteUri);

                string card_uri = getJsonValue(card.Page, "card_uri");
                //string tweet_id = getJsonValue(card.Page, "tweet_id");
                string card_name = getJsonValue(card.Page, "card_name");
                string token = getJsonValue(card.Page, "token");
                string capi = getJsonValue(card.Page, "capi");
                //    

                Uri uri = new Uri("https://www.twitter.com");
                System.Net.CookieCollection cookies = CookieContainer.GetCookies(new Uri("https://twitter.com"));
                foreach (System.Net.Cookie cookie in cookies)
                {

                    if (cookie.Name == "ct0")
                    {
                    
                    clientLogin.DefaultRequestHeaders.Add("x-csrf-token", cookie.Value);

                        break;
                    }
                }




                var values = new Dictionary<string, string>
                    {
            {"twitter:string:card_uri" ,card_uri},
            {"twitter:long:original_tweet_id" ,tweet_id},
            {"twitter:string:response_card_name" , card_name},
            {"twitter:string:cards_platform" , "Web-12"},
            {"twitter:string:selected_choice" ,selected_choice.ToString()}
            };

                var content = new FormUrlEncodedContent(values);

                var response = await clientLogin.PostAsync("https://caps.twitter.com/v2/capi/passthrough/1", content);

                var responseString = response.Content.ReadAsStringAsync();



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error Voting Code #6662 " + Environment.NewLine + ex.Message);
            }


        }
        private void LoginChallenge(string uri, string page)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page);
            var nodes = htmlDoc.DocumentNode.SelectSingleNode("//form[@id = 'login-challenge-form']").SelectNodes("//input");
            string parameters = "";
            foreach (var node in nodes)
            {
                string name = node.GetAttributeValue("name", "");
                string value = node.GetAttributeValue("value", "");
                if (!string.IsNullOrWhiteSpace(name) && name != "challenge_response")
                {
                    parameters += $"{name}={value}&";
                }
            }
            parameters += $"challenge_response={EmailOrPhone}";
            var challenge_response = postRequest(uri, parameters);
            if (challenge_response.ResponseUri.LocalPath != "/" || !challenge_response.ResponseUri.LocalPath.ToLower().Contains("account/password_reset_complete"))
                throw new Exception("challenge");
        }

        private void AccountAccess(string page)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(page);
            var uri = htmlDoc.DocumentNode.SelectSingleNode("//a[contains(@class ,'EdgeButton')]").GetAttributeValue("href", "");
            if (uri.ToLower().Contains("access_password_reset"))
            {
                //password reset //access_password_reset?current_user_only=true&amp;cause=br
                throw new Exception("Password Reset");
            }
        }
    }
}
