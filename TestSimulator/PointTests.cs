using Simulator;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_InitializesCoordinatesCorrectly()
    {
        // Arrange
        int x = 5, y = 10;

        // Act
        var point = new Point(x, y);

        // Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Fact]
    public void ToString_ReturnsCorrectFormat()
    {
        // Arrange
        var point = new Point(3, 7);

        // Act
        string result = point.ToString();

        // Assert
        Assert.Equal("(3, 7)", result);
    }

    [Theory]
    [InlineData(Direction.Left, -1, 0)]
    [InlineData(Direction.Right, 1, 0)]
    [InlineData(Direction.Up, 0, 1)]
    [InlineData(Direction.Down, 0, -1)]
    public void Next_ReturnsCorrectPoint(Direction direction, int dx, int dy)
    {
        // Arrange
        var point = new Point(10, 20);

        // Act
        var result = point.Next(direction);

        // Assert
        Assert.Equal(10 + dx, result.X);
        Assert.Equal(20 + dy, result.Y);
    }

    [Theory]
    [InlineData(Direction.Left, -1, 1)]
    [InlineData(Direction.Right, 1, -1)]
    [InlineData(Direction.Up, 1, 1)]
    [InlineData(Direction.Down, -1, -1)]
    public void NextDiagonal_ReturnsCorrectPoint(Direction direction, int dx, int dy)
    {
        // Arrange
        var point = new Point(15, 25);

        // Act
        var result = point.NextDiagonal(direction);

        // Assert
        Assert.Equal(15 + dx, result.X);
        Assert.Equal(25 + dy, result.Y);
    }

    [Fact]
    public void Next_InvalidDirection_ReturnsDefault()
    {
        // Arrange
        var point = new Point(5, 5);

        // Act
        var result = point.Next((Direction)6);

        // Assert
        Assert.Equal(default, result);
    }

    [Fact]
    public void NextDiagonal_InvalidDirection_ReturnsDefault()
    {
        // Arrange
        var point = new Point(5, 5);

        // Act
        var result = point.NextDiagonal((Direction)999);

        // Assert
        Assert.Equal(default, result);
    }
}