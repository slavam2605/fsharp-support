﻿using System.Collections.Generic;
using FSharp.Compiler.SourceCodeServices;
using JetBrains.Annotations;
using JetBrains.ReSharper.Plugins.FSharp.Checker;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Resolve;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;
using Microsoft.FSharp.Core;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Tree
{
  public interface IFSharpFileCheckInfoOwner : ICompositeElement
  {
    [CanBeNull]
    FSharpOption<FSharpParseAndCheckResults> GetParseAndCheckResults(bool allowStaleResults, string opName);

    [NotNull] FSharpCheckerService CheckerService { get; set; }

    [NotNull] IFSharpResolvedSymbolsCache ResolvedSymbolsCache { get; set; }

    [CanBeNull] FSharpOption<FSharpParseFileResults> ParseResults { get; set; }

    [CanBeNull]
    FSharpSymbolUse GetSymbolUse(int offset);

    [CanBeNull]
    FSharpSymbolUse GetSymbolDeclaration(int offset);

    [CanBeNull]
    FSharpSymbol GetSymbol(int offset);

    [NotNull]
    IReadOnlyList<FSharpResolvedSymbolUse> GetAllResolvedSymbols(FSharpCheckFileResults checkResults = null);

    [NotNull]
    IReadOnlyList<FSharpResolvedSymbolUse> GetAllDeclaredSymbols(FSharpCheckFileResults checkResults = null);
  }
}
