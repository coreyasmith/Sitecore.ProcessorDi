using Microsoft.Extensions.DependencyInjection;
using ProcessorDi.Controllers;
using Sitecore.DependencyInjection;

namespace ProcessorDi.Models
{
  public class ProcessorDiConfigurator : IServicesConfigurator
  {
    public void Configure(IServiceCollection serviceCollection)
    {
      serviceCollection.AddScoped<IScopedService, ScopedService>();
      serviceCollection.AddTransient<TestController>();
    }
  }
}
