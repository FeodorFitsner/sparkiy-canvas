using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace SharpDX.Toolkit {
    /// <summary>
    ///     Extension methods for <see cref="ComObject" />.
    /// </summary>
    public static class ComObjectExtensions {
        private static Assembly[] _assemblies;
        private static Dictionary<Type, Type[]> _dictionaryInterfaces;

        /// <summary>
        ///     Queries this COM object for interfaces it implements.
        /// </summary>
        /// <param name="comObject"></param>
        /// <returns>An array of types from SharpDX assemblies that represents the implemented interfaces for this COM object.</returns>
        /// <remarks>Queries are cached for faster subsequent queries.</remarks>
        public static Type[] QueryInterfaces(this ComObject comObject) {
            if (comObject == null) throw new ArgumentNullException("comObject");
            if (_dictionaryInterfaces == null) {
                _dictionaryInterfaces = new Dictionary<Type, Type[]>();
            }
            Type type = comObject.GetType();
            bool containsKey = _dictionaryInterfaces.ContainsKey(type);
            if (containsKey) {
                return _dictionaryInterfaces[type];
            }

            Type[] interfaces = GetInterfaces(comObject);
            _dictionaryInterfaces.Add(type, interfaces);
            return interfaces;
        }

        /// <summary>
        ///     Gets the interfaces implemented by a COM object.
        /// </summary>
        /// <param name="comObject"></param>
        /// <returns></returns>
        private static Type[] GetInterfaces(ComObject comObject) {
            Assembly[] assemblies = GetSharpDxAssemblies();
            return assemblies
                .SelectMany(s => s.ExportedTypes)
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Namespace)
                .Where(s => s.GetTypeInfo().IsSubclassOf(typeof (ComObject)))
                .Where(s => comObject.QueryInterfaceOrNull(Utilities.GetGuidFromType(s)) != IntPtr.Zero)
                .ToArray();
        }

        /// <summary>
        ///     Tries to load SharpDX assemblies from application folder.
        /// </summary>
        /// <returns></returns>
        private static Assembly[] GetSharpDxAssemblies() {
            if (_assemblies != null) return _assemblies;
            var list = new List<Assembly>();
            try {
                Assembly assemblyD2D = Assembly.Load(new AssemblyName("SharpDX.Direct2D1"));
                list.Add(assemblyD2D);
            }
            catch (Exception ex) {
                Debug.WriteLine("SharpDX.Direct2D1 assembly could not be found: " + ex.Message);
            }

            try {
                Assembly assemblyD3D11 = Assembly.Load(new AssemblyName("SharpDX.Direct3D11"));
                list.Add(assemblyD3D11);
            }
            catch (Exception ex) {
                Debug.WriteLine("SharpDX.Direct3D11 assembly could not be found: " + ex.Message);
            }

            try {
                Assembly assemblyDxgi = Assembly.Load(new AssemblyName("SharpDX.DXGI"));
                list.Add(assemblyDxgi);
            }
            catch (Exception ex) {
                Debug.WriteLine("SharpDX.DXGI assembly could not be found: " + ex.Message);
            }

            if (list.Count == 0) {
                Debug.WriteLine("No SharpDX assemblies could be found");
            }

            _assemblies = list.ToArray();
            return _assemblies;
        }
    }
}