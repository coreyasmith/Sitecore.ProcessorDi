using System.Collections.Generic;

namespace ProcessorDi.Models
{
  public class TestViewModel
  {
    public IList<ScopedServiceViewModel> ScopedServices { get; set; }

    public TestViewModel()
    {
      ScopedServices = new List<ScopedServiceViewModel>();
    }
  }
}
