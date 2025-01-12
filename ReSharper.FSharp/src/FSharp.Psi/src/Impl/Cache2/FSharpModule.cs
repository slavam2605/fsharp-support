﻿using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2.Parts;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Caches2;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2
{
  internal class FSharpModule : FSharpClass, IModule
  {
    public FSharpModule([NotNull] IModulePart part) : base(part)
    {
    }

    protected override IList<IDeclaredType> CalcSuperTypes() =>
      new[] {Module.GetPredefinedType().Object};

    public bool IsAnonymous =>
      this.GetPart<IModulePart>() is var part && part != null && part.IsAnonymous;

    protected override bool AcceptsPart(TypePart part) =>
      part is IModulePart;
  }
}
