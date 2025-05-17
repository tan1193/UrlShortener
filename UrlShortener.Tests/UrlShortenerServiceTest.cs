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
            Assert.True(service.Test1() == 1);
        }


        [Fact]
        public void TestFunc2()
        {
            var service = new UrlShortenerService();
            Assert.True(service.Test2() == 2);
        }
    }
}
