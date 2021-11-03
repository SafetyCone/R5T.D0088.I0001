using System;

using R5T.Lombardy;

using R5T.A0001;
using R5T.D0063.Default;
using R5T.D0065.Standard;


namespace R5T.D0088.I0001
{
    public interface IProvidedServiceActionAggregation :
        IEnvironmentVariableProviderActionAggregation,
        IExecutableDirectoryPathActionAggregation,
        IStringlyTypedPathOperatorActionAggregation
    {
        IHostServiceActionAggregration HostServiceActions { get; set; }
    }
}
