using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Tree
{
  internal partial class DotSetExpr
  {
    public override ITokenNode ReferenceIdentifier => LongIdentifier?.IdentifierToken;
  }
}
