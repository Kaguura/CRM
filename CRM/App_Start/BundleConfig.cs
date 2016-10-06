using System.Web;
using System.Web.Optimization;

namespace CRM
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
                      "~/Scripts/angular.min.js",
                      "~/Scripts/ui-bootstrap-tpls-2.1.4.min.js",
                      "~/Scripts/angular-route.min.js",
                      "~/Scripts/angular-animate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/SPA").Include(
                      "~/SPA/ApiService.js",
                      "~/SPA/Controllers/ViewStudentController.js",
                      "~/SPA/Controllers/StudentController.js",
                      "~/SPA/Controllers/ViewCourseController.js",
                      "~/SPA/Controllers/CourseController.js",
                      "~/SPA/Controllers/ViewEventController.js",
                      "~/SPA/Controllers/EventController.js",
                      "~/SPA/App.js"));

            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                      "~/Scripts/script.js"));
        }
    }
}
