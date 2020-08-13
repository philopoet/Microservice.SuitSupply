namespace Suitsupply.Framework.Web.Utilities
{
    public interface IApiClient
    {
        int TimeOut { get; set; }
        string BaseUrl { get; set; }
        void Post(string url, object input);
        TOutput Post<TOutput>(string url, object input);

        string Get(string url, object input);
        TOutput Get<TOutput>(string url, object input);
        TOutput Get<TOutput>(string url);


        void Put(string url, object input);
        TOutput Put<TOutput>(string url, object input);

    }
}
