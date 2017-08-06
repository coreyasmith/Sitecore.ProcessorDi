using System;

namespace ProcessorDi.Models
{
  public interface IScopedService : IDisposable
  {
    Guid Id { get; }
    bool IsDisposed { get; }
  }
}
