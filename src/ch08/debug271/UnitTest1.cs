using System;
using Xunit;

namespace debug271;

public class UnitTest1
{
    // 通常の初期化
    [Fact]
    public void Test1()
    {
        var t = Target.CreatePoint(10, 10);
        Assert.NotNull(t);
        Assert.Equal(10, t.X);
        Assert.Equal(10, t.Y);
    }
    // 例外のチェック
    [Fact]
    public void Test2()
    {
        try
        {
            var t = Target.CreatePoint(-1,-1);
        } 
        catch ( Exception ex )
        {
            Assert.Equal("例外発生", ex.Message);
            return;
        }
        // 例外が発生しない場合、テストが失敗
        Assert.True(false);
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
        if (x < 0 || y < 0)
        {
            // 不正な値で初期化した場合は、例外を発生する
            throw new ArgumentException("例外発生");
        }
        return new Target { X = x, Y = y };
    }
}
