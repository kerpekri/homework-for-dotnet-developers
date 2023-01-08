using EG.Homework.Orders.Services;
using FluentAssertions;

namespace EG.Homework.Tests.Orders.Services;

public class DiscountSelectorTests
{
    private readonly DiscountSelector _selector;

    public DiscountSelectorTests()
    {
        _selector = new DiscountSelector();
    }

    [Fact]
    public void Select_MustReturnSmallOrderDiscount_WhenTwoKitsOrdered()
    {
        var result = _selector.Select(2);

        result.Should().BeOfType<SmallOrderDiscountStrategy>();
    }

    [Fact]
    public void Select_MustReturnSmallOrderDiscount_WhenTwelveKitsOrdered()
    {
        var result = _selector.Select(12);

        result.Should().BeOfType<MediumOrderDiscountStrategy>();
    }

    [Fact]
    public void Select_MustReturnSmallOrderDiscount_WhenFiftyKitsOrdered()
    {
        var result = _selector.Select(50);

        result.Should().BeOfType<LargeOrderDiscountStrategy>();
    }
}