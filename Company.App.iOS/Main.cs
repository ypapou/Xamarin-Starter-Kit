using System.Diagnostics.CodeAnalysis;
using UIKit;

namespace Company.App.Ios
{
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1649:File name must match first type name",
        Justification = "This is default file name.",
        Scope = "type",
        Target = "~T:Company.App.Ios.Application")]
    public class Application
    {
        // This is the main entry point of the application.
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
