module Module

let (f: Foo<string>.Bar<bool>) = Foo.Bar("", true)
let (i: int) = f.Method("", 123)
