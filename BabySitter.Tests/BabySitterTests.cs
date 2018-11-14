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

        [Fact]
        public void WhenAFractionalTimeRangeIsPassedReturnsNumberOfHoursWorked_ShouldRoundUpAndBe4()
        {
            TimeSpan startTime = new TimeSpan(17,01,00);
            TimeSpan endTime = new TimeSpan(21,00,00);
            Assert.Equal(4, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

        [Fact]
        public void WhenAFractionalTimeRangeIsPassedReturnsNumberOfHoursWorked_ShouldRoundUpAndBe5()
        {
            TimeSpan startTime = new TimeSpan(17,29,00);
            TimeSpan endTime = new TimeSpan(22,00,00);
            Assert.Equal(5, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

        [Fact]
        public void WhenAFractionalTimeRangeIsPassedReturnsNumberOfHoursWorked_ShouldRoundUpAndBe4_2()
        {
            TimeSpan startTime = new TimeSpan(17,31,00);
            TimeSpan endTime = new TimeSpan(22,00,00);
            Assert.Equal(4, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

    }

}
