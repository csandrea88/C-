using futureAPI;
using Xunit;
public class testclass
{
    [Theory]
    [InlineData(3)]
    [InlineData(5)]
    [InlineData(6)]
    public void MyfirstTheory(int mynum)
    {
        Assert.True(Program.IsOdd(mynum));
    }
    [Fact]
    public void PassingAddTest()
    {
        Assert.Equal(4, Program.Add(2,2));
    }
    [Fact]
    public void FailingTest()
    {
        Assert.NotEqual(5, Program.Add(2,2));
    }

}
