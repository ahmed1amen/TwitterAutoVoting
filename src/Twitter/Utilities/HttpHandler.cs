using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace test.Utilities
{
  public class HttpHandler
  {
    /// <summary>
    /// Contain cookie for making authorized request 
    /// </summary>
    public virtual CookieContainer CookieContainer { get; set; }

    /// <summary>
    /// Add Proxy 
    /// </summary>
    public virtual WebProxy Proxy { get; set; }


    /// <summary>
    /// User-agent
    /// </summary>
    public virtual string UserAgent { get; set; }

    /// <summary>
    /// Initialize new instance of BaseHttp request with default user agent
    /// </summary>
    public HttpHandler()
    {
      CookieContainer = new CookieContainer();

      // default user-agent
      // TODO (ThinhVu) : Fix hard-coded user agent
      UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:45.0) Gecko/20100101 Firefox/45.0";
    }

    /// <summary>
    /// Initialize new instance of BaseHttp request.
    /// </summary>
    /// <param name="userAgent">User agent</param>
    public HttpHandler(string userAgent)
        : this()
    {
      UserAgent = userAgent;
    }
    /// <summary>
    /// Initialize new instance of BaseHttp request.
    /// </summary>
    /// <param name="userAgent">User agent</param>
    ///   /// <param name="proxy">Proxy</param>
    public HttpHandler(string userAgent, WebProxy proxy)
        : this()
    {
      UserAgent = userAgent;
      Proxy = proxy;
    }


    /// <summary>
    /// Make GET request
    /// </summary>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    public virtual HttpWebRequest MakeGetRequest(Uri requestUri)
    {
      var request = this.CreateRequest(requestUri);

      if (Proxy != null)
      {
        Proxy.BypassProxyOnLocal = false;
        request.Proxy = Proxy;
      }
      request.Method = WebRequestMethods.Http.Get;

      return request;
    }

    /// <summary>
    /// Make POST request
    /// </summary>
    /// <param name="requestUri"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public virtual HttpWebRequest MakePostRequest(Uri requestUri, byte[] content)
    {
      var request = this.CreateRequest(requestUri);
      if (Proxy != null)
      {
        Proxy.BypassProxyOnLocal = false;
        request.Proxy = Proxy;
      }
      request.Method = WebRequestMethods.Http.Post;
      request.ContentLength = content.Length;
      request.ContentType = "application/x-www-form-urlencoded";

      return request;
    }

    public virtual HttpWebRequest MakePutRequest(Uri requestUri, byte[] content)
    {
      var request = this.CreateRequest(requestUri);
      if (Proxy != null)
      {
        Proxy.BypassProxyOnLocal = false;
        request.Proxy = Proxy;
      }
      request.Method = WebRequestMethods.Http.Put;
      request.ContentLength = content.Length;
      request.ContentType = "application/x-www-form-urlencoded";

      return request;
    }

    /// <summary>
    /// Send GET request to requestUri and recv response
    /// </summary>
    /// <param name="requestUri">A string containing the URI of the requested resource</param>
    /// <param name="cookies">A System.Net.CookieContainer containing cookies for this request</param>        
    /// <returns>A System.Net.HttpWebResponse for the specified uri scheme</returns>
    public virtual HttpWebResponse SendGetRequest(string requestUrl)
    {
      var response = MakeGetRequest(new Uri(requestUrl)).GetResponse() as HttpWebResponse;

      this.StoreCookie(response.Cookies);

      return response;
    }

    /// <summary>
    /// Send POST request to requestUri and recv response
    /// </summary>
    /// <param name="requestUrl">A System.String containing the URI of the requested resource</param>
    /// <param name="content">A System.String containing the content to send</param>
    /// <param name="cookies">A System.Net.CookieContainer containing cookies for this request</param>        
    /// <returns>A System.Net.HttpWebResponse for the specified uri scheme</returns>
    public virtual HttpWebResponse SendPostRequest(string requestUrl, string content)
    {
      byte[] buffer = Encoding.ASCII.GetBytes(content);

      var postRequest = MakePostRequest(new Uri(requestUrl), buffer);
      using (var postRequestStream = postRequest.GetRequestStream())
        postRequestStream.Write(buffer, 0, buffer.Length);

      var response = postRequest.GetResponse() as HttpWebResponse;

      this.StoreCookie(response.Cookies);

      return response;
    }

    public virtual HttpWebResponse SendPostRequests(string requestUrl, string content)
    {
      byte[] buffer = Encoding.ASCII.GetBytes(content);

      var postRequest = MakePostRequest(new Uri(requestUrl), buffer);

      postRequest.Headers.Add(HttpRequestHeader.Cookie, "twitter_ads_id=v1_106099989729681024; netpu=\"Frjn24HoVgA=\"; kdt=p0SqJgZavmo25FvRtutuTsDIySA9J7k8fzAjBlps; remember_checked_on=1; syndication_guest_id=v1%3A149373900027974440; _ga=GA1.2.1872849231.1491404289; eu_cn=1; __ncuid=c711f3b3-cbcb-40a9-b280-00cbf0e303f2; csrf_same_site_set=1; csrf_same_site=1; mobile_metrics_token=152482245995138322; tfw_exp=1; __utmz=43838368.1532522460.1.1.utmcsr=(direct)|utmccn=(direct)|utmcmd=(none); __utma=43838368.1872849231.1491404289.1532522460.1533814213.2; __utmc=43838368; _gid=GA1.2.334947814.1533881339; night_mode=1; dnt=1; lang=en; ct0=1c4157d3da40269bd8b3556ccc55e2b0; _twitter_sess=BAh7DSIKZmxhc2hJQzonQWN0aW9uQ29udHJvbGxlcjo6Rmxhc2g6OkZsYXNo%250ASGFzaHsABjoKQHVzZWR7ADoPY3JlYXRlZF9hdGwrCGt9cx5lAToHaWQiJTM1%250ANzNlMzY4MWQ1MWU2YzQ2ZjYwOWJlMDllZDEwMjg1Ogxjc3JmX2lkIiU5M2M3%250AZjdiNmUzMDFiMmI4NTczMDcxYzg0MTkwOWJjYiIJcHJycCIAOghwcnNpCDoI%250AcHJ1bCsJAmBWKHbvfgs6CHByaWkH--cc29839305c6fc0b38434f10c3ccfa59f0c21e7b; personalization_id=\"v1_geoCH8umIGA114Px+1QHog==\"; guest_id=v1%3A153394902308150205; gt=1028082983142649856; auth_token=ce6576b857eabeb2d0368c4936b3d65890704b07");
      postRequest.Headers.Add("x-csrf-token", "1c4157d3da40269bd8b3556ccc55e2b0");
      postRequest.Headers.Add("x-twitter-auth-type", "OAuth2Session");
      postRequest.Headers.Add("x-twitter-active-user", "yes");

      postRequest.Headers.Add(HttpRequestHeader.Authorization, "Bearer AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA");

      using (var postRequestStream = postRequest.GetRequestStream())
        postRequestStream.Write(buffer, 0, buffer.Length);

      var response = postRequest.GetResponse() as HttpWebResponse;

      this.StoreCookie(response.Cookies);

      return response;
    }


    public virtual HttpWebResponse SendPutRequest(string requestUrl, string content)
    {
      byte[] buffer = Encoding.ASCII.GetBytes(content);

      var postRequest = MakePutRequest(new Uri(requestUrl), buffer);

      using (var postRequestStream = postRequest.GetRequestStream())
        postRequestStream.Write(buffer, 0, buffer.Length);

      var response = postRequest.GetResponse() as HttpWebResponse;

      this.StoreCookie(response.Cookies);

      return response;
    }


    public string Get(Uri url)
    {
      try
      {

        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        httpWebRequest.CookieContainer = CookieContainer;
        httpWebRequest.AllowAutoRedirect = true;
        if (Proxy != null)
        {
          Proxy.BypassProxyOnLocal = false;
          httpWebRequest.Proxy = (IWebProxy)Proxy;
        }

        httpWebRequest.Method = "GET";
        httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
        httpWebRequest.AllowWriteStreamBuffering = true;
        httpWebRequest.ProtocolVersion = HttpVersion.Version11;
        httpWebRequest.AllowAutoRedirect = true;
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        HttpWebResponse response = (HttpWebResponse)httpWebRequest.GetResponse();
        return GetPage(response);
      }
      catch (Exception ex)
      {
        return null;
      }
    }
    private string GetPage(HttpWebResponse getResponse)
    {
      if (getResponse == null)
        return (string)null;
      using (StreamReader streamReader = new StreamReader(getResponse.GetResponseStream()))
      {
        string end = streamReader.ReadToEnd();
        getResponse.Close();
        return end;
      }
    }
    /// <summary>
    /// Download Html content
    /// </summary>
    /// <param name="requestUri"></param>
    /// <returns></returns>
    public virtual string DownloadContent(string requestUrl)
    {
      // cause Accept-Encoding allow gzip so request use gzip stream to decompress content.
      using (var response = this.SendGetRequest(requestUrl))
      using (var responseStreamReader = new StreamReader(new GZipStream(response.GetResponseStream(), CompressionMode.Decompress)))
      {
        return responseStreamReader.ReadToEnd();
      }
    }

    /// <summary>
    /// Create a request
    /// </summary>
    /// <param name="requestUri">A System.Uri containing the URI of the requested resource</param>
    /// <param name="cookieContainer">A System.Net.CookieContainer containing cookies for this request</param>              
    /// <returns>A System.Net.HttpWebRequest for the specified URI scheme.</returns>
    HttpWebRequest CreateRequest(Uri requestUri)
    {
      var request = WebRequest.Create(requestUri) as HttpWebRequest;

      request.Accept = "*/*";
      request.AllowAutoRedirect = false;
      request.CookieContainer = this.CookieContainer;
      request.Headers.Add("Accept-Language", "en-US,en;q=0.5");
      request.Headers.Add("Accept-Encoding", "gzip");
      request.Host = requestUri.Host + ":" + requestUri.Port;
      request.KeepAlive = true;
      request.ProtocolVersion = HttpVersion.Version11;
      request.ServicePoint.Expect100Continue = false;
      request.UserAgent = this.UserAgent;

      return request;
    }

    /// <summary>
    /// Store new cookie to cookie containter
    /// </summary>
    /// <param name="cookies"></param>
    void StoreCookie(CookieCollection cookies)
    {
      if (cookies != null && cookies.Count > 0)
        this.CookieContainer.Add(cookies);
    }
  }
}
