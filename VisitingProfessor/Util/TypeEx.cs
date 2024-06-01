﻿namespace Clio.Demo.VisitingProfessor.Util
{
    internal static class TypeEx
    {
        private static readonly Dictionary<Type, string> typeNames = new Dictionary<Type, string>
        {
            { typeof(string) , "string" },
            { typeof(object) , "object" },
            { typeof(bool) , "bool" },
            { typeof(byte) , "byte" },
            { typeof(char) , "char" },
            { typeof(decimal), "decimal" },
            { typeof(double) , "double" },
            { typeof(short) , "short" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(sbyte), "sbyte" },
            { typeof(float), "float" },
            { typeof(ushort), "ushort" },
            { typeof(uint), "uint" },
            { typeof(ulong), "ulong" },
            { typeof(void), "void" }
        };

        public static string DisplayName(this Type type, Dictionary<Type, string> translations)
        {
            if (null == type) return string.Empty;
            if (translations.ContainsKey(type)) return translations[type];
            else if (type.IsArray) return DisplayName(type.GetElementType(), translations) + "[]";
            else if (type.IsGenericType) return type.Name.Split('`')[0] + "<" + string.Join(", ", type.GetGenericArguments().Select(x => DisplayName(x)).ToArray()) + ">";
            else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return type.GetGenericArguments()[0].DisplayName() + "?";
            else return type.Name;
        }

        public static string DisplayName(this Type type)
        {
            return null != type ? type.DisplayName(typeNames) : string.Empty;
        }

        public static string Stamp(this object sender)
        {
            switch (sender)
            {
                case string str: return str;
                case Type type: return type.DisplayName();
            }
            return $"{sender.GetType().DisplayName()}";
        }

        public static string TypeName(this object sender)
        {
            if (null == sender) return "null";
            return sender.GetType().DisplayName();
        }
    }
}
