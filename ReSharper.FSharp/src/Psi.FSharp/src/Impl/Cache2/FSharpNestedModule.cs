﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace JetBrains.ReSharper.Psi.FSharp.Impl.Cache2
{
  internal class FSharpNestedModule : FSharpClassLikeElement<NestedModulePart>
  {
    public FSharpNestedModule([NotNull] IClassPart part) : base(part)
    {
    }

    protected override IList<IDeclaredType> CalcSuperTypes()
    {
      return new[] {Module.GetPredefinedType().Object};
    }
  }
}