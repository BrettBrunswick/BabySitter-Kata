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


        #region Get Hours Worked

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

        [Fact]
        public void WhenAFractionalTimeRangeIsPassedReturnsNumberOfHoursWorked_ShouldRoundDownAndBe3()
        {
            TimeSpan startTime = new TimeSpan(20,30,01);
            TimeSpan endTime = new TimeSpan(24,00,00);
            Assert.Equal(3, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

        [Fact]
        public void WhenATimeRangeIsPassedWithEndTimeTheNextDayReturnsNumberOfHoursWorked_ShouldBe2()
        {
            TimeSpan startTime = new TimeSpan(23,00,00);
            TimeSpan endTime = new TimeSpan(1,00,00);
            Assert.Equal(2, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

        [Fact]
        public void WhenATimeRangeIsPassedWithEndTimeTheNextDayReturnsNumberOfHoursWorked_ShouldBe5()
        {
            TimeSpan startTime = new TimeSpan(23,30,00);
            TimeSpan endTime = new TimeSpan(4,00,00);
            Assert.Equal(5, _service.GetNumberOfHoursWorked(startTime, endTime));
        }

        #endregion


        #region Accept Correctly Formatted Time Input

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("12:00:00"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat2_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("12"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat3_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("12:00"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat4_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("04"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat5_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("24"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("25"));
        }


        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat2_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("12000000"));
        }



        #endregion


    }

}
