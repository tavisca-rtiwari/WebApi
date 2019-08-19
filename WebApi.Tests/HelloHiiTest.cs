using System;
using Xunit;
using WebApi.Controllers;
namespace WebApi.Tests
{
    public class HelloHiiTest
    {
        [Fact]
        public void Test_Get_Hello()
        {
            var HelloHiiController = new HelloHiiController();
            Assert.Equal("Hii", HelloHiiController.Get("Hello"));
        }
        [Fact]
        public void Test_Get_Hii()
        {
            var controllerHello = new HelloHiiController();
            Assert.Equal("Hello", controllerHello.Get("Hii"));
        }
        [Fact]
        public void Test_Get()
        {
            var controllerHello = new HelloHiiController();
            Assert.Equal("Something went wrong", controllerHello.Get());
        }
    }
}
