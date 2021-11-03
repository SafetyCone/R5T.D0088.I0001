using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace R5T.D0088.I0001.Construction
{
    public class HostStartup : HostStartupBase
    {
        public override Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder)
        {
            // Do nothing.

            return Task.CompletedTask;
        }

        protected override Task ConfigureServices(IServiceCollection services,
            IProvidedServiceActionAggregation providedServicesAggregation)
        {
            services
                .Run(providedServicesAggregation.DirectoryNameOperatorAction)
                .Run(providedServicesAggregation.DirectorySeparatorOperatorAction)
                .Run(providedServicesAggregation.FileExtensionOperatorAction)
                .Run(providedServicesAggregation.FileNameOperatorAction)
                .Run(providedServicesAggregation.StringlyTypedPathOperatorAction)
                ;

            return Task.CompletedTask;
        }

        protected override Task<IRequiredServiceActionAggregation> GetRequiredServices()
        {
            var requiredSerivces = new RequiredServiceActionAggregation();

            return Task.FromResult(requiredSerivces as IRequiredServiceActionAggregation);
        }
    }
}
