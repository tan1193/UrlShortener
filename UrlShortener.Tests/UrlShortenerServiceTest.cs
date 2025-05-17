using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Services;

namespace UrlShortener.Tests
{
    public class UrlShortenerServiceTest
    {
        [Fact]
        public void TestFunc()
        {
            var service = new UrlShortenerService();
            Assert.True(service.Test() == 1);
        }
    }
}
