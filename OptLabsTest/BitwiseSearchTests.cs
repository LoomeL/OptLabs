namespace OptLabsTest;

public class BitwiseSearchTests
{
    [Theory(DisplayName = "f(x)=x ")]
    [InlineData(2, 4, 1e-3)]
    [InlineData(2.1, 4, 1e-3)]
    [InlineData(2.03, 4, 1e-3)]
    public void Test1(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new BitwiseSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon, search.FunctionX);
        Assert.Multiple(
            () => Assert.Equal(leftInterval, result.MinX, epsilon),
            () => Assert.Equal(leftInterval, result.FunX, epsilon));
    }

    [Theory(DisplayName = "f(x)=-x ")]
    [InlineData(2, 4, 1e-3)]
    [InlineData(2, 4.1, 1e-3)]
    [InlineData(2, 4.03, 1e-3)]
    public void Test2(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new BitwiseSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon, search.FunctionNegativeX);
        Assert.Multiple(
            () => Assert.Equal(rightInterval, result.MinX, epsilon),
            () => Assert.Equal(-rightInterval, result.FunX, epsilon));
    }

    [Theory(DisplayName = "12 вариант ")]
    [InlineData(2, 4, 1e-3)]
    [InlineData(2.1, 4, 1e-3)]
    [InlineData(2.03, 4, 1e-3)]
    public void Test3(double leftInterval, double rightInterval, double epsilon)
    {
        var search = new BitwiseSearch();
        var result = search.Search(leftInterval, rightInterval, epsilon, search.Function);
        Assert.Multiple(
            () => Assert.Equal(2.49999993353737, result.MinX, epsilon),
            () => Assert.Equal(.185695338177052, result.FunX, epsilon));
    }
}