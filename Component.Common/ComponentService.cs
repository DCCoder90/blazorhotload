using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Component.Common
{
    public class ComponentService : IComponentService
    {
        public IEnumerable<Type> Components { get; private set; }

        public void LoadComponents(string path)
        {
            var components = new List<Type>();
            var assemblies = LoadAssemblies(path);

            foreach (var asm in assemblies)
            {
                var types = GetTypesWithInterface(asm);
                foreach (var typ in types) components.Add(typ);
            }

            Components = components;
        }

        public IEnumerable<MenuItem> GetMenuItems()
        {
            return Components.Select(x => ((IDynamicComponent) Activator.CreateInstance(x)).MenuData);
        }

        public IDynamicComponent GetComponentByName(string name)
        {
            return Components.Select(x => (IDynamicComponent) Activator.CreateInstance(x))
                .SingleOrDefault(x => x.Name == name);
        }
        
        public IDynamicComponent GetComponentByPage(string name)
        {
            return Components.Select(x => (IDynamicComponent) Activator.CreateInstance(x))
                .SingleOrDefault(x => x.Page == name);
        }

        private IEnumerable<Assembly> LoadAssemblies(string path)
        {
            return Directory.GetFiles(path, "*.dll").Select(dll => Assembly.LoadFile(dll)).ToList();
        }

        private IEnumerable<Type> GetTypesWithInterface(Assembly asm)
        {
            var it = typeof(IDynamicComponent);
            return GetLoadableTypes(asm).Where(it.IsAssignableFrom).ToList();
        }

        private IEnumerable<Type> GetLoadableTypes(Assembly assembly)
        {
            if (assembly == null) throw new ArgumentNullException("assembly");
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }
    }
}