namespace Facade;

public class OrderService
{
    public bool HasEnoughOrders(int customerId) => customerId >= 5;
}

public class CustomerDiscountBaseService
{
    public double CalculateDiscountBase(int customerId) => customerId > 8 ? 10 : 20;
}

public class DayOfWeekFactor
{
    private readonly ITimeService _timeService;

    public DayOfWeekFactor(ITimeService? timeService = null)
    {
        _timeService = timeService ?? new StandardTimeService();
    }

    public double CalculateDayOfTheWeekFactor
    {
        get
        {
            var dayOfTheWeek = _timeService.GetDayOfWeek();
            switch (dayOfTheWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Tuesday:
                case DayOfWeek.Wednesday:
                case DayOfWeek.Thursday:
                case DayOfWeek.Friday:
                    return 1.2;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return 0.8;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

public interface ITimeService
{
    public DayOfWeek GetDayOfWeek();
}

public class StandardTimeService : ITimeService
{
    public DayOfWeek GetDayOfWeek() => DateTime.Now.DayOfWeek;
}

public class DiscountFacade
{
    private readonly OrderService _orderService = new();
    private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
    private readonly DayOfWeekFactor _dayOfWeekFactor;

    public DiscountFacade(DayOfWeekFactor dayOfWeekFactor)
    {
        _dayOfWeekFactor = dayOfWeekFactor;
    }

    public double CalculateDiscount(int customerId)
    {
        if (!_orderService.HasEnoughOrders(customerId))
        {
            return 0;
        }

        var discountBase = _customerDiscountBaseService.CalculateDiscountBase(customerId);
        var dayOfTheWeekFactor = _dayOfWeekFactor.CalculateDayOfTheWeekFactor;

        return discountBase * dayOfTheWeekFactor;
    }
}