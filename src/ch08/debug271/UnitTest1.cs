using System;
using Xunit;

namespace debug271;

public class UnitTest1
{
    // �ʏ�̏�����
    [Fact]
    public void Test1()
    {
        var t = Target.CreatePoint(10, 10);
        Assert.NotNull(t);
        Assert.Equal(10, t.X);
        Assert.Equal(10, t.Y);
    }
    // ��O�̃`�F�b�N
    [Fact]
    public void Test2()
    {
        try
        {
            var t = Target.CreatePoint(-1,-1);
        } 
        catch ( Exception ex )
        {
            Assert.Equal("��O����", ex.Message);
            return;
        }
        // ��O���������Ȃ��ꍇ�A�e�X�g�����s
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
            // �s���Ȓl�ŏ����������ꍇ�́A��O�𔭐�����
            throw new ArgumentException("��O����");
        }
        return new Target { X = x, Y = y };
    }
}
