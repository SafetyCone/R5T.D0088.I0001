using System;

using R5T.T0062;
using R5T.T0063;


namespace R5T.D0088.I0001.Construction
{
    public static class IServiceActionExtensions
    {
        public static IServiceAction<HostStartup> HostStartupAction(this IServiceAction _)
        {
            return _.New<HostStartup>(services => services.AddHostStartup());
        }
    }
}
