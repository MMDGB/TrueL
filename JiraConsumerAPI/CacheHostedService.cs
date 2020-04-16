using JiraConsumerAPI.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JiraConsumerAPI
{
    public class CacheHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public CacheHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                // Get the DbContext instance
                var myCache = scope.ServiceProvider.GetRequiredService<IJiraConfiguration>();

                //Do the migration asynchronously
                myCache.KnownTasks = await DefineCache();
            }
        }

        private async Task<Dictionary<string, JObject>> DefineCache()
        {
            JsonCreator  jsonCreator = new JsonCreator();

            return new Dictionary<string, JObject>
            {
                { Constants.Meeting, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.Meeting)) },
                { Constants.Support, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.Support)) },
                { Constants.ES45Test, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ES45Test)) },
                { Constants.WASDeploy, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.WASDeploy)) },
                { Constants.ES104Test, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ES104Test)) },
                { Constants.OnBoarding, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.OnBoarding)) },
                { Constants.NewGUIReact, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.NewGUIReact)) },
                { Constants.FinasDefect, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.FinasDefect)) },
                { Constants.AutotestIDE, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.AutotestIDE)) },
                { Constants.SafirDefect, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.SafirDefect)) },
                { Constants.FeplasDefect, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.FeplasDefect)) },
                { Constants.AutotestFINAS, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.AutotestFINAS)) },
                { Constants.AutotestSAFIR, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.AutotestSAFIR)) },
                { Constants.TestingOfES46, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.TestingOfES46)) },
                { Constants.MigrationWASS1, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.MigrationWASS1)) },
                { Constants.MigrationWASS3, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.MigrationWASS3)) },
                { Constants.NewTechTesting, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.NewTechTesting)) },
                { Constants.TestingOfES116, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.TestingOfES116)) },
                { Constants.TestingOfES117, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.TestingOfES117)) },
                { Constants.TestingOfES118, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.TestingOfES118)) },
                { Constants.TestingOfES140, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.TestingOfES140)) },
                { Constants.TestingOf116384, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.TestingOf116384)) },
                { Constants.NewTechMigration, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.NewTechMigration)) },
                { Constants.SAFIRTranslation, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.SAFIRTranslation)) },
                { Constants.ServiceFeplasWeb, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ServiceFeplasWeb)) },
                { Constants.FINASTranslation, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.FINASTranslation)) },
                { Constants.FEPLASTranslation, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.FEPLASTranslation)) },
                { Constants.ES45Implementation, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ES45Implementation)) },
                { Constants.ImplementationES26, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationES26)) },
                { Constants.DevelopmentLearning, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.DevelopmentLearning)) },
                { Constants.ES104Implementation, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ES104Implementation)) },
                { Constants.ImplementationOfE140, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfE140)) },
                { Constants.ImplementationOfES46, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfES46)) },
                { Constants.NewTechMicroServices, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.NewTechMicroServices)) },
                { Constants.ImplementationOfES108, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfES108)) },
                { Constants.ImplementationOfES116, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfES116)) },
                { Constants.ImplementationOfES117, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfES117)) },
                { Constants.ImplementationOfES118, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfES118)) },
                { Constants.ImplementationOfES125, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationOfES125)) },
                { Constants.AnalisisAndEstimation, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.AnalisisAndEstimation)) },
                { Constants.ImplementationCR107142, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ImplementationCR107142)) },
                { Constants.ConfigurationApplication, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ConfigurationApplication)) },
                { Constants.ChangeRequestMaintananceFINAS, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ChangeRequestMaintananceFINAS)) },
                { Constants.ChangeRequestMaintananceSAFIR, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ChangeRequestMaintananceSAFIR)) },
                { Constants.ChangeRequestMaintenanceFEPLAS, JObject.Parse(await jsonCreator.GetJiraWorklogAsync(Constants.ChangeRequestMaintenanceFEPLAS)) }
            };
        }

        // noop
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}