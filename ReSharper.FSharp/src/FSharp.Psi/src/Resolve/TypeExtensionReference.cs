using FSharp.Compiler.SourceCodeServices;
using JetBrains.Annotations;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Tree;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Resolve
{
  public class TypeExtensionReference : FSharpSymbolReference
  {
    public TypeExtensionReference([NotNull] IReferenceExpression owner) : base(owner)
    {
    }

    public override FSharpSymbol GetFSharpSymbol()
    {
      var token = myOwner.IdentifierToken;
      if (token == null)
        return null;

      var fsFile = myOwner.FSharpFile;
      var offset = token.GetTreeStartOffset().Offset;
      return fsFile.GetSymbolDeclaration(offset)?.Symbol ?? fsFile.GetSymbolUse(offset)?.Symbol;
    }
  }
}
