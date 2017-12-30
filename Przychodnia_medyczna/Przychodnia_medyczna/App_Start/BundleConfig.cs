using System.Web;
using System.Web.Optimization;

namespace Przychodnia_medyczna
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                     
                   
                     "~/Scripts/jquery.scrollex.min.js",
                     "~/Scripts/jquery.scrolly.min.js",
                     "~/Scripts/util.js",
                     "~/Scripts/chart.min.js",
                     "~/Scripts/chart-data.js",
                     "~/Scripts/custom.js",
                     "~/Scripts/easypiechart.js",
                     "~/Scripts/easypiechart-data.js",
                     "~/Scripts/html5shiv.min.js",
                     "~/Scripts/lumino.glyphs.js",
                     "~/Scripts/.bootstrap-datepicker",
                     "~/Scripts/bootstrap.js",
                     "~/Scripts/bootstrap-datepicker.min.js",
                     "~/Scripts/respond.js",
                     "~/Scripts/main.js",
                      "~/Scripts/transition.min.js"


                     
                    ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-2.6.2.js"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/bootstrap-datepicker.min.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/template/Admin/bootstrap.css",
                      "~/Content/template/Admin/bootstrap.min.css",
                      "~/Content/template/Admin/bootstrap-table.css",
                      "~/Content/template/Admin/bootstrap-theme.css",
                      "~/Content/template/Admin/bootstrap-theme.min.css",
                      "~/Content/template/Admin/datepicker.css",
                      "~/Content/template/Admin/datepicker3.css",
                      "~/Content/template/Admin/font-awesome.min.css",
                      "~/Content/template/Admin/styles.css"
                 ));

            bundles.Add(new StyleBundle("~/Content2/css").Include(
                 "~/Content/PagedList.css",
                 "~/Content/template/Default/main.css",
                 "~/Content/template/Default/ie9.css",
                 "~/Content/template/Default/ie8.css",
                 "~/Content/template/Default/font-awesome.min.css"

                 ));
        }
    }
}
