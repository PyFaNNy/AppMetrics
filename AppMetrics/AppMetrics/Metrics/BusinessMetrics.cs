using App.Metrics;
using App.Metrics.Counter;

namespace AppMetrics.MetricsR;

public class BusinessMetrics
{
    public static CounterOptions CustomersGetAllCounter => new CounterOptions()
    {
        Context = "Customers",
        Name = "Customer get all request",
        MeasurementUnit = Unit.Calls,
        Tags = new MetricTags(new []{"AppMetric"}, new []{"Number one"})
    };
}