using System;
using System.Collections;
using System.Collections.Generic;
using Component.Common;

namespace ComponentDemo
{
    public class MyComponent : IDynamicComponent
    {
        public IDictionary<Type,Type> InjectableDependencies => new Dictionary<Type, Type>();
        public IDictionary<string,string> Parameters => new Dictionary<string, string>();
        
        public string Name => "Counter";
        public string Page => "Counter";
        public Type Component => typeof(Component1);

        public MenuItem MenuData => new MenuItem
        {
            Display = true,
            Permission = string.Empty,
            Page = Page,
            CSS = String.Empty,
            Text = "Counter",
            Icon = "oi oi-plus"
        };
    }
}