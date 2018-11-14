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
        public void WhenATimeRangeIsPassedReturnsNumberOfHoursWorked_ShouldBe3()
        {
            TimeSpan startTime = new TimeSpan(17,00,00);
            TimeSpan endTime = new TimeSpan(20,00,00);
            Assert.Equal(3, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

    }

}
