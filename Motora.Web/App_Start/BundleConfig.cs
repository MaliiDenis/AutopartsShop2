using System.Web;
using System.Web.Optimization;

namespace Motora.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Create a new script bundle for JavaScript files
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-3.4.1.min.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/custom.js"));

            // Create a new style bundle for CSS files
            bundles.Add(new StyleBundle("~/bundles/css").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/style.css",
                "~/Content/css/responsive.css"));
        }
    }
}