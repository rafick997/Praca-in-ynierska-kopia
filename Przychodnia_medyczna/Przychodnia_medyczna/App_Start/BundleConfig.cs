using System.Web;
using System.Web.Optimization;

namespace Przychodnia_medyczna
{
    public class BundleConfig
    {
      
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(

                "~/Scripts/jquery.scrollex.min.js",
                "~/Scripts/jquery.scrolly.min.js",
                "~/Scripts/util.js",
                "~/Scripts/skel.js",
                "~/Scripts/main.js"
                 
               ));
            bundles.Add(new ScriptBundle("~/bundles/jquery2").Include(

             "~/Scripts/jquery-1.11.1.min.js",
              "~/Scripts/custom.js",
              "~/Scripts/html5shiv.min.js",
              "~/Scripts/lumino.glyphs.js",
              "~/Scripts/.bootstrap-datepicker",
        
              "~/Scripts/bootstrap-datepicker.min.js",
              "~/Scripts/respond.js",
               "~/Scripts/transition.min.js"
             ));

          //  bundles.Add(new ScriptBundle("~/bundles/jquery2").Include(

          //"~/Scripts/jquery-1.11.1.min.js",
          // "~/Scripts/jquery.scrollex.min.js",
          // "~/Scripts/jquery.scrolly.min.js",
          // "~/Scripts/util.js",
          // "~/Scripts/custom.js",
          // "~/Scripts/html5shiv.min.js",
          // "~/Scripts/lumino.glyphs.js",
          // "~/Scripts/.bootstrap-datepicker",
          // "~/Scripts/bootstrap.js",
          // "~/Scripts/bootstrap-datepicker.min.js",
          // "~/Scripts/respond.js",
          // "~/Scripts/main.js",
          //  "~/Scripts/transition.min.js"



          //));



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
                      
                      "~/Content/template/Admin/bootstrap.min.css",
                      "~/Content/template/Admin/bootstrap-table.css",
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
