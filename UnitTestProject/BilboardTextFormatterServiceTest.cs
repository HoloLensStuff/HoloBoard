using Assets.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class BilboardTextFormatterServiceTest
    {
        private BilboardTextFormatterService _bilboardTextFormatterService;

        [TestInitialize]
        public void Initialize()
        {
            _bilboardTextFormatterService = new BilboardTextFormatterService();
        }

        [TestMethod]
        public void Format_WhenInputIsEmptyString_ReturnEmptyString()
        {
            // Arrange
            var input = "";
            var expected = "";

            // Act
            var result = _bilboardTextFormatterService.Format(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Format_WhenInputIsStringLesserThan10Characters_ReturnInputString()
        {
            // Arrange
            var input = "Igor Igor";
            var expected = "Igor Igor";

            // Act
            var result = _bilboardTextFormatterService.Format(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Format_WhenInputIsStringBetween10And20Characters_ReturnInputString()
        {
            // Arrange
            var input = "Igor Igor Igor Igor";
            var expected = "Igor Igor Igor Igor";

            // Act
            var result = _bilboardTextFormatterService.Format(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Format_WhenInputIsStringBetween20And30Characters_ReturnInputString()
        {
            // Arrange
            var input = "Igor Igor Igor Igor Igor Igor";
            var expected = "Igor Igor Igor Igor Igor Igor";

            // Act
            var result = _bilboardTextFormatterService.Format(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Format_WhenInputIsStringGreaterThan30Characters_ReturnFormatedInputString30CharactersPerLine()
        {
            // Arrange
            var input = "Igor Igor Igor Igor Igor Igor Igor Igor";
            var expected = "Igor Igor Igor Igor Igor Igor\r\nIgor Igor";

            // Act
            var result = _bilboardTextFormatterService.Format(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Format_WhenInputIsStringGreaterThan60Characters_ReturnFormatedInputString30CharactersPerLine()
        {
            // Arrange
            var input = "Hello my name is Igor, I am a .NET developer. These tests are written not for me but for the next user that will debug his way into the application. I still need to add few more lines here in order to complete the test.";
            var expected = "Hello my name is Igor, I am a\r\n.NET developer. These tests\r\nare written not for me but for\r\nthe next user that will debug\r\nhis way into the application.\r\nI still need to add few more\r\nlines here in order to\r\ncomplete the test.";

            // Act
            var result = _bilboardTextFormatterService.Format(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
