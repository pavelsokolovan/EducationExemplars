﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Linq;

namespace TestProject
{
    [TestClass]
    public class DynamicTypeForStaticMembers
    {
        [TestMethod]
        public void DynamicTypeForStaticMembersTest()
        {
            dynamic d = new StaticMemberDynamicWrapper(typeof(Clazz));
            d.Objects = new object[] { 11, "st1" };
            Console.WriteLine(d.Length(11, "11"));
            Console.ReadKey();
        }
    }

    class Clazz
    {
        public static Object[] Objects { private get; set; }

        public static int Length(int a, string b)
        {
            return Objects.Length + a + b.Length;
        }
    }

    internal sealed class StaticMemberDynamicWrapper : DynamicObject
    {
        private readonly TypeInfo m_type;

        public StaticMemberDynamicWrapper(Type type) { m_type = type.GetTypeInfo(); }

        public override IEnumerable<String> GetDynamicMemberNames()
        {
            return m_type.DeclaredMembers.Select(mi => mi.Name);
        }

        public override Boolean TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            var field = FindField(binder.Name);
            if (field != null) { result = field.GetValue(null); return true; }
            var prop = FindProperty(binder.Name, true);
            if (prop != null) { result = prop.GetValue(null, null); return true; }
            return false;
        }

        public override Boolean TrySetMember(SetMemberBinder binder, object value)
        {
            var field = FindField(binder.Name);
            if (field != null) { field.SetValue(null, value); return true; }
            var prop = FindProperty(binder.Name, false);
            if (prop != null) { prop.SetValue(null, value, null); return true; }
            return false;
        }

        public override Boolean TryInvokeMember(InvokeMemberBinder binder, Object[] args, out Object result)
        {
            MethodInfo method = FindMethod(binder.Name, args.Select(arg => arg.GetType()).ToArray());
            if (method == null) { result = null; return false; }
            result = method.Invoke(null, args);
            return true;
        }

        private MethodInfo FindMethod(String name, Type[] paramTypes)
        {
            return m_type.DeclaredMethods.FirstOrDefault(mi => mi.IsPublic &&
            mi.IsStatic
            && mi.Name == name
            && ParametersMatch(mi.GetParameters(), paramTypes));
        }

        private Boolean ParametersMatch(ParameterInfo[] parameters, Type[] paramTypes)
        {
            if (parameters.Length != paramTypes.Length) return false;
            for (Int32 i = 0; i < parameters.Length; i++)
                if (parameters[i].ParameterType != paramTypes[i]) return false;
            return true;
        }

        private FieldInfo FindField(String name)
        {
            return m_type.DeclaredFields.FirstOrDefault(fi => fi.IsPublic && fi.IsStatic && fi.Name == name);
        }

        private PropertyInfo FindProperty(String name, Boolean get)
        {
            if (get)
                return m_type.DeclaredProperties.FirstOrDefault(
                pi => pi.Name == name && pi.GetMethod != null &&
                pi.GetMethod.IsPublic && pi.GetMethod.IsStatic);
            return m_type.DeclaredProperties.FirstOrDefault(
            pi => pi.Name == name && pi.SetMethod != null &&
            pi.SetMethod.IsPublic && pi.SetMethod.IsStatic);
        }
    }
}
