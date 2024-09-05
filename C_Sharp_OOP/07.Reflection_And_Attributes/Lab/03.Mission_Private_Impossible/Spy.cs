using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        private FieldInfo[] GetFieldInfos(Type classType)
        {
            return classType.GetFields(
              BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        }
        private FieldInfo[] GetPublicFieldInfos(Type classType)
        {
             return classType.GetFields(
               BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        }
        private MethodInfo[] GetPublicMethodInfos(Type classType)
        {
            return classType.GetMethods(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        }
        private MethodInfo[] GetNonPublicMethodInfos(Type classType)
        {
            return classType.GetMethods(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic);
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] privateMethodInfos = GetNonPublicMethodInfos(classType);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var methodInfo in privateMethodInfos)
            {
                sb.AppendLine(methodInfo.Name);
            }

            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfos = GetPublicFieldInfos(classType);
            MethodInfo[] publicMethodInfos = GetPublicMethodInfos(classType);
            MethodInfo[] nonPublicMethodInfos = GetNonPublicMethodInfos(classType);

            StringBuilder sb = new StringBuilder();

            foreach (var fieldInfo in fieldInfos)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }
            foreach (var methodInfo in nonPublicMethodInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} must be public!");
            }
            foreach (var methodInfo in publicMethodInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodInfo.Name} must be private!");
            }

            return sb.ToString().Trim();
        }
        public string StealFieldInfo(string className, params string[] fieldNames)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = GetFieldInfos(classType);

            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType);

            stringBuilder.AppendLine($"Class under investigation: {className}");

            foreach (var field in classFields.Where(f => fieldNames.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }
    }
}
