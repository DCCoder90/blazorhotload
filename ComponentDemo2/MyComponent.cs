using System;
using System.Collections;
using System.Collections.Generic;
using Component.Common;

namespace ComponentDemo2
{
    public class MyComponent : IDynamicComponent
    {
        public bool DisplayInMenu => true;

        public IDictionary<Type,Type> InjectableDependencies => new Dictionary<Type,Type>
        {
            {typeof(WeatherForecastService), typeof(WeatherForecastService)}
        };
        
        public IDictionary<string,string> Parameters => new Dictionary<string,string>
        {
            {"Name",Name}
        };
        
        public string Name => "Weather Forecast";
        public string Page => "Forecast";
        public Type Component => typeof(Component2);

        public MenuItem MenuData => new MenuItem
        {
            Display = true,
            Page = Page,
            Permission = String.Empty,
            CSS = String.Empty,
            Text = "Data",
            Icon = "oi oi-list-rich"
        };
    }
}