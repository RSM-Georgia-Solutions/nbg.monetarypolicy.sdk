using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nbg.monetarypolicy.sdk
{
    public interface IExchangeRateService
    {
        /// <summary>
        /// აბრუნებს ლარის მიმართ უცხოური ვალუტების გაცვლის ოფიციალურ კურსებს
        /// </summary>
        /// <returns></returns>
        public Currencies GetCurrencies();
        /// <summary>
        /// აბრუნებს ლარის მიმართ უცხოური ვალუტის გაცვლის ოფიციალურ კურსს
        /// </summary>
        /// <param name="currencyEnum"></param>
        /// <returns></returns>
        public Currencies GetCurrencies(CurrencyEnum currencyEnum);
        /// <summary>
        /// აბრუნებს ლარის მიმართ უცხოური ვალუტების გაცვლის ოფიციალურ კურსებს, მითითებული თარიღისთვის
        /// </summary>
        /// <param name="dateTime">კურსის გამოცხადების თარიღი</param>
        /// <returns></returns>
        public Currencies GetCurrencies(DateTime dateTime);
        /// <summary>
        /// აბრუნებს ლარის მიმართ უცხოური ვალუტების გაცვლის ოფიციალურ კურსებს, მითითებული თარიღისთვის და ვალუტისთვის
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="currencyEnum"></param>
        /// <returns></returns>
        public Currencies GetCurrencies(DateTime dateTime, CurrencyEnum currencyEnum);
    }
}
