﻿using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Lombardy;

using R5T.A0001;
using R5T.D0063.Default;
using R5T.D0065.Standard;


namespace R5T.D0088.I0001
{
    public abstract class HostStartupBase : IHostStartup
    {
        //private IserviceX ServiceX { get; }

        public HostStartupBase(
            //IServiceX serviceX
            )
        {
            //this.ServiceX = serviceX;
        }

        public abstract Task ConfigureConfiguration(IConfigurationBuilder configurationBuilder);

        public async Task ConfigureServices(IServiceCollection services)
        {
            var requiredServices = await this.GetRequiredServices();

            // Services.
            // Level 0.
            var environmentVariableProviderActions = Instances.ServiceAction.AddEnvironmentVariableProviderActions();
            var hostServiceActions = Instances.ServiceAction.AddHostServiceActions();
            var stringlyTypedPathOperatorActions = Instances.ServiceAction.AddStringlyTypedPathOperatorActions();

            // Level 1.
            var executableDirectoryPathProviderActions = Instances.ServiceAction.AddExecutableDirectoryPathProviderActions(
                stringlyTypedPathOperatorActions.StringlyTypedPathOperatorAction);

            // Now allow derived host startups to configure services.
            var providedServices = new ProvidedServicesAggregation
            {
                HostServiceActions = hostServiceActions,
            }
            .FillFrom(environmentVariableProviderActions)
            .FillFrom(executableDirectoryPathProviderActions)
            .FillFrom(stringlyTypedPathOperatorActions)
            ;

            await this.ConfigureServices(services,
                providedServices);
        }

        protected abstract Task<IRequiredServiceActionAggregation> GetRequiredServices();

        protected abstract Task ConfigureServices(IServiceCollection services,
            IProvidedServiceActionAggregation providedServicesAggregation);
    }
}