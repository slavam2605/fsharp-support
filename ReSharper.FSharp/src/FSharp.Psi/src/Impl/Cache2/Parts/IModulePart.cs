using JetBrains.ReSharper.Psi.ExtensionsAPI.Caches2;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2.Parts
{
  public interface IModulePart : Class.IClassPart
  {
    bool IsAnonymous { get; }
  }
}
