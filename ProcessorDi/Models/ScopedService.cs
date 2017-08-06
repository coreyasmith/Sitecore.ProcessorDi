using System;

namespace ProcessorDi.Models
{
  public class ScopedService : IScopedService
  {
    public Guid Id { get; private set; }
    public bool IsDisposed { get; private set; }

    public ScopedService()
    {
      Id = Guid.NewGuid();
    }

    public void Dispose()
    {
      IsDisposed = true;
    }
  }
}
