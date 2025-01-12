# Release notes

## 2019.1

### Refactorings

* Rename
	* Cross-language rename for F#-defined symbols
	* Name suggestions based on symbol type

### Navigation and cross-language interop

* Go to next/previous/containing member actions now work for top level `let` bindings
* Global navigation and Go to File Member action now work for type-private `let` bindings
* F# defined delegates are now supported and are properly seen by code in other languages
* Intrinsic type extensions are now considered type parts with navigation working for every part
* Navigation to compiler generated members declarations from usages in other languages now navigates to origin members
* Navigation to symbols with escaped names now places caret inside escaped identifiers
* `outref` and `inref` types are now properly seen in other languages

### Find usages

* Usages inside `let` bindings are properly grouped by containing members
* Separate grouping for new occurrence kinds:
	* Type argument
	* Base type
	* Type checking
	* Type conversions
	* Module or namespace import
	* Write
	* Attribute reference
* Highlight Usages in File action now highlights Write occurrences differently to other occurrences
* Find usages of union cases now also searches for compiler generated union members

### Code editing and completion

* An option for out-of-scope completion to place `open` statements to the top level was added and enabled by default by [@saul](https://github.com/saul) ([#39](https://github.com/JetBrains/fsharp-support/pull/39))
* Out-of-scope completion can be disabled now
* New Surround with Parens typing assist

### Code analysis

* FSharp.Compiler.Service updated with anonymous records support
* Format specifiers are now highlighted, by [@vasily-kirichenko](https://github.com/vasily-kirichenko) ([#40](https://github.com/JetBrains/fsharp-support/pull/40))
* Inferred generic arguments are shown in tooltips, by [@vasily-kirichenko](https://github.com/vasily-kirichenko) ([#44](https://github.com/JetBrains/fsharp-support/pull/44))
* Full member names are shown in tooltips, by [@vasily-kirichenko](https://github.com/vasily-kirichenko) ([#45](https://github.com/JetBrains/fsharp-support/pull/45))
* Debugger now shows local symbols values next to their uses
* Unused local values analysis is now turned on for all projects and scripts by default
* Support `TreatWarningsAsErrors` MSBuild property

### Misc

* Notification about F# projects having wrong project type guid in solution file
* F# Interactive in FSharp.Compiler.Tools is now automatically found in non-SDK projects
* FSharp.Compiler.Interactive.Settings.dll is now bundled to the plugin (so `fsi` object is available in scripts)
* F# breadcrumbs provider was added
* Add hotkey hint to Send to F# interactive action
* Provide F# project Azure scope for Azure plugin ([#46](https://github.com/JetBrains/fsharp-support/pull/46))

### Fixes

* Pair paren was not inserted in attributes list
* Tab left action (Shift+Tab) didn't work
* Tests defined as `let` bindings in types were not found
* Incremental lexers were not reused, by [@misonijnik](https://github.com/misonijnik)
* Type hierarchy action icon was shown in wrong places
* Usages of operators using their compiled names were highlighted incorrectly
* Find usages didn't work for compiled active patterns and some union cases
* Local rename didn't work properly for symbols defined in Or patterns
* Better highlighting of active pattern declarations
* Extend Selection works better for patterns and `match` expressions
* Resolve and navigation didn't work for optional extension members having the same name in a single module
* Secondary constructors resolve was broken in other languages
* Some reported errors were duplicated
