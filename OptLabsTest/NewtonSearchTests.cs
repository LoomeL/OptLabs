namespace OptLabsTest;

public class NewtonSearchTests
{
    [Theory(DisplayName = "Поиск методом ньютона")]
    [InlineData(-200, 1e-3)]
    [InlineData(-1, 1e-3)]
    [InlineData(0, 1e-3)]
    public void Test1(double x, double epsilon)
    {
        var search = new NewtonSearch();
        var result = search.Search(x, epsilon);
        Assert.Multiple(
            () => Assert.Equal(.42241, result.MinX, epsilon),
            () => Assert.Equal(.46004, result.FunX, epsilon));
    }
}