namespace Bridge;

public abstract class Menu
{
    protected readonly ICoupon Coupon;
    public abstract int CalculatePrice();

    protected Menu(ICoupon coupon)
    {
        Coupon = coupon;
    }
}

public class VegetarianMenu : Menu
{
    public VegetarianMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice() => 20 - Coupon.CouponValue;
}

public class MeatBasedMenu : Menu
{
    public MeatBasedMenu(ICoupon coupon) : base(coupon)
    {
    }

    public override int CalculatePrice() => 30 - Coupon.CouponValue;
}

public interface ICoupon
{
    int CouponValue { get; }
}

public class NoCoupon : ICoupon
{
    public int CouponValue => 0;
}

public class OneEuroCoupon : ICoupon
{
    public int CouponValue => 1;
}

public class TwoEuroCoupon : ICoupon
{
    public int CouponValue => 2;
}