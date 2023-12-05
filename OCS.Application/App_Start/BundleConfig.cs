using System.Web;
using System.Web.Optimization;

namespace OCS.Application
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //client css files
            bundles.Add(new StyleBundle("~/bundles/client/css").Include(
                "~/Content/client/css/style.css",
                "~/Content/client/font/PermanentMarker/PermanentMarker.css"));

            //client js files
            bundles.Add(new ScriptBundle("~/bundles/client/js").Include(
                "~/Scripts/client/js/swiper.js",
                "~/Scripts/client/js/main.js"));

            //dashboard css files
            bundles.Add(new StyleBundle("~/bundles/dashboard/css").Include(
                      "~/Content/dashboard/css/sb-admin-2.css"));

            //dashboard js files
            bundles.Add(new ScriptBundle("~/bundles/dashboard/js").Include(
                "~/Content/dashboard/vendor/jquery/jquery.min.js",
                "~/Content/dashboard/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/dashboard/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/dashboard/vendor/chart/Chart.bundle.min.js",
                "~/Content/dashboard/js/sb-admin-2.min.js",
                "~/Content/dashboard/js/demo/chart-area-demo.js",
                "~/Content/dashboard/js/demo/chart-bar-demo.js",
                "~/Content/dashboard/js/demo/chart-pie-demo.js",
                "~/Content/dashboard/js/demo/datatables-demo.js"));

            //form css files
            bundles.Add(new StyleBundle("~/bundles/form/css").Include(
                "~/Content/form/vendor/datepicker/daterangepicker.css",
                "~/Content/form/vendor/mdi-font/css/material-design-iconic-font.min.css",
                "~/Content/form/vendor/select2/select2.min.css",
                "~/Content/form/css/main.css"));

            //form js files
            //bundles.Add(new ScriptBundle("~/bundles/form/js").Include(
            //    "~/Content/form/vendor/jquery/jquery.min.js",
            //    "~/Content/form/vendor/select2/select2.min.js",
            //    "~/Content/form/vendor/datepicker/moment.min.js",
            //    "~/Content/form/vendor/datepicker/daterangepicker.js",
            //    "~/Content/form/js/global.js"));
        }
    }
}
