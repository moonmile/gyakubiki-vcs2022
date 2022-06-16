using Xunit;

namespace debug272;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var t = new Target();
        int ans = t.Add(10, 20);
        Assert.Equal(30, ans);
    }
    [Fact]
    public void Test2()
    {
        var t = new Target();
        string ans = t.Add("マスダ", "トモアキ");
        Assert.Equal("マスダトモアキ", ans);
    }
    [Fact]
    public void Test3()
    {
        var t = Target.CreatePoint(-1, -1);
        Assert.Null(t);
        t = Target.CreatePoint(10, 20);
        Assert.NotNull(t);
        Assert.Equal(10, t.X);
        Assert.Equal(20, t.Y);
    }
}

public class Target
{
    public int Add(int x, int y)
    {
        return x + y;
    }
    public string Add(string x, string y)
    {
        return x + y;
    }

    public int X { get; set; }
    public int Y { get; set; }
    public static Target? CreatePoint(int x, int y)
    {
        if (x < 0 || y < 0) return null;
        return new Target { X = x, Y = y };
    }
}
