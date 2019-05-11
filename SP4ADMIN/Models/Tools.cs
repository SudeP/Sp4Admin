using System.Diagnostics;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System;

namespace SP4ADMIN.Models
{
    public class Tools : Controller
    {
        private readonly static string urlHome = "/Home/Main";
        private readonly static string urlLogin = "/Home/Index";
        private static string paramNameAndValue = string.Empty;

        public static string UrlHome => urlHome;
        public static string UrlLogin => urlLogin;
        public static string ParamNameAndValue
        {
            get => paramNameAndValue;
            set => paramNameAndValue = value;
        }

        public static bool IsLogin(Controller controller, string key)
        {
            return controller.Session[key] is null ? false : true;
        }

        public static string GetMethodName => new StackTrace().GetFrame(1).GetMethod().Name;
        public static string GetControllerName => new StackTrace().GetFrame(1).GetMethod().DeclaringType.Name.Replace("Controller", "");
        public static void NameFill(Controller controller)
        {
            controller.ViewBag.Method = new StackTrace().GetFrame(1).GetMethod().Name;
            controller.ViewBag.Controller = new StackTrace().GetFrame(1).GetMethod().DeclaringType.Name.Replace("Controller", "");
        }
        [Obsolete]
        public static Dictionary<string, string> GetParamaterListToString(MethodBase info)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            info.GetParameters().ToList().ForEach(param =>
            {
                keyValues.Add(param.Name, param.Name);
            });
            return null;
        }
    }
    [Serializable]
    public sealed class TraceAttribute : Attribute/*OnMethodBoundaryAspect*/
    {
        private readonly string category;

        public TraceAttribute(string category)
        {
            this.category = category;
        }

        public string Category { get { return category; } }

        //public override void OnEntry(MethodExecutionArgs args)
        //{
        //    Tools.ParamNameAndValue = string.Empty;
        //    Tools.ParamNameAndValue += $"{category}: Entering {args.Method.DeclaringType.Name}.{args.Method.Name}." + args.ReturnValue + Environment.NewLine;
        //    for (int x = 0; x < args.Arguments.Count; x++)
        //        Tools.ParamNameAndValue += args.Method.GetParameters()[x].Name + " = " + args.Arguments.GetArgument(x) + args.ReturnValue + Environment.NewLine;
        //}

        //public override void OnExit(MethodExecutionArgs args)
        //{
        //    Tools.ParamNameAndValue += "Return Value: " + args.ReturnValue + Environment.NewLine;
        //    Tools.ParamNameAndValue += $"{category}: Leaving {args.Method.DeclaringType.Name}.{args.Method.Name}.";
        //}
    }
}