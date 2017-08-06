using System;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.Pipelines.HttpRequest;

namespace ProcessorDi.Models
{
  public class TransientProcessor : HttpRequestProcessor
  {
    private readonly IScopedService _scopedService;

    public TransientProcessor(IScopedService scopedService)
    {
      if (scopedService == null) throw new ArgumentNullException(nameof(scopedService));
      _scopedService = scopedService;
    }

    public override void Process(HttpRequestArgs args)
    {
      args.Context.Items[Constants.TransientInstanceServiceKey] = _scopedService;

      var scopedService = ServiceLocator.ServiceProvider.GetService<IScopedService>();
      args.Context.Items[Constants.TransientMethodServiceKey] = scopedService;
    }
  }
}
