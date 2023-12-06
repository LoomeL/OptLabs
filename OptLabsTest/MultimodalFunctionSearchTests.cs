namespace OptLabsTest;

public class MultimodalFunctionSearchTests
{
    [Theory(DisplayName = "Нахождение константы Липшица")]
    [InlineData(9, 11, 0.015)]
    public void LipschitzConstantTest(double a, double b, double epsilon)
    {
        var search = new MultimodalFunctionSearch();
        var result = search.BruteforceMethod(a, b);
        Assert.Equal(0.10961508414476798, result, epsilon);
    }

    [Theory(DisplayName = "Поиск методом перебора")]
    [InlineData(9, 11, 0.015)]
    [InlineData(9, 11, 1e-3)]
    [InlineData(9, 11, 1e-4)]
    public void UniformSearchTest(double a, double b, double epsilon)
    {
        var search = new MultimodalFunctionSearch();
        var result = search.UniformSampling(a, b, epsilon);
        Assert.Equal(-10.0058, result.FunX, epsilon);
    }

    [Theory(DisplayName = "Поиск методом ломаных с константой")]
    [InlineData(9, 11, 0.015)]
    public void PiecewiseLinearApproximationTest(double a, double b, double e)
    {
        var search = new MultimodalFunctionSearch();
        var result = search.LipshitzMethod(a, b, e);
        var epsilon = e;
        Assert.Equal(-10.0058, result.FunX, epsilon);
    }
}