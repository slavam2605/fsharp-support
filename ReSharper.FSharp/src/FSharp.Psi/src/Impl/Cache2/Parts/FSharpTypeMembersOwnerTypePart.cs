﻿using System.Collections.Generic;
using JetBrains.Annotations;
using JetBrains.Metadata.Reader.API;
using JetBrains.ReSharper.Plugins.FSharp.Psi.Tree;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.ExtensionsAPI.Caches2;
using JetBrains.Util;

namespace JetBrains.ReSharper.Plugins.FSharp.Psi.Impl.Cache2.Parts
{
  internal abstract class FSharpTypeMembersOwnerTypePart : FSharpClassLikePart<IFSharpTypeDeclaration>
  {
    protected FSharpTypeMembersOwnerTypePart([NotNull] IFSharpTypeDeclaration declaration,
      [NotNull] ICacheBuilder cacheBuilder)
      : base(declaration, ModifiersUtil.GetDecoration(declaration.AccessModifiers, declaration.Attributes),
        declaration.TypeParameters, cacheBuilder)
    {
      var extendListShortNames = new FrugalLocalHashSet<string>();
      foreach (var member in declaration.TypeMembersEnumerable)
      {
        var baseTypeIdentifier = (member as ITypeInherit)?.BaseType?.LongIdentifier;
        if (baseTypeIdentifier != null)
        {
          extendListShortNames.Add(baseTypeIdentifier.Name);
          continue;
        }

        var interfaceImplTypeIdentifier = (member as IInterfaceImplementation)?.InterfaceType?.LongIdentifier;
        if (interfaceImplTypeIdentifier != null)
        {
          extendListShortNames.Add(interfaceImplTypeIdentifier.Name);
          continue;
        }

        var interfaceInheritTypeIdentifier = (member as IInterfaceInherit)?.BaseType?.LongIdentifier;
        if (interfaceInheritTypeIdentifier != null)
          extendListShortNames.Add(interfaceInheritTypeIdentifier.Name);
      }

      ExtendsListShortNames = extendListShortNames.ToArray();
    }

    protected FSharpTypeMembersOwnerTypePart(IReader reader) : base(reader) =>
      ExtendsListShortNames = reader.ReadStringArray();

    protected override void Write(IWriter writer)
    {
      base.Write(writer);
      writer.WriteStringArray(ExtendsListShortNames);
    }

    public override string[] ExtendsListShortNames { get; }

    [CanBeNull] internal IClrTypeName[] SuperTypesClrTypeNames;

    public virtual MemberPresenceFlag GetMemberPresenceFlag() =>
      MemberPresenceFlag.SIGN_OP | MemberPresenceFlag.EXPLICIT_OP |
      MemberPresenceFlag.MAY_EQUALS_OVERRIDE | MemberPresenceFlag.MAY_TOSTRING_OVERRIDE |

      // RIDER-10263
      (HasPublicDefaultCtor ? MemberPresenceFlag.PUBLIC_DEFAULT_CTOR : MemberPresenceFlag.NONE);

    public virtual IDeclaredType GetBaseClassType() =>
      ExtendsListShortNames.IsEmpty()
        ? null
        : GetDeclaration()?.BaseClassType ?? GetPsiModule().GetPredefinedType().Object;

    public override IEnumerable<IDeclaredType> GetSuperTypes()
    {
      if (ExtendsListShortNames.IsEmpty())
        return EmptyList<IDeclaredType>.InstanceList;

      var declaration = GetDeclaration();
      return declaration != null ? declaration.SuperTypes : EmptyList<IDeclaredType>.InstanceList;
    }

    public override IEnumerable<ITypeElement> GetSuperTypeElements()
    {
      var psiModule = GetPsiModule();
      if (SuperTypesClrTypeNames != null)
        return SuperTypesClrTypeNames.ToTypeElements(psiModule);

      var superTypeNames = new HashSet<IClrTypeName>();
      var superTypeElements = new HashSet<ITypeElement>();

      foreach (var declaredType in GetSuperTypes())
      {
        var typeElement = declaredType.GetTypeElement();
        if (typeElement == null)
          continue;

        superTypeNames.Add(typeElement.GetClrName().GetPersistent());
        superTypeElements.Add(typeElement);
      }

      SuperTypesClrTypeNames = superTypeNames.ToArray();
      return superTypeElements;
    }
  }
}
