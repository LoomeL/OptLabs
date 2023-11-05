namespace OptLabsTest;

public class MidpointSearchTests
{
    [Theory(DisplayName = "f(x)=x ")]
    [InlineData(-1, 1, 1e-3)]
    [InlineData(-1.1, 1, 1e-3)]
    [InlineData(-1.03, 1, 1e-3)]
    public void Test1(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon, AbstractSearch.FunctionX);
        Assert.Multiple(
            () => Assert.Equal(leftInterval, result.MinX, epsilon),
            () => Assert.Equal(leftInterval, result.FunX, epsilon));
    }

    [Theory(DisplayName = "f(x)=-x ")]
    [InlineData(-1, 1, 1e-3)]
    [InlineData(-1, 1.1, 1e-3)]
    [InlineData(-1, 1.03, 1e-3)]
    public void Test2(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon, AbstractSearch.FunctionNegativeX);
        Assert.Multiple(
            () => Assert.Equal(rightInterval, result.MinX, epsilon),
            () => Assert.Equal(-rightInterval, result.FunX, epsilon));
    }

    [Theory(DisplayName = "12 вариант ")]
    [InlineData(-1, 1, 1e-3)]
    [InlineData(-1.1, 1, 1e-3)]
    [InlineData(-1.03, 1, 1e-3)]
    public void Test3(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new MidPointSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon, search.Function);
        Assert.Multiple(
            () => Assert.Equal(.42241, result.MinX, epsilon),
            () => Assert.Equal(.46004, result.FunX, epsilon));
    }
}