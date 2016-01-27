using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TPIA.Common.Adaptor
{
    public class TLApiAdaptor : IWebApiAdaptor
    {
        #region 成員
        private string _TLUrl = string.Empty;
        private HttpClient _httpClient = null;
        #endregion

        #region 屬性
        private HttpClient Client
        {
            get
            {
                if (_httpClient != null)
                    return _httpClient;

                _httpClient = new HttpClient();

                _TLUrl = "http://localhost:1541/";
                //_TLUrl = ConfigurationManager.AppSettings["WebAPIUrl_TL"];

                _httpClient.BaseAddress = new Uri(_TLUrl);
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return _httpClient;
            }
        }
        #endregion

        #region IWebApiAdaptor<T> 成員

        public To Get<To>(string uri)
        {
            To result;
            HttpResponseMessage msg = null;

            msg = Client.GetAsync(uri).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            result = msg.Content.ReadAsAsync<To>().Result;

            return result;
        }

        public To GetByValidate<To>(string uri, string ClubOneToken, string UID)
        {
            To result;
            HttpResponseMessage msg = null;

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("ClubOneToken", ClubOneToken);
            Client.DefaultRequestHeaders.Add("UID", UID);

            msg = Client.GetAsync(uri).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            result = msg.Content.ReadAsAsync<To>().Result;

            return result;
        }

        public To Post<Ti,To>(string uri, Ti obj)
        {
            To result = default(To);
            HttpResponseMessage msg = null;

            msg = Client.PostAsJsonAsync<Ti>(uri, obj).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            result = msg.Content.ReadAsAsync<To>().Result;

            return result;
        }

        public To PostByValidate<Ti, To>(string uri, Ti obj, string ClubOneToken, string UID)
        {
            To result = default(To);
            HttpResponseMessage msg = null;

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("ClubOneToken", ClubOneToken);
            Client.DefaultRequestHeaders.Add("UID", UID);

            msg = Client.PostAsJsonAsync<Ti>(uri, obj).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            result = msg.Content.ReadAsAsync<To>().Result;

            return result;
        }

        public To Put<Ti,To>(string uri, Ti obj)
        {
            To result = default(To);
            HttpResponseMessage msg = null;

            msg = Client.PutAsJsonAsync<Ti>(uri, obj).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            result = msg.Content.ReadAsAsync<To>().Result;

            return result;
        }

        public To PutByValidate<Ti, To>(string uri, Ti obj, string ClubOneToken, string UID)
        {
            To result = default(To);
            HttpResponseMessage msg = null;

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("ClubOneToken", ClubOneToken);
            Client.DefaultRequestHeaders.Add("UID", UID);

            msg = Client.PutAsJsonAsync<Ti>(uri, obj).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            result = msg.Content.ReadAsAsync<To>().Result;

            return result;
        }

        public To Delete<To>(string uri)
        {
            To result = default(To);
            HttpResponseMessage msg = null;

            msg = Client.DeleteAsync(uri).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            return result;
        }

        public To DeleteByValidate<To>(string uri, string ClubOneToken, string UID)
        {
            To result = default(To);
            HttpResponseMessage msg = null;

            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("ClubOneToken", ClubOneToken);
            Client.DefaultRequestHeaders.Add("UID", UID);

            msg = Client.DeleteAsync(uri).Result;
            if (!msg.IsSuccessStatusCode)
                throw new Exception(msg.Content.ReadAsStringAsync().Result);

            return result;
        }

        #endregion
    }
}
