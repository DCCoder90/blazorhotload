using System;
using System.Collections.Generic;

namespace Component.Common
{
    public interface IComponentService
    {
        void LoadComponents(string path);
        IDynamicComponent GetComponentByName(string name);
        IDynamicComponent GetComponentByPage(string name);
        IEnumerable<Type> Components { get; }
        IEnumerable<MenuItem> GetMenuItems(bool getHiddenItems = false);
    }
}