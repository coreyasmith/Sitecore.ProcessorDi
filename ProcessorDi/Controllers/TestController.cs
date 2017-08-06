using System;
using System.Web.Mvc;
using ProcessorDi.Models;

namespace ProcessorDi.Controllers
{
  public class TestController : Controller
  {
    private readonly IScopedService _scopedService;

    public TestController(IScopedService scopedService)
    {
      if (scopedService == null) throw new ArgumentNullException(nameof(scopedService));
      _scopedService = scopedService;
    }

    public ActionResult Test()
    {
      var model = new TestViewModel();
      model.ScopedServices.Add(CreateScopedServiceViewModel(Constants.SingletonInstanceServiceKey, "Singleton Processor Instance Service"));
      model.ScopedServices.Add(CreateScopedServiceViewModel(Constants.SingletonMethodServiceKey, "Singleton Processor Method Service"));
      model.ScopedServices.Add(CreateScopedServiceViewModel(Constants.TransientInstanceServiceKey, "Transient Processor Instance Service"));
      model.ScopedServices.Add(CreateScopedServiceViewModel(Constants.TransientMethodServiceKey, "Transient Processor Method Service"));
      model.ScopedServices.Add(CreateScopedServiceViewModel(_scopedService, "Controller Instance Service"));
      return View(model);
    }
    
    private ScopedServiceViewModel CreateScopedServiceViewModel(string httpContextKey, string name)
    {
      var scopedService = HttpContext.Items[httpContextKey] as IScopedService;
      return CreateScopedServiceViewModel(scopedService, name);
    }

    private static ScopedServiceViewModel CreateScopedServiceViewModel(IScopedService scopedService, string name)
    {
      return new ScopedServiceViewModel
      {
        Name = name,
        ScopedService = scopedService
      };
    }
  }
}
