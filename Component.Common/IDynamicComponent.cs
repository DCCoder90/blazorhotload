using System;
using System.Collections.Generic;

namespace Component.Common
{
    public interface IDynamicComponent
    {
        IDictionary<Type,Type> InjectableDependencies { get; }
        IDictionary<string,string> Parameters { get; }
        string Name { get; }
        string Page { get; }
        Type Component { get;}
        //Permission to render or display
        //How to deal with modules that have multiple pages?
        MenuItem MenuData { get; }
    }
}