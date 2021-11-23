using System;

using R5T.A0001;


namespace R5T.D0088.I0001
{
    public interface IProvidedServiceActionAggregation :
        A0002.IServiceActionAggregation
    {
        IHostServiceActionAggregration HostServiceActions { get; set; }
    }
}
