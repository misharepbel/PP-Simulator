using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    // Tests for Limiter
    [Theory]
    [InlineData(5, 1, 10, 5)]    // Within range
    [InlineData(-5, 1, 10, 1)]   // Below minimum
    [InlineData(15, 1, 10, 10)]  // Above maximum
    [InlineData(1, 1, 10, 1)]    // On minimum boundary
    [InlineData(10, 1, 10, 10)]  // On maximum boundary
    public void Limiter_ReturnsCorrectValue(int value, int min, int max, int expected)
    {
        // Act
        int result = Validator.Limiter(value, min, max);

        // Assert
        Assert.Equal(expected, result);
    }

    // Tests for Shortener
    [Theory]
    [InlineData("Hello World", 5, 10, '*', "Hello Worl")] // Truncated to max
    [InlineData("Hi", 5, 10, '*', "Hi***")]              // Padded to min
    [InlineData("  Test  ", 5, 10, '*', "Test*")]        // Trimmed, padded
    [InlineData("lowercase", 5, 10, '-', "Lowercase")]   // Capitalized first char
    [InlineData("   short   ", 5, 10, '-', "Short")]     // Trimmed and within range
    [InlineData("ExactlyTen", 5, 10, '#', "ExactlyTen")] // Exactly max length
    [InlineData("երբեք չեմ հրաժարվի քեզնից", 5, 19, '#', "Երբեք չեմ հրաժարվի")] // Armenian, capitalized, trimmed to max, then trimmed spaces
    [InlineData("ħ                  ż", 7, 15, '^', "Ħ^^^^^^")] // Maltese, capitalized, trimmed to max, trimmed spaces, and padded
    public void Shortener_ReturnsCorrectValue(string value, int min, int max, char placeholder, string expected)
    {
        // Act
        string result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Shortener_EmptyString_ReturnsPlaceholderString()
    {
        // Arrange
        string value = "";
        int min = 5;
        int max = 10;
        char placeholder = '#';

        // Act
        string result = Validator.Shortener(value, min, max, placeholder);

        // Assert
        Assert.Equal("#####", result); // Padded to minimum length
    }
}
