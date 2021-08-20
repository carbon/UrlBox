using System;

using Xunit;

namespace UrlBox.Tests
{
    public class ScreenshotRequestTests
    {
        [Fact]
        public void Serialize1()
        {
            var request = new ScreenshotRequest(new Uri("https://google.com/"));

            Assert.Equal("?url=https%3A%2F%2Fgoogle.com%2F", request.ToQueryString());

            var parameters = request.GetParameters();

            Assert.Single(parameters);
        }

        [Fact]
        public void Serialize2()
        {
            var request = new ScreenshotRequest(new Uri("https://google.com/")) { FullPage = true };

            Assert.Equal("?url=https%3A%2F%2Fgoogle.com%2F&full_page=true", request.ToQueryString());
        }

        [Fact]
        public void Serialize3()
        {
            var request = new ScreenshotRequest(new Uri("https://google.com/")) { 
                UserAgent = "a", 
                FullPage = false, 
                Timeout = TimeSpan.FromSeconds(30) 
            };

            Assert.Equal("?url=https%3A%2F%2Fgoogle.com%2F&full_page=false&user_agent=a&timeout=30000", request.ToQueryString());
        }
    }
}