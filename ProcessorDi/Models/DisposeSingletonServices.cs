using Sitecore.Pipelines.HttpRequest;

namespace ProcessorDi.Models
{
  public class DisposeSingletonServices : HttpRequestProcessor
  {
    public override void Process(HttpRequestArgs args)
    {
      var singletonInstanceService = GetScopedServiceFromHttpContext(args, Constants.SingletonInstanceServiceKey);
      singletonInstanceService.Dispose();

      var transientInstanceService = GetScopedServiceFromHttpContext(args, Constants.TransientInstanceServiceKey);
      transientInstanceService.Dispose();
    }

    private static IScopedService GetScopedServiceFromHttpContext(HttpRequestArgs args, string httpContextKey)
    {
      return args.Context.Items[httpContextKey] as IScopedService;
    }
  }
}
