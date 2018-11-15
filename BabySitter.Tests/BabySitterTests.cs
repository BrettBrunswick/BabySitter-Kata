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




        #region Validate Format of Time Input

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat1_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("24:00"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat2_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("12:00:00"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat3_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("12"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat4_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("04"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat5_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("24"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat6_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("25"));
        }


        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat7_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("12000000"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat8_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("2:0"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat9_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("13:29 pm"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithInCorrectFormat10_ShouldReturnFalse()
        {
            Assert.False(_service.IsInputTimeFormatValid("12:60 pm"));
        }


        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat1_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("12:00"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat2_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("23:59"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat3_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("1:00"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat4_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("10:10"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat5_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("03:29"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat6_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("03:29 AM"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat7_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("03:29 pm"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat8_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("03:29am"));
        }

        [Fact]
        public void WhenAStartTimeOrEndTimeIsPassedWithCorrectFormat9_ShouldReturnTrue()
        {
            Assert.True(_service.IsInputTimeFormatValid("1:29 pm"));
        }

        #endregion





        #region Validate Start/End Time Business Rules


        // Validate Start Time.

        [Fact]
        public void WhenAStartTimeIsPassedAndIsAfterEarliestStart_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(17, 00, 00);
            Assert.True(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsAfterEarliestStart2_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(17, 01, 00);
            Assert.True(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsAfterEarliestStart3_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(19, 00, 00);
            Assert.True(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsAfterEarliestStart4_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(23, 55, 00);
            Assert.True(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsAfterEarliestStart5_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(2, 55, 00);
            Assert.True(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsBeforeEarliestStart_ShouldReturnFalse()
        {
            TimeSpan startTime = new TimeSpan(16, 59, 00);
            Assert.False(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsBeforeEarliestStart1_ShouldReturnFalse()
        {
            TimeSpan startTime = new TimeSpan(14, 55, 00);
            Assert.False(_service.IsStartTimeValid(startTime));
        }

        [Fact]
        public void WhenAStartTimeIsPassedAndIsBeforeEarliestStart2_ShouldReturnFalse()
        {
            TimeSpan startTime = new TimeSpan(12, 55, 00);
            Assert.False(_service.IsStartTimeValid(startTime));
        }


        //Validate End Time.

        [Fact]
        public void WhenAEndTimeIsPassedAndIsBeforeLatestEnd_ShouldReturnTrue()
        {
            TimeSpan endTime = new TimeSpan(3, 59, 00);
            Assert.True(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsBeforeLatestEnd2_ShouldReturnTrue()
        {
            TimeSpan endTime = new TimeSpan(1, 01, 00);
            Assert.True(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsBeforeLatestEnd3_ShouldReturnTrue()
        {
            TimeSpan endTime = new TimeSpan(2, 00, 00);
            Assert.True(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsBeforeLatestEnd4_ShouldReturnTrue()
        {
            TimeSpan endTime = new TimeSpan(3, 55, 00);
            Assert.True(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsBeforeLatestEnd5_ShouldReturnTrue()
        {
            TimeSpan endTime = new TimeSpan(19, 55, 00);
            Assert.True(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsAfterLatestEnd_ShouldReturnFalse()
        {
            TimeSpan endTime = new TimeSpan(4, 01, 00);
            Assert.False(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsAfterLatestEnd1_ShouldReturnFalse()
        {
            TimeSpan endTime = new TimeSpan(6, 55, 00);
            Assert.False(_service.IsEndTimeValid(endTime));
        }

        [Fact]
        public void WhenAEndTimeIsPassedAndIsAfterLatestEnd2_ShouldReturnFalse()
        {
            TimeSpan endTime = new TimeSpan(5, 55, 00);
            Assert.False(_service.IsEndTimeValid(endTime));
        }


        // Validate End Time is not before Start time.

        [Fact]
        public void WhenStartTimeAndEndTimeIsPassedAndEndIsAfterStart_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(17, 00, 00);
            TimeSpan endTime = new TimeSpan(17, 01, 00);
            Assert.True(_service.IsEndTimeAfterStartTime(startTime, endTime));
        }

        [Fact]
        public void WhenStartTimeAndEndTimeIsPassedAndEndIsAfterStart2_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(17, 00, 00);
            TimeSpan endTime = new TimeSpan(20, 01, 00);
            Assert.True(_service.IsEndTimeAfterStartTime(startTime, endTime));
        }

        [Fact]
        public void WhenStartTimeAndEndTimeIsPassedAndEndIsAfterStart3_ShouldReturnTrue()
        {
            TimeSpan startTime = new TimeSpan(17, 00, 00);
            TimeSpan endTime = new TimeSpan(2, 00, 00);
            Assert.True(_service.IsEndTimeAfterStartTime(startTime, endTime));
        }

        [Fact]
        public void WhenStartTimeAndEndTimeIsPassedAndEndIsAfterStart_ShouldReturnFalse()
        {
            TimeSpan startTime = new TimeSpan(17, 00, 00);
            TimeSpan endTime = new TimeSpan(16, 00, 00);
            Assert.False(_service.IsEndTimeAfterStartTime(startTime, endTime));
        }

        [Fact]
        public void WhenStartTimeAndEndTimeIsPassedAndEndIsAfterStart2_ShouldReturnFalse()
        {
            TimeSpan startTime = new TimeSpan(2, 00, 00);
            TimeSpan endTime = new TimeSpan(1, 00, 00);
            Assert.False(_service.IsEndTimeAfterStartTime(startTime, endTime));
        }

        [Fact]
        public void WhenStartTimeAndEndTimeIsPassedAndEndIsAfterStart3_ShouldReturnFalse()
        {
            TimeSpan startTime = new TimeSpan(03, 00, 00);
            TimeSpan endTime = new TimeSpan(02, 59,  00);
            Assert.False(_service.IsEndTimeAfterStartTime(startTime, endTime));
        }

        #endregion





        #region Turn string into TimeSpan

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan_ShouldReturnTrue()
        {
            string time = "17:00";
            TimeSpan shouldBeTime = new TimeSpan(17, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan2_ShouldReturnTrue()
        {
            string time = "7:00";
            TimeSpan shouldBeTime = new TimeSpan(7, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan3_ShouldReturnTrue()
        {
            string time = "7:00 PM";
            TimeSpan shouldBeTime = new TimeSpan(19, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan4_ShouldReturnTrue()
        {
            string time = "1:00 aM";
            TimeSpan shouldBeTime = new TimeSpan(1, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan5_ShouldReturnTrue()
        {
            string time = "08:00 PM";
            TimeSpan shouldBeTime = new TimeSpan(20, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan6_ShouldReturnTrue()
        {
            string time = "6:00am";
            TimeSpan shouldBeTime = new TimeSpan(6, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan7_ShouldReturnTrue()
        {
            string time = "12:00am";
            TimeSpan shouldBeTime = new TimeSpan(0, 00, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        [Fact]
        public void WhenValidStringIsPassedInReturnCorrectTimeSpan8_ShouldReturnTrue()
        {
            string time = "08:21 PM";
            TimeSpan shouldBeTime = new TimeSpan(20, 21, 00);
            Assert.Equal(shouldBeTime, _service.GetTimeSpanFromString(time));
        }

        #endregion





        #region Data Retrieval

        // Validate Family Exists

        [Fact]
        public void WhenPassedAValidFamilyIdIsPassedReturnTrue_ShouldBeTrue()
        {
            string familyId = "A";
            Assert.True(_service.IsValidFamily(familyId));
        }

        [Fact]
        public void WhenPassedAValidFamilyIdIsPassedReturnTrue2_ShouldBeTrue()
        {
            string familyId = "c";
            Assert.True(_service.IsValidFamily(familyId));
        }

        [Fact]
        public void WhenPassedAValidFamilyIdIsPassedReturnTrue3_ShouldBeTrue()
        {
            string familyId = "b";
            Assert.True(_service.IsValidFamily(familyId));
        }

        [Fact]
        public void WhenPassedAValidFamilyIdIsPassedReturnTrue_ShouldBeFalse()
        {
            string familyId = "d";
            Assert.False(_service.IsValidFamily(familyId));
        }

        [Fact]
        public void WhenPassedAValidFamilyIdIsPassedReturnTrue2_ShouldBeFalse()
        {
            string familyId = "AA";
            Assert.False(_service.IsValidFamily(familyId));
        }

        [Fact]
        public void WhenPassedAValidFamilyIdIsPassedReturnTrue3_ShouldBeFalse()
        {
            string familyId = "";
            Assert.False(_service.IsValidFamily(familyId));
        }

        //Given a Family ID Calculate Earnings

        [Fact]
        public void WhenPassedAFamilyAndStartAndEndTimeReturnEarnings_ShouldBe35()
        {
            string familyId = "A";
            TimeSpan startTime = new TimeSpan(22, 00, 00);
            TimeSpan endTime = new TimeSpan(0, 00, 00);
            Assert.Equal(35.0, _service.GetTotalEarnings(familyId, startTime, endTime));
        }

        #endregion


    }

}
