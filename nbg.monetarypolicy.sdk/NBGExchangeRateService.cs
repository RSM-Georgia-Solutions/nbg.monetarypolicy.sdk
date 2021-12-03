using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace nbg.monetarypolicy.sdk
{
    public class NBGExchangeRateService : IExchangeRateService
    {
        private readonly string _serviceUrl;

        public NBGExchangeRateService(string serviceUrl = "https://nbg.gov.ge/gw/api/ct/monetarypolicy/currencies")
        {
            _serviceUrl = serviceUrl;
        }

        public Currencies GetCurrencies()
        {
            WebRequest webRequest = WebRequest.Create(_serviceUrl);
            return sendRequest(webRequest);
        }

        public Currencies GetCurrencies(CurrencyEnum currencyEnum)
        {
            WebRequest webRequest = WebRequest.Create($"{_serviceUrl}/?currencies={currencyEnum}");
            return sendRequest(webRequest);
        }

        public Currencies GetCurrencies(DateTime dateTime)
        {
            WebRequest webRequest = WebRequest.Create($"{_serviceUrl}/?&date={formatDate(dateTime)}");
            return sendRequest(webRequest);
        }

        public Currencies GetCurrencies(DateTime dateTime, CurrencyEnum currencyEnum)
        {
            WebRequest webRequest = WebRequest.Create($"{_serviceUrl}/?currencies={currencyEnum}&date={formatDate(dateTime)}");
            return sendRequest(webRequest);
        }
        private static Currencies sendRequest(WebRequest webRequest)
        {
            HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

            if (response.StatusDescription == "OK")
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();

                return JsonConvert.DeserializeObject<Currencies[]>(responseFromServer).FirstOrDefault();
            }

            throw new Exception(response.StatusDescription);
        }

        public Currencies GetCurrencies(string currencyCode)
        {
            WebRequest webRequest = WebRequest.Create($"{_serviceUrl}/?currencies={currencyCode}");
            return sendRequest(webRequest);
        }

        public Currencies GetCurrencies(DateTime dateTime, string currencyCode)
        {
            WebRequest webRequest = WebRequest.Create($"{_serviceUrl}/?currencies={currencyCode}&date={formatDate(dateTime)}");
            return sendRequest(webRequest);
        }

        private string formatDate(DateTime dateTime)
        {
            return dateTime.AddDays(-1).ToString("yyyy-MM-dd");
        }
    }
}
