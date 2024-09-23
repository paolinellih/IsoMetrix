using System;
using Xunit;
using StringCalculator;

public class StringCalculatorTests
{
    private readonly IStringCalculator _calculator;
    private readonly string negativeErrorMessage = "Negatives not allowed: ";

    public StringCalculatorTests()
    {
        _calculator = new StringCalculatorService();
    }

    [Fact]
    public void Add_EmptyString_ReturnsZero()
    {
        Assert.Equal(0, _calculator.Add(""));
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("1,2", 3)]
    public void Add_SingleOrTwoNumbers_ReturnsSum(string input, int expected)
    {
        Assert.Equal(expected, _calculator.Add(input));
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("4,5,6,7", 22)]
    public void Add_MultipleNumbers_ReturnsSum(string input, int expected)
    {
        Assert.Equal(expected, _calculator.Add(input));
    }

    [Theory]
    [InlineData("1\n2,3", 6)]
    [InlineData("4\n5\n6", 15)]
    public void Add_NumbersWithNewLines_ReturnsSum(string input, int expected)
    {
        Assert.Equal(expected, _calculator.Add(input));
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//|\n1|2|3", 6)]
    public void Add_CustomDelimiter_ReturnsSum(string input, int expected)
    {
        Assert.Equal(expected, _calculator.Add(input));
    }

    [InlineData("//[*][%]\n1*2%3", 6)]
    [InlineData("//[***]***2***3", 6)]
    [InlineData("//[***][%%%]\n1***2%%%3", 6)]
    [InlineData("//[***]\n1***2", 3)]

    public void Add_AnyLengthDelimiter_ReturnsSum(string input, int expected)
    {
        Assert.Equal(expected, _calculator.Add(input));
    }

    [Theory]
    [InlineData("-1,2", "-1")]
    [InlineData("2,-4,3,-5", "-4,-5")]
    public void Add_NegativeNumbers_ThrowsException(string input, string expectedMessage)
    {
        var exception = Assert.Throws<ArgumentException>(() => _calculator.Add(input));
        Assert.Equal(negativeErrorMessage + expectedMessage, exception.Message);
    }

    [Theory]
    [InlineData("2,1001", 2)]
    [InlineData("1000,999", 1999)]
    public void Add_NumbersBiggerThan1000_IgnoredInSum(string input, int expected)
    {
        Assert.Equal(expected, _calculator.Add(input));
    }
}