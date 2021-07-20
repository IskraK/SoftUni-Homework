using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (var field in classFields.Where(n => requestedFields.Contains(n.Name)))
            {
                sb.AppendLine($"{ field.Name} = { field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public );
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            //object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classPublicMethods.Where(n => n.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            foreach (var method in classNonPublicMethods.Where(n => n.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in classPrivateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            foreach (var method in classMethods.Where(n => n.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in classMethods.Where(n => n.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
