namespace OptLabsTest;

public class MidpointSearchTests
{
    [Theory(DisplayName = "Поиск средней точкой если стационарная в пределах интервала")]
    [InlineData(-1, 1, 1e-3)]
    [InlineData(-1.1, 1, 1e-3)]
    [InlineData(-1.03, 1, 1e-3)]
    public void Test1(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon);
        Assert.Multiple(
            () => Assert.Equal(.42241, result.MinX, epsilon),
            () => Assert.Equal(.46004, result.FunX, epsilon));
    }

    [Theory(DisplayName = "Поиск средней точкой если стационарная за пределами интервала слева")]
    [InlineData(0.5, 1, 1e-3)]
    public void Test2(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon);
        Assert.Equal(leftInterval, result.MinX, epsilon);
    }

    [Theory(DisplayName = "Поиск средней точкой если стационарная за пределами интервала справа")]
    [InlineData(-1, 0, 1e-3)]
    public void Test3(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon);
        Assert.Equal(rightInterval, result.MinX, epsilon);
    }
}