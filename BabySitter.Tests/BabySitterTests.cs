using System;
using Xunit;
using BabySitter.App;

namespace BabySitter.Tests
{
    public class BabySitterTests
    {
        private readonly BabySitterService _service;

        public BabySitterTests()
        {
            _service = new BabySitterService();
        }

        [Fact]
        public void Test1()
        {
            Assert.Equal(2, _service.GetNumberTwo());
        }

    }

}
