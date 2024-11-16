using Simulator;

namespace TestSimulator;

using System;
using Xunit;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_CreatesRectangle()
    {
        // Arrange
        int x1 = 2, y1 = 3, x2 = 5, y2 = 6;

        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_CoordinatesSwapped_CorrectlyReordersCoordinates()
    {
        // Arrange
        int x1 = 5, y1 = 6, x2 = 2, y2 = 3;

        // Act
        var rectangle = new Rectangle(x1, y1, x2, y2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_InvalidRectangle_ThrowsArgumentException()
    {
        // Arrange
        int x1 = 3, y1 = 3, x2 = 3, y2 = 7; // Line, not rectangle

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
        Assert.Equal("Couldn't create rectangle. It's flat in at least one dimension.", ex.Message);
    }

    [Fact]
    public void Constructor_UsingPoints_InitializesRectangle()
    {
        // Arrange
        var p1 = new Point(2, 3);
        var p2 = new Point(5, 6);

        // Act
        var rectangle = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_UsingPoints_CoordinatesSwapped_CorrectlyReordersCoordinates()
    {
        // Arrange
        var p1 = new Point(2, 6);
        var p2 = new Point(5, 3);

        // Act
        var rectangle = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(2, rectangle.X1);
        Assert.Equal(3, rectangle.Y1);
        Assert.Equal(5, rectangle.X2);
        Assert.Equal(6, rectangle.Y2);
    }

    [Fact]
    public void Constructor_UsingPoints_InvalidRectangle_ThrowsArgumentException()
    {
        // Arrange
        var p1 = new Point(7, 30);  // Line, 
        var p2 = new Point(20, 30); // not rectangle

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => new Rectangle(p1, p2));
        Assert.Equal("Couldn't create rectangle. It's flat in at least one dimension.", ex.Message);
    }

    [Theory]
    [InlineData(3, 4, true)]  // Inside rectangle
    [InlineData(2, 3, true)]  // On bottom-left corner
    [InlineData(5, 6, true)]  // On top-right corner
    [InlineData(3, 3, true)]  // On the bottom line
    [InlineData(5, 4, true)]  // On the right line
    [InlineData(1, 4, false)] // Outside to the left
    [InlineData(6, 4, false)] // Outside to the right
    [InlineData(3, 7, false)] // Outside above
    [InlineData(3, 2, false)] // Outside below
    public void Contains_ChecksPointContainment(int px, int py, bool expected)
    {
        // Arrange
        var rectangle = new Rectangle(2, 3, 5, 6);
        var point = new Point(px, py);

        // Act
        bool result = rectangle.Contains(point);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        // Arrange
        var rectangle = new Rectangle(2, 3, 5, 6);

        // Act
        string result = rectangle.ToString();

        // Assert
        Assert.Equal("(2, 3):(5, 6)", result);
    }
}

