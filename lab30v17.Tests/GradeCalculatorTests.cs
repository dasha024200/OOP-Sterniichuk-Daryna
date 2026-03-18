using System;
using System.Collections.Generic;
using Xunit;
using lab30v17;

namespace lab30v17.Tests
{
    public class GradeCalculatorTests
    {
        private readonly GradeCalculator _calculator;

        public GradeCalculatorTests()
        {
            _calculator = new GradeCalculator();
        }

        [Fact]
        public void CalculateGPA_ShouldReturn4_WhenAverageIs90OrMore()
        {
            var grades = new List<int> { 95, 90, 100 };

            double result = _calculator.CalculateGPA(grades);

            Assert.Equal(4.0, result);
        }

        [Fact]
        public void CalculateGPA_ShouldReturn3_WhenAverageIs80To89()
        {
            var grades = new List<int> { 80, 85, 89 };

            double result = _calculator.CalculateGPA(grades);

            Assert.Equal(3.0, result);
        }

        [Fact]
        public void CalculateGPA_ShouldReturn2_WhenAverageIs70To79()
        {
            var grades = new List<int> { 70, 75, 79 };

            double result = _calculator.CalculateGPA(grades);

            Assert.Equal(2.0, result);
        }

        [Fact]
        public void CalculateGPA_ShouldReturn1_WhenAverageIs60To69()
        {
            var grades = new List<int> { 60, 65, 69 };

            double result = _calculator.CalculateGPA(grades);

            Assert.Equal(1.0, result);
        }

        [Fact]
        public void CalculateGPA_ShouldReturn0_WhenAverageIsBelow60()
        {
            var grades = new List<int> { 40, 50, 59 };

            double result = _calculator.CalculateGPA(grades);

            Assert.Equal(0.0, result);
        }

        [Fact]
        public void CalculateGPA_ShouldThrowArgumentNullException_WhenGradesIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _calculator.CalculateGPA(null));
        }

        [Fact]
        public void CalculateGPA_ShouldThrowArgumentException_WhenGradesListIsEmpty()
        {
            var grades = new List<int>();

            Assert.Throws<ArgumentException>(() => _calculator.CalculateGPA(grades));
        }

        [Fact]
        public void CalculateGPA_ShouldThrowArgumentOutOfRangeException_WhenGradeIsLessThanZero()
        {
            var grades = new List<int> { 90, -5, 80 };

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateGPA(grades));
        }

        [Fact]
        public void CalculateGPA_ShouldThrowArgumentOutOfRangeException_WhenGradeIsGreaterThan100()
        {
            var grades = new List<int> { 90, 105, 80 };

            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateGPA(grades));
        }

        [Theory]
        [InlineData(95, "A")]
        [InlineData(90, "A")]
        [InlineData(85, "B")]
        [InlineData(80, "B")]
        [InlineData(75, "C")]
        [InlineData(70, "C")]
        [InlineData(65, "D")]
        [InlineData(60, "D")]
        [InlineData(50, "F")]
        [InlineData(0, "F")]
        public void GetLetterGrade_ShouldReturnCorrectLetter(int grade, string expected)
        {
            string result = _calculator.GetLetterGrade(grade);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(101)]
        public void GetLetterGrade_ShouldThrowArgumentOutOfRangeException_ForInvalidGrade(int grade)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.GetLetterGrade(grade));
        }
    }
}