using System;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using R5T.Lombardy;

using R5T.D0090;


namespace R5T.D0088.I0001.Construction
{
    class Program : ProgramAsAServiceBase
    {
        #region Static

        static async Task Main(string[] args)
        {
            await Instances.Host.NewBuilder()
                .UseProgramAsAService<Program, T0075.IHostBuilder>()
                .UseHostStartup(Instances.ServiceAction.HostStartupAction())
                .Build()
                .RunAsync();
        }

        #endregion

        public Program(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override Task ServiceMain(CancellationToken stoppingToken)
        {
            var stringlyTypedPathOperator = this.ServiceProvider.GetRequiredService<IStringlyTypedPathOperator>();

            var rootDirectoryPath = @"C:\Temp\R5T.Lombardy";
            var relativeDirectoryPath = @"X\Y\Z";

            var combinedDirectoryPath = stringlyTypedPathOperator.Combine(rootDirectoryPath, relativeDirectoryPath);

            return Task.CompletedTask;
        }
    }
}