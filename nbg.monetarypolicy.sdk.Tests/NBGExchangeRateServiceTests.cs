using System;
using System.Linq;
using Xunit;

namespace nbg.monetarypolicy.sdk.Tests
{
    public class NBGExchangeRateServiceTests
    {
        public IExchangeRateService exchangeRateService { get; set; }

        public NBGExchangeRateServiceTests()
        {
            exchangeRateService = new NBGExchangeRateService();
        }

        [Fact]
        public void GetCurrenciesTest()
        {
            var res = exchangeRateService.GetCurrencies();
            Assert.True(res.date == DateTime.Today);
            Assert.NotEmpty(res.currencies);
        }

        [Fact]
        public void GetCurrenciesSingleCurrencyTest()
        {
            var res = exchangeRateService.GetCurrencies(CurrencyEnum.USD);
            Assert.True(res.date == DateTime.Today);
            Assert.NotEmpty(res.currencies);
            Assert.True(res.currencies.First().code == "USD");
        }

        [Fact]
        public void GetCurrenciesSingleCurrencyWithStringCodeTest()
        {
            var res = exchangeRateService.GetCurrencies("USD");
            Assert.True(res.date == DateTime.Today);
            Assert.NotEmpty(res.currencies);
            Assert.True(res.currencies.First().code == "USD");
        }

        [Fact]
        public void GetCurrenciesSingleCurrencyWithDateTest()
        {
            var res = exchangeRateService.GetCurrencies(DateTime.Now.AddDays(-5), CurrencyEnum.USD);
            Assert.True(res.currencies.First().validFromDate == DateTime.Today.AddDays(-6));
            Assert.NotEmpty(res.currencies);
            Assert.True(res.currencies.First().code == "USD");
        }

        [Fact]
        public void GetCurrenciesSingleCurrencyWithDateAndCurrencyCodeTest()
        {
            var res = exchangeRateService.GetCurrencies(DateTime.Now.AddDays(-5), "USD");
            Assert.True(res.currencies.First().validFromDate == DateTime.Today.AddDays(-6));
            Assert.NotEmpty(res.currencies);
            Assert.True(res.currencies.First().code == "USD");
        }


        [Fact]
        public void GetCurrenciesWithDateTest()
        {
            var date = DateTime.Now.AddDays(-5);
            var res = exchangeRateService.GetCurrencies(date);
            Assert.True(res.currencies.All(x => x.validFromDate.Date == date.AddDays(-1).Date));
        }

    }
}
