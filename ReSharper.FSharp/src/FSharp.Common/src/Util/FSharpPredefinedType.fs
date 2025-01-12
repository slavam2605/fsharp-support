[<AutoOpen; Extension>]
module JetBrains.ReSharper.Plugins.FSharp.Util.FSharpPredefinedType

open JetBrains.Metadata.Reader.API
open JetBrains.Metadata.Reader.Impl
open JetBrains.ReSharper.Psi

let clrTypeName name = ClrTypeName(name) :> IClrTypeName

[<CompiledName("SourceNameAttrTypeName")>]
let sourceNameAttrTypeName = clrTypeName "Microsoft.FSharp.Core.CompilationSourceNameAttribute"

[<CompiledName("CompilationMappingAttrTypeName")>]
let compilationMappingAttrTypeName = clrTypeName "Microsoft.FSharp.Core.CompilationMappingAttribute"


[<CompiledName("FSharpListTypeName")>]
let fsListTypeName = clrTypeName "Microsoft.FSharp.Collections.FSharpList`1"

[<CompiledName("FSharpOptionTypeName")>]
let fsOptionTypeName = clrTypeName "Microsoft.FSharp.Collections.FSharpOption`1"

[<CompiledName("FSharpRefTypeName")>]
let fsRefTypeName = clrTypeName "Microsoft.FSharp.Collections.FSharpRef`1"

[<CompiledName("FSharpResultTypeName")>]
let fsResultTypeName = clrTypeName "Microsoft.FSharp.Core.FSharpResult`2"

[<CompiledName("FSharpAsyncTypeName")>]
let fsAsyncTypeName = clrTypeName "Microsoft.FSharp.Control.FSharpAsync"

[<CompiledName("FSharpAsyncGenericTypeName")>]
let fsAsyncGenericTypeName = clrTypeName "Microsoft.FSharp.Control.FSharpAsync`1"


[<CompiledName("StructuralComparableTypeName")>]
let structuralComparableTypeName = clrTypeName "System.Collections.IStructuralComparable"

[<CompiledName("StructuralEquatableTypeName")>]
let structuralEquatableTypeName = clrTypeName "System.Collections.IStructuralEquatable"

[<CompiledName("ComparerTypeName")>]
let comparerTypeName = clrTypeName "System.Collections.IComparer"

[<CompiledName("EqualityComparerTypeName")>]
let equalityComparerTypeName = clrTypeName "System.Collections.IEqualityComparer"


/// This map is used in Find Usages to get source name of element without having FSharpSymbol element.
/// It should be removed when it's possible to get abbreviation definitions from assemblies.
[<CompiledName("PredefinedAbbreviations")>]
let predefinedAbbreviations =
    [| PredefinedType.OBJECT_FQN, [| "obj" |]
       PredefinedType.EXCEPTION_FQN, [| "exn" |]
       PredefinedType.INTPTR_FQN, [| "nativeint" |]
       PredefinedType.UINTPTR_FQN, [| "unativeint" |]
       PredefinedType.STRING_FQN, [| "string" |]
       PredefinedType.FLOAT_FQN, [| "float32"; "single" |]
       PredefinedType.DOUBLE_FQN, [| "float"; "double" |]
       PredefinedType.SBYTE_FQN, [| "sbyte"; "int8" |]
       PredefinedType.BYTE_FQN, [| "byte"; "uint8" |]
       PredefinedType.SHORT_FQN, [| "int16" |]
       PredefinedType.USHORT_FQN, [| "uint16" |]
       PredefinedType.INT_FQN, [| "int"; "int32" |]
       PredefinedType.UINT_FQN, [| "uint32" |]
       PredefinedType.LONG_FQN, [| "int64" |]
       PredefinedType.ULONG_FQN, [| "uint64" |]
       PredefinedType.CHAR_FQN, [| "char" |]
       PredefinedType.BOOLEAN_FQN, [| "bool" |]
       PredefinedType.DECIMAL_FQN, [| "decimal" |]

       fsListTypeName, [| "list" |]
       fsOptionTypeName, [| "option" |]
       fsRefTypeName, [| "ref" |]
       fsResultTypeName, [| "Result" |]
       fsAsyncTypeName, [| "Async" |]
       fsAsyncGenericTypeName, [| "Async" |] |]
    |> dict

[<Extension; CompiledName("TryGetPredefinedAbbreviations")>]
let tryGetPredefinedAbbreviations(clrTypeName: IClrTypeName, names: outref<string[]>) =
    predefinedAbbreviations.TryGetValue(clrTypeName, &names)
