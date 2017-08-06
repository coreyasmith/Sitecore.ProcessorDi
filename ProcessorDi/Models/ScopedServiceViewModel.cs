namespace ProcessorDi.Models
{
  public class ScopedServiceViewModel
  {
    public string Name { get; set; }
    public IScopedService ScopedService { get; set; }
  }
}
